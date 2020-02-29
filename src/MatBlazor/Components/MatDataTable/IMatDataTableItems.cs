using System.Collections.Generic;

namespace MatBlazor
{
    public interface IMatDataTableItems
    {
        int Length();
        void MarkStateHasChanged();
    }
}