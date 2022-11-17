// using System;

// public class ExceptionHandler {

//     public static void ThrowsWhenInvalidValue(int value, int MIN, int MAX, Exception e) {
//         if (value < MIN || value > MAX) throw e;
//     }

// }

// public interface SingleIntValueObject {

//     int Value { get; }
//     int MIN { get; }
//     int MAX { get; }

// }

// public abstract class HP {

//     public int Value { get; }
//     public int MIN { get; }
//     public int MAX { get; }
    
//     protected HP(int value, int MIN, int MAX) {
//         this.MIN = MIN;
//         this.MAX = MAX;
        
//         ExceptionHandler.ThrowsWhenInvalidValue(
//             value,
//             MIN,
//             MAX,
//             new ArgumentException("不正な値が渡されました", nameof(value))
//         );
        
//         Value = value;
//     }
    
//     public override string ToString() {
//         return $"{Value}";
//     }
    
//     public override int GetHashCode() {
//         int result = 31;
//         result *= 37 + Value;
//         result *= 37 + MIN;
//         result *= 37 + MAX;
//         return result;
//     }
    
//     public override bool Equals(object obj) {
//         if (ReferenceEquals(obj, null)) return false;
//         if (ReferenceEquals(this, obj)) return true;
        
//         return obj is HP other && this.Equals(other);
//     }
    
//     public bool Equals(HP other) {
//         return ClassEquals(this, other) && this.GetHashCode() == other.GetHashCode();
//     }
    
//     /*
//      * 同じクラスであるのか判定するメソッド
//      */
//     public static bool ClassEquals(HP lhHP, HP rhHP) {
//         return lhHP.GetType().Name == rhHP.GetType().Name;
//     }
    
//     public static bool operator==(HP lhHP, HP rhHP) {
//         return ClassEquals(lhHP, rhHP) && lhHP.Equals(rhHP);
//     }
    
//     public static bool operator!=(HP lhHP, HP rhHP) {
//         return !(lhHP == rhHP);
//     }

// }

// public class PlayerHP : HP {
//     public const int MIN = 0;
//     public const int MAX = 100;

//     public PlayerHP(int value) : base(value, MIN, MAX) {
//     }

// }

// public class EnemyHP : HP {
//     public const int MIN = 0;
//     public const int MAX = 1000;

//     public EnemyHP(int value) : base(value, MIN, MAX) {
//     }

// }

// public class Hello{
    
//     public static void Main(){
//         HP playerHP1 = new PlayerHP(0);
//         Console.WriteLine(playerHP1.MIN);
//         Console.WriteLine(playerHP1.MAX);
//     }
    
// }
