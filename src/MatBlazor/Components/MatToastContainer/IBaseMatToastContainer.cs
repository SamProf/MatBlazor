using System;
using System.Collections.Generic;
using MatBlazor.Services.Toast;

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
        /// Displays a toast with the specified <see cref="MatBlazor.Services.Toast" />
        /// </summary>
        /// <param name="type">The toast <see cref="MatBlazor.Services.Toast"/></param>
        /// <param name="message">The toast main message</param>
        /// <param name="title">The optional toast tile</param>
        /// <param name="configure">An action for configuring a <see cref="Options"/> instance already containing the globally configured settings</param>
        void Add(ToastType type, string message, string title = null, Action<Options> configure = null);

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
