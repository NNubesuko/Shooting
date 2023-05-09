using System.Collections.Generic;

namespace KataokaLib.AutoTest.ReplaceObjects
{
    public sealed class TestCases : IReplaceObject
    {
        public List<string> Cases { get; private set; }

        public TestCases(List<string> cases)
        {
            Cases = cases;
        }
    }
}