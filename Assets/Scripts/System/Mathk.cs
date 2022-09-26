using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systemk {

    public class Mathk {

        public static int KeepValueWithinRange(int value, int MIN, int MAX) {
            value = Mathf.Max(value, MIN);
            value = Mathf.Min(value, MAX);

            return value;
        }

    }

}