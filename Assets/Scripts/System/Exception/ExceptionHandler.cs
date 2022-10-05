using System;

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

        public static void ThrowWhenLowValueGiggerThanHighValue<T> (
            float lowValue,
            float highValue,
            T exception
        ) where T : Exception {
            if (lowValue > highValue) throw exception;
        }

    }
    
}
