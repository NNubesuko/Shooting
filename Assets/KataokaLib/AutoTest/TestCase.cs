namespace KataokaLib.AutoTest
{
    public class TestCase
    {
        public MethodName MethodName { get; private set; }
        public string[] Values { get; private set; }

        public TestCase(MethodName methodName, params string[] values)
        {
            MethodName = methodName;
            Values = values;
        }
    }
}