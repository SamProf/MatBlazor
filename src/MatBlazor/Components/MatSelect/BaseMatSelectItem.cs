namespace MatBlazor
{
    public class BaseMatSelectItem<TValue> : CoreMatSelectValue<TValue, TValue>
    {
        protected override int GetKeyFromValue(TValue value)
        {
            return Items.IndexOf(value);
        }

        protected override TValue GetValueFromKey(int key)
        {
            return Items[key];
        }
    }
}