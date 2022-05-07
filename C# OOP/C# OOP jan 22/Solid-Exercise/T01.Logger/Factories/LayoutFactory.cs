namespace T01.Logger
{
    using System;
    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            return type switch
            {
                "SimpleLayout" => new SimpleLayout(),
                "XmlLayout" => new XmlLayout(),
                _ => throw new InvalidOperationException("Missing type!"),
            };
        }
    }
}
