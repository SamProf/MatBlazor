using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor.Services.Toast
{
    /// <summary>
    /// Defines the css classes to be used for the <see cref="ToastState"/>
    /// </summary>
    public class IconClasses
    {
        /// <summary>
        /// The css class for the Info <see cref="ToastState"/>. Defaults to <see cref="Defaults.Classes.Icons.Info"/>
        /// </summary>
        public string Info { get; set; } = Defaults.Classes.Icons.Info;

        /// <summary>
        /// The css class for the Success <see cref="ToastState"/>. Defaults to <see cref="Defaults.Classes.Icons.Success"/>
        /// </summary>
        public string Success { get; set; } = Defaults.Classes.Icons.Success;

        /// <summary>
        /// The css class for the Warning <see cref="ToastState"/>. Defaults to <see cref="Defaults.Classes.Icons.Warning"/>
        /// </summary>
        public string Danger { get; set; } = Defaults.Classes.Icons.Danger;

        /// <summary>
        /// The css class for the Error <see cref="ToastState"/>. Defaults to <see cref="Defaults.Classes.Icons.Error"/>
        /// </summary>
        public string Warning { get; set; } = Defaults.Classes.Icons.Warning;
    }
}
