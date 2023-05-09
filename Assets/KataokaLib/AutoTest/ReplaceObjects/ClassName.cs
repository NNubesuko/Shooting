namespace KataokaLib.AutoTest.ReplaceObjects
{
    public sealed class ClassName : IReplaceObject
    {
        public string Value { get; private set; }

        public ClassName(string value)
        {
            Value = value;
        }
    }
}