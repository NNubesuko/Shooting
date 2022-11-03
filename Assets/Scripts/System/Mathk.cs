using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systemk {

    public class Mathk {

        // * 加算、減算、乗算、除算に分けてしまっているため、もっと良い方法を見つける

        public static int OverflowControlDuringAddition(int lhValue, int rhValue) {
            int value = 0;

            try {
                checked {
                    value = lhValue + rhValue;
                }
            } catch (OverflowException) {
                value = int.MaxValue;
            }

            return value;
        }

        public static int OverflowControlDuringSubtraction(int lhValue, int rhValue) {
            int value = 0;

            try {
                checked {
                    value = lhValue - rhValue;
                }
            } catch (OverflowException) {
                value = int.MinValue;
            }

            return value;
        }

        public static int OverflowControlDuringMultiplication(int lhValue, int rhValue) {
            int value = 0;

            try {
                checked {
                    value = lhValue * rhValue;
                }
            } catch (OverflowException) {
                value = int.MaxValue;
            }

            return value;
        }
        
        public static int OverflowControlDuringDivision(int lhValue, int rhValue) {
            int value = 0;

            try {
                checked {
                    value = lhValue / rhValue;
                }
            } catch (OverflowException) {
                value = int.MinValue;
            }

            return value;
        }

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