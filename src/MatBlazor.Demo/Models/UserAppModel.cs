using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor.Demo.Models
{
    public class UserAppModel : IDisposable
    {
        private readonly AppModel _appModel;

        public UserAppModel(AppModel appModel)
        {
            _appModel = appModel;
            appModel.AddUserCount(1);
        }

        public void Dispose()
        {
            _appModel.AddUserCount(-1);
        }
    }
}