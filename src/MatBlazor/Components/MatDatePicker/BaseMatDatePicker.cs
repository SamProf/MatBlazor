using System.Threading.Tasks;

namespace MatBlazor
{
    public class BaseMatDatePicker : BaseMatComponent
    {
        public BaseMatDatePicker()
        {
            CallAfterRender(async () => { Js.InvokeAsync<object>("matBlazor.matDatePicker.init", Ref); });
        }
    }
}
