namespace KataokaLib.ValueObject {

    public abstract class RangeValueObject<T> : IRangeValueObject<T> {

        public T Start { get; }
        public T End { get; }
        public T MIN { get; }
        public T MAX { get; }

        protected RangeValueObject(T start, T end, T MIN, T MAX) {
            this.MIN = MIN;
            this.MAX = MAX;

            ValueObjectExceptionHandler.ThrowsWHenInValidValue(
                start,
                end,
                MIN,
                MAX,
                ValueObjectExceptionHandler.ArgumentException(nameof(start)),
                ValueObjectExceptionHandler.ArgumentException(nameof(end))
            );

            Start = start;
            End = end;
        }

    }

}