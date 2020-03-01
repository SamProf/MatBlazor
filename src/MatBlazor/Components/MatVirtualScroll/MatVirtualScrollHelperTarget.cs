namespace MatBlazor
{
    public interface IMatVirtualScrollHelperTarget
    {
        bool GetVirtualScrollIsEnabled();
        int GetVirtualScrollItemHeight();
        void MarkStateHasChanged();
    }
}