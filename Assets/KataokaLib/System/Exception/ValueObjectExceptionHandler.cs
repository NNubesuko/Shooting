using System;

namespace KataokaLib.System {

    public class ValueObjectExceptionHandler {

        public static void ThrowsWHenInvalidValue(
            int value,
            int MIN,
            int MAX,
            Exception exception
        ) {
            if (value < MIN || value > MAX) throw exception;
        }

        public static void ThrowsWHenInvalidValue(
            float value,
            float MIN,
            float MAX,
            Exception exception
        ) {
            if (value < MIN || value > MAX) throw exception;
        }

        public static void ThrowsWHenInvalidValue(
            int startValue,
            int endValue,
            int MIN,
            int MAX,
            Exception exception
        ) {
            if (startValue < MIN || endValue > MAX) throw exception;
        }

    }

}
