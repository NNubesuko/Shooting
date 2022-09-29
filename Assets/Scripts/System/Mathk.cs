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

        public static float[] KeepValueWithinRange(
            float lowValue,
            float highValue,
            float MIN,
            float MAX
        ) {
            lowValue = Mathf.Max(lowValue, MIN);
            lowValue = Mathf.Min(lowValue, MAX);

            highValue = Mathf.Max(highValue, MIN);
            highValue = Mathf.Min(highValue, MAX);
            
            return new float[2] { lowValue, highValue };
        }

        /**
         * 0に対応したSign
         */
        public static float Sign(float value) {
            if (value == 0f) {
                return 0f;
            } else if (value > 0f) {
                return 1f;
            } else {
                return -1f;
            }
        }

    }

}