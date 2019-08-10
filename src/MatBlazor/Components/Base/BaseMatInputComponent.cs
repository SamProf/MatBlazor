using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MatBlazor
{
    /// <summary>
    /// Base class for any input control that optionally supports an <see cref="EditContext"/>.
    /// </summary>
    /// <typeparam name="T">the natural type of the input's value</typeparam>
    public abstract class BaseMatInputComponent<T> : BaseMatDomComponent
    {
        // This is like InputBase from Microsoft.AspNetCore.Components.Forms,
        // except that it treats [CascadingParameter] EditContext as optional.

        private bool _hasSetInitialParameters;

        [CascadingParameter] EditContext CascadedEditContext { get; set; }

        /// <summary>
        /// Gets the associated <see cref="Microsoft.AspNetCore.Components.Forms.EditContext"/>.
        /// </summary>
        protected EditContext EditContext { get; private set; }

        /// <summary>
        /// Gets the <see cref="FieldIdentifier"/> for the bound value.
        /// </summary>
        protected FieldIdentifier FieldIdentifier { get; private set; }

        /// <summary>
        /// Gets a string that indicates the status of the field being edited. This will include
        /// some combination of "modified", "valid", or "invalid", depending on the status of the field.
        /// </summary>
        protected string FieldClass => EditContext?.FieldClass(FieldIdentifier) ?? string.Empty;

        /// <summary>
        /// Should be invoked by whenever a bound value is changed, such
        /// as right after the value's corresponding <i>ValueChanged</i>
        /// EventCallback is invoked.
        /// </summary>
        protected void NotifyFieldChanged()
        {
            EditContext?.NotifyFieldChanged(FieldIdentifier);
        }

        /// <summary>
        /// Gets or sets an expression that identifies the bound value.
        /// </summary>
        [Parameter] public Expression<Func<T>> ValueExpression { get; private set; }

        /// <inheritdoc />
        public override Task SetParametersAsync(ParameterCollection parameters)
        {
            parameters.SetParameterProperties(this);

            if (!_hasSetInitialParameters)
            {
                // This is the first run -- could put this logic in OnInit, but nice
                // to avoid forcing people who override OnInit to call base.OnInit()

                EditContext = CascadedEditContext;
                if (EditContext != null)
                {
                    if (ValueExpression == null)
                    {
                        throw new InvalidOperationException($"{GetType()} requires a value for the 'ValueExpression' " +
                            $"parameter. Normally this is provided automatically when using 'bind-Value'.");
                    }

                    FieldIdentifier = FieldIdentifier.Create(ValueExpression);
                }
                _hasSetInitialParameters = true;
            }
            else if (CascadedEditContext != EditContext)
            {
                // Not the first run

                // We don't support changing EditContext because it's messy to be clearing up state and event
                // handlers for the previous one, and there's no strong use case. If a strong use case
                // emerges, we can consider changing this.
                throw new InvalidOperationException($"{GetType()} does not support changing the " +
                    $"{nameof(EditContext)} dynamically.");
            }

            // For derived components, retain the usual lifecycle with OnInit/OnParametersSet/etc.
            return base.SetParametersAsync(ParameterCollection.Empty);
        }
    }
}
