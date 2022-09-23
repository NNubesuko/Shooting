using System;

namespace Systemk {

    public class ExceptionHandler {

        public static void ThrowWhenInvalidValue<T>(int value, int MIN, int MAX, T exception)
        where T : Exception {
            if (value < MIN || value > MAX) throw exception;
        }

    }
    
}
