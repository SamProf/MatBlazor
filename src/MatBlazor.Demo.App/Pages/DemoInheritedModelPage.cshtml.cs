using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Services;

namespace MatBlazor.Demo.App
{
    public class DemoInheritedModel : ComponentBase
    {
        public bool MyCheck = false;
        public string MyString = "MatBlazor";
        private int counter = 1;

        protected async Task MyClick()
        {
            await System.Threading.Tasks.Task.Delay(1000);
            MyString = "MatBlazor Button Clicked " + counter++;
            return;
        }
    }
}