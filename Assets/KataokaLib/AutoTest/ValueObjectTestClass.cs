using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace KataokaLib.AutoTest
{
    public class ValueObjectTestClass
    {
        private List<Description> _descriptions;
        private ClassName _className;
        private List<TestCase> _testCases;
        private List<MethodName> _methodNames;
        private ArgumentType _argumentType;

        public ValueObjectTestClass(Type type)
        {
            _descriptions = new List<Description>();
            _descriptions.Add(new Description($"{type.Name}のテスト"));
            _className = new ClassName(type.Name);
        }
    }
}