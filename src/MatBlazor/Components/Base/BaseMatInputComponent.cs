using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
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
        protected MatBlazorSwitchT<T> SwitchT = MatBlazorSwitchT<T>.Get();

        protected Type _nullableUnderlyingType;
        private T _value;

        protected BaseMatInputComponent()
        {
        }
        
        [Parameter]
        public bool ValidationDisabled { get; set; }


        [CascadingParameter]
        EditContext CascadedEditContext { get; set; }

        /// <summary>
        /// Gets or sets the value of the input. This should be used with two-way binding.
        /// </summary>
        /// <example>
        /// @bind-Value="model.PropertyName"
        /// </example>
        [Parameter]
        public T Value
        {
            get => _value;
            set
            {
                var old = _value;
                _value = value;
                OnValueChanged(!EqualityComparer<T>.Default.Equals(old, value));
            }
        }


        protected virtual void OnValueChanged(bool changed)
        {
        }

        /// <summary>
        /// Gets or sets a callback that updates the bound value.
        /// </summary>
        [Parameter]
        public EventCallback<T> ValueChanged { get; set; }

        /// <summary>
        /// Gets or sets an expression that identifies the bound value.
        /// </summary>
        [Parameter]
        public Expression<Func<T>> ValueExpression { get; set; }

        /// <summary>
        /// Gets the associated <see cref="Microsoft.AspNetCore.Components.Forms.EditContext"/>.
        /// </summary>
        protected EditContext EditContext { get; set; }

        /// <summary>
        /// Gets the <see cref="FieldIdentifier"/> for the bound value.
        /// </summary>
        protected FieldIdentifier FieldIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the current value of the input.
        /// </summary>
        protected virtual T CurrentValue
        {
            get => _value;
            set
            {
                var hasChanged = !EqualityComparer<T>.Default.Equals(value, Value);
                if (hasChanged && ValidateCurrentValue(value))
                {
                    _value = value;
                    ValueChanged.InvokeAsync(value);
                    EditContext?.NotifyFieldChanged(FieldIdentifier);
                }
            }
        }


        protected virtual bool ValidateCurrentValue(T value)
        {
            return true;
        }


        /// <summary>
        /// Gets a string that indicates the status of the field being edited. This will include
        /// some combination of "modified", "valid", or "invalid", depending on the status of the field.
        /// </summary>
        protected string FieldClass
            => EditContext?.FieldCssClass(FieldIdentifier);

        /// <inheritdoc />
        public override Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);


            if (!ValidationDisabled)
            {
                if (EditContext == null)
                {
                    // This is the first run
                    // Could put this logic in OnInit, but its nice to avoid forcing people who override OnInit to call base.OnInit()

                    if (CascadedEditContext != null)
                    {
                        if (ValueExpression == null)
                        {
                            throw new InvalidOperationException(
                                $"{GetType()} requires a value for the 'ValueExpression' " +
                                $"parameter. Normally this is provided automatically when using 'bind-Value'.");
                        }

                        EditContext = CascadedEditContext;
                        FieldIdentifier = FieldIdentifier.Create(ValueExpression);
                        _nullableUnderlyingType = Nullable.GetUnderlyingType(typeof(T));
                    }
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
            }

            // For derived components, retain the usual lifecycle with OnInit/OnParametersSet/etc.
            return base.SetParametersAsync(ParameterView.Empty);
        }
    }
}