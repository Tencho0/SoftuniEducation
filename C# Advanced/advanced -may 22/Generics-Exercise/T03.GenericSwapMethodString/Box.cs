namespace T03.GenericSwapMethodString
{
    public class Box<T>
    {
        public Box(T element)
        {
            Element = element;
        }
        public T Element{ get; }
        public override string ToString()
        {
            return $"{typeof(T)}: {Element}";
        }
    }
}
