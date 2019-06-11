using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Text fields allow users to input, edit, and select text.
    /// </summary>
    public class BaseMatTextField : BaseMatTextField<string>
    {
        [Parameter]
        public string Type { get; set; } = "text";


        public BaseMatTextField()
        {
            this.CallAfterRender(async () => { await Js.InvokeAsync<object>("matBlazor.matTextField.init", Ref); });
        }
    }
}