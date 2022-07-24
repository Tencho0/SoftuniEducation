namespace ValidationAttributes.Utilities.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj is string value)
                return !string.IsNullOrEmpty(value);
            return obj != null;
        }
    }
}
