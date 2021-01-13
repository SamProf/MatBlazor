using System;
using System.Collections.Generic;

namespace MatBlazor
{
    /// <inheritdoc />
    /// <summary>
    /// Represents an instance of the MatToaster engine
    /// </summary>
    public interface IMatToaster : IDisposable
    {
        /// <summary>
        /// The current list of toasts (either displayed or waiting to be shown)
        /// </summary>
        IList<MatToast> Toasts { get; }

        /// <summary>
        /// The global <see cref="MatToastConfiguration"/> 
        /// </summary>
        MatToastConfiguration Configuration { get; }

        /// <summary>
        /// An event raised when the list of toasts changes or a global configuration setting is modified
        /// </summary>
        event Action OnToastsUpdated;

        /// <summary>
        /// Displays a toast with the specified <see cref="MatBlazor.MatToast" />
        /// </summary>
        /// <param name="message">The toast main message</param>
        /// <param name="type">The optional toast <see cref="MatToastType"/></param>
        /// <param name="title">The optional toast tile</param>
        /// <param name="icon">The optional toast icon</param>
        /// <param name="configure">An action for configuring a <see cref="MatToastOptions"/> instance already containing the globally configured settings</param>
        MatToast Add(string message, MatToastType type, string title = null, string icon = null,
            Action<MatToastOptions> configure = null);

        /// <summary>
        /// Hides all the toasts, including the ones waiting to be displayed
        /// </summary>
        void Clear();

        /// <summary>
        /// Hides the specified <see cref="MatToast"/>
        /// </summary>
        /// <param name="matToast">The <see cref="MatToast"/> to be hidden</param>
        void Remove(MatToast matToast);
    }
}
