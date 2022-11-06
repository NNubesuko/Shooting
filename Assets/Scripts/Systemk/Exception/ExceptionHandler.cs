using System;
using System.Linq;
using UnityEngine;

namespace Systemk.Exceptions {

    public class ExceptionHandler {

        public static void ThrowWhenInvalidValue<T>(
            int value,
            int MIN,
            int MAX,
            T exception
        ) where T : Exception {
            if (value < MIN || value > MAX) throw exception;
        }

        public static void ThrowWhenInvalidValue<T>(
            float lowValue,
            float highValue,
            float MIN,
            float MAX,
            T exception
        ) where T : Exception {
            if (lowValue < MIN || highValue > MAX) throw exception;
        }

        public static void ThrowWhenLowValueGiggerThanHighValue<T>(
            float lowValue,
            float highValue,
            T exception
        ) where T : Exception {
            if (lowValue > highValue) throw exception;
        }

        public static void ThrowWhenEnumDoesNotExist<T>(
            int MIN,
            int MAX,
            T exception,
            params int[] values
        ) where T : Exception {
            int[] subjectOfCompaison = Enumerable.Range(MIN, MAX - MIN + 1).ToArray<int>();
            for (int i = 0; i < subjectOfCompaison.Length; i++) {
                if (subjectOfCompaison.Length != values.Length) {
                    throw exception;
                }

                if (subjectOfCompaison[i] != values[i]) {
                    throw exception;
                }
            }
        }

    }

}
