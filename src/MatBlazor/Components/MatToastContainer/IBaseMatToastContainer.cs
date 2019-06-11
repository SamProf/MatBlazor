using System;
using System.Collections.Generic;
using MatBlazor.Services.Toast;
using MatBlazor.MatToaster.Helpers;


namespace MatBlazor.Components.MatToast
{
    /// <inheritdoc />
    /// <summary>
    /// Represents an instance of the MatToaster engine
    /// </summary>
    public interface IBaseMatToastContainer : IDisposable
    {
        /// <summary>
        /// The current list of toasts (either displayed or waiting to be shown)
        /// </summary>
        IList<IBaseMatToast> Toasts { get; }

        /// <summary>
        /// The global <see cref="MatBlazor.Services.Toast.Configuration"/> 
        /// </summary>
        Configuration Configuration { get; }

        /// <summary>
        /// An event raised when the list of toasts changes or a global configuration setting is modified
        /// </summary>
        event Action OnToastsUpdated;

        /// <summary>
        /// Displays a toast with the specified <see cref="MatBlazor.MatToast" />
        /// </summary>
        /// <param name="message">The toast main message</param>
        /// <param name="type">The optional toast <see cref="MatBlazor.MatToaster.Helpers.ToastType"/></param>
        /// <param name="title">The optional toast tile</param>
        /// <param name="icon">The optional toast icon</param>
        /// <param name="configure">An action for configuring a <see cref="Options"/> instance already containing the globally configured settings</param>
        void Add(string message, ToastType type, string title = null, string icon = null, Action<Options> configure = null);

        /// <summary>
        /// Hides all the toasts, including the ones waiting to be displayed
        /// </summary>
        void Clear();

        /// <summary>
        /// Hides the specified <see cref="IBaseMatToast"/>
        /// </summary>
        /// <param name="matToast">The <see cref="IBaseMatToast"/> to be hidden</param>
        void Remove(IBaseMatToast matToast);
    }
}
