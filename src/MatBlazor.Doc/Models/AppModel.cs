using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace MatBlazor.Demo.Models
{

    public class AppModel
    {
        private readonly object syncObj = new object();
        private int userCount = 0;

        public Assembly AppAssembly => DocAppIndexComponentType.Assembly;
        public Type DocAppIndexComponentType { get; }
        public NavModel NavModel { get; }
        public bool ShowAds { get; }
        public bool ShowRatingSnackBar { get; }
        public Func<IServiceProvider,Task> PreRenderingInitializationAsync { get; }

        public Func<Type, bool> ApiTypeFilter { get; }

        public event EventHandler<int> UserCountChanged;

        public int GetUserCount()
        {
            lock (syncObj)
            {
                return userCount;
            }
        }
        
        public AppModel(Type docAppIndexComponentType,NavModel navModel, bool showAds = true, bool showRatingSnackBar = true, Func<IServiceProvider,Task> preRenderingInitializationAsync = null, Func<Type,bool> apiTypeFilter = null)
        {
            DocAppIndexComponentType = docAppIndexComponentType;
            NavModel = navModel;
            ShowAds = showAds;
            ShowRatingSnackBar = showRatingSnackBar;
            PreRenderingInitializationAsync = preRenderingInitializationAsync;
            ApiTypeFilter = apiTypeFilter;
            if (navModel.NavGroups == null)
                navModel.NavGroups = GenerateNavModel(docAppIndexComponentType);
        }

        private static NavGroupModel[] GenerateNavModel(Type docAppIndexComponentType)
        {
            var navGroupModels = docAppIndexComponentType.Assembly.GetTypes()
                .Where(t => t!= docAppIndexComponentType && typeof(ComponentBase).IsAssignableFrom(t))
                .Select(t => (Type: t, Route: t.GetCustomAttribute<RouteAttribute>(), DisplayInfo: t.GetCustomAttribute<RouteDisplayAttribute>()))
                .Where(x => x.Route != null && (x.DisplayInfo?.Visible ?? true))
                .GroupBy(x => x.DisplayInfo?.Group)
                .Select(group =>
                {
                    var navGroup = new NavGroup(group.Key);
                    navGroup.Order = group.Min(x => x.DisplayInfo.GroupPriority);
                    var navGroupItems = group.Select(
                        i => new NavItem
                        {
                            Order = i.DisplayInfo?.Priority ?? 0,
                            Group = navGroup,
                            Name = i.DisplayInfo?.Text ?? i.Route.Template.Trim('/'),
                            Url = i.Route.Template
                        })
                        .OrderBy(x=>x.Order).ThenBy(x=>x.Name).ToArray();

                    var navGroupModel = new NavGroupModel() { Group = navGroup, Items = navGroupItems };
                    return navGroupModel;
                }).OrderBy(x=>x.Group.Order).ThenBy(x=>x.Group.Name).ToArray();
            return navGroupModels;
        }


        public void AddUserCount(int value)
        {
            lock (syncObj)
            {
                userCount += value;
                OnUserCountChanged(userCount);
            }
        }

        protected virtual void OnUserCountChanged(int e)
        {
            UserCountChanged?.Invoke(this, e);
        }
    }
}