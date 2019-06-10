using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    public abstract class BaseMatDomComponent : BaseMatComponent
    {
        private ElementRef _ref;

        /// <summary>
        /// Returned ElementRef reference for DOM element.
        /// </summary>
        public virtual ElementRef Ref
        {
            get => _ref;
            set
            {
                _ref = value;
                RefBack?.Set(value);
            }
        }

        public string MatBlazorId = IdGeneratorHelper.Generate("matBlazor_id_");

        [CascadingParameter]
        public MatTheme Theme { get; set; }

        protected ClassMapper ClassMapper { get; } = new ClassMapper();


        protected BaseMatDomComponent()
        {
            ClassMapper
                .Get(() => this.Class)
                .Get(() => this.Theme?.GetClass());
        }

        /// <summary>
        /// Specifies one or more classnames for an DOM element.
        /// </summary>
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


        /// <summary>
        /// Specifies an inline style for an DOM element.
        /// </summary>
        [Parameter]
        public string Style
        {
            get => _style;
            set
            {
                _style = value;
                this.StateHasChanged();
            }
        }

        private string _class;
        private string _style;
    }
}