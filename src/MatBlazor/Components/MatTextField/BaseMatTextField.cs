using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Text fields allow users to input, edit, and select text.
    /// </summary>
    public abstract class BaseMatTextField : MatField<string>
    {
        public BaseMatTextField()
        {
            this.CallAfterRender(async () => { await Js.InvokeAsync<object>("matBlazor.matTextField.init", Ref); });
        }

        protected override string ConvertToValue(string value)
        {
            return value;
        }


        protected override string ConvertFromValue(string value)
        {
            return value;
        }
    }
}