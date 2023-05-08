using System;

namespace KataokaLib.AutoTest
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class ValueObjectAttribute : Attribute
    {
        public readonly string directoryName;

        public ValueObjectAttribute(string directoryName)
        {
            this.directoryName = directoryName;
        }
    }
}