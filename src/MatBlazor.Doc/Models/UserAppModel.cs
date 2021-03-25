using System;

namespace MatBlazor.Demo.Models
{
    public class UserAppModel : IDisposable
    {
        private readonly AppModel _appModel;
        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                this.OnTitleChanged();
            }
        }

        public event EventHandler TitleChanged;


        public UserAppModel(AppModel appModel)
        {
            _appModel = appModel;
            appModel.AddUserCount(1);
        }

        public void Dispose()
        {
            _appModel.AddUserCount(-1);
        }

        protected virtual void OnTitleChanged()
        {
            TitleChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}