namespace KataokaLib.AutoTest.ReplaceObjects
{
    public sealed class FieldName : IReplaceObject
    {
        public string Value { get; private set; }

        public FieldName(string value)
        {
            Value = value;
        }
    }
}