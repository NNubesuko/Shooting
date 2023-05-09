namespace KataokaLib.AutoTest.ReplaceObjects
{
    public sealed class DescriptionText : IReplaceObject
    {
        public string Value { get; private set; }

        public DescriptionText(string value)
        {
            Value = value;
        }
    }
}