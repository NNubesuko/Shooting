using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using Systemk.Exceptions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    public class StructTest {

        [Test]
        [Description("容量テスト")]
        public void TestMethod() {
            StructMain structMain = StructMain.Of(10);

            Assert.That(Marshal.SizeOf(typeof(StructMain)), Is.LessThan(TestCodeIni.ScriptBytes));
            Assert.That(Marshal.SizeOf(structMain), Is.LessThan(TestCodeIni.ScriptBytes));
        }

    }

}
