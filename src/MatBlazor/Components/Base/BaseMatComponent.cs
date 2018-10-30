using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.MatButton;
using MatBlazor.Helpers;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.Base
{
    public abstract class BaseMatComponent : BlazorComponent
    {
        public ClassMapper ClassMapper { get; } = new ClassMapper();

        protected BaseMatComponent()
        {
            ClassMapper.Get(() => this.Class);
        }

        [Parameter]
        public string Class
        {
            get => _class;
            set
            {
                _class = value;
                ClassMapper.MakeDirty();
            }
        }

        private string _class;
    }
}