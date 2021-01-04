using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;

namespace MatBlazor
{
    public abstract class BaseMatInputTextElementComponent<T> : BaseMatInputElementComponent<T>
    {
        private bool _previousParsingAttemptFailed;
        private ValidationMessageStore _parsingValidationMessages;


        /// <summary>
        /// Gets or sets the current value of the input, represented as a string.
        /// </summary>
        protected string CurrentValueAsString
        {
            get => FormatValueAsString(CurrentValue);
            set
            {
                _parsingValidationMessages?.Clear();

                bool parsingFailed;

                if (TryParseValueFromString(value, out var parsedValue, out var validationErrorMessage))
                {
                    parsingFailed = false;
                    CurrentValue = parsedValue;
                }
                else
                {
                    parsingFailed = true;

                    if (_parsingValidationMessages == null && EditContext != null)
                    {
                        _parsingValidationMessages = new ValidationMessageStore(EditContext);
                    }

                    _parsingValidationMessages?.Add(FieldIdentifier, validationErrorMessage);

                    // Since we're not writing to CurrentValue, we'll need to notify about modification from here
                    EditContext?.NotifyFieldChanged(FieldIdentifier);
                }

                // We can skip the validation notification if we were previously valid and still are
                if (parsingFailed || _previousParsingAttemptFailed)
                {
                    EditContext?.NotifyValidationStateChanged();
                    _previousParsingAttemptFailed = parsingFailed;
                }
            }
        }

        [Parameter]
        public string Format { get; set; } = null;

        /// <summary>
        /// Formats the value as a string. Derived classes can override this to determine the formating used for <see cref="CurrentValueAsString"/>.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>A string representation of the value.</returns>
        protected virtual string FormatValueAsString(T value)
        {
            return SwitchT.FormatValueAsString(value, Format);
        }

        /// <summary>
        /// Parses a string to create an instance of <typeparamref name="T"/>. Derived classes can override this to change how
        /// <see cref="CurrentValueAsString"/> interprets incoming values.
        /// </summary>
        /// <param name="value">The string value to be parsed.</param>
        /// <param name="result">An instance of <typeparamref name="T"/>.</param>
        /// <param name="validationErrorMessage">If the value could not be parsed, provides a validation error message.</param>
        /// <returns>True if the value could be parsed; otherwise false.</returns>
        protected virtual bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            try
            {
                result = SwitchT.ParseFromString(value, Format);
                validationErrorMessage = null;
                return true;
            }
            catch (Exception e)
            {
                result = default(T);
                validationErrorMessage = e.Message;
                return false;
            }
        }
    }
}