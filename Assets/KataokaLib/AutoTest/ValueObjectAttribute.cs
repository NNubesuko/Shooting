using System;

namespace KataokaLib.AutoTest
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class ValueObjectAttribute : Attribute
    {
        public readonly string directoryName;
        public readonly Object min;
        public readonly Object max;
        public readonly Type valueType;

        public ValueObjectAttribute(string directoryName, Object min, Object max)
        {
            this.directoryName = directoryName;
            this.min = min;
            this.max = max;
            this.valueType = min.GetType();
        }
    }
}