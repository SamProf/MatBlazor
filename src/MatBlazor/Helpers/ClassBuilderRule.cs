namespace ITMS.External.MatBlazor
{
    public abstract class ClassBuilderRule<T>
    {
        public abstract string GetClass(T data);
    }
}