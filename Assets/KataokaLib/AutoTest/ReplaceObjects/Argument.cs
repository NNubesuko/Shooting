namespace KataokaLib.AutoTest.ReplaceObjects
{
    public sealed class Argument : IReplaceObject
    {
        public string Type { get; private set; }
        public string Value { get; private set; }

        public Argument(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}