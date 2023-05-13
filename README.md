# Shooting
Shooting Game

### 目的
 * TDDとDDDを組み合わせて、ゲームを開発できるのかに興味を持ったから<br>
 　-> TDDとDDDはゲーム開発で取り込むには、難しいところが多いと聞いたため、実際に書いて確認する
 * ユーザーに不具合を気にせずにゲームをプレイして欲しい

### 将来
 * Unity DOTSと組み合わせて、安全で高速なゲームを作る
 * 現在抽象クラスの演算に不安な部分があるため、.NET7.0以上を使用したい<br>
 - 理由と現状
   - 抽象クラスのdynamic演算を型制限をしたジェネリック同士で演算を行いたい
   - Visual Studioで使用したいインターフェースや抽象クラスをdllファイルで作成したが、Unityで使用できなかった
   - Unityに.NET7.0以上を使用できないか、問い合わせ中...

## メモ
 * ValueObjectのスクリプト自体のサイズとインスタンスのサイズは、8byte以下であること<br>
 - 理由
    - Unityで2Dゲーム開発に一番使用される構造体であるVector2のスクリプト自体のサイズとインスタンスのサイズが8byteであるため<br>

 * ValueObjectなどの単独で完結しているオブジェクトを生成する場合は、Ofメソッドを実装し使用する
 * BulletなどのValueObjectを複数組み合わせたオブジェクトを生成する場合は、Generateメソッドを実装し使用する
 - 理由
    - コードとして、ValueObjectと明確な区別をつけるため
    - ValueObjectと違いゲームの動きに直接関わるオブジェクトであることが多いため<br>

 * ValueObjectをAssert.Thatで比較する場合は、ValueObject.Valueでプリミティブ型の値までアクセスして比較する
 * BulletなどのValueObjectを複数組み合わせたオブジェクトを比較する場合は、オブジェクトでの比較をする
 - 理由
    - ValueObjectは、値を格納する専門のオブジェクトであるため、根本的な値であるプリミティブ型を比較する必要がある
    - ValueObjectを複数組み合わせたオブジェクトは、ValueObjectの単体テスト時に根本的な値のテストがされているため、プリミティブ型の比較をする必要が無い。また、このオブジェクトをテストする場合は、結合テストとなるためプリミティブ型の比較をしていると「.Value」を付けるのを忘れてしまいテストが円滑に行われない。以上のことから、オブジェクト同士の比較の方が直感的に円滑にテストすることができると考えた

### テスト方法

* 正常系テスト
```
[Test]
[TestCase(引数)]
    :
    :
[Description("[正常] テスト内容")]
public void TestMethod(引数) {
    int responseValue = 10;

    TestClass testClass = TestClass.Of(引数);
    Assert.That(testClass.Value, Is.EqualTo(responseValue));
}
```

* 異常系テスト
```
[Test]
[TestCase(引数)]
    :
    :
[Description("[異常] テスト内容")]
public void TestMethod(引数) {
    Assert.That(() =>
        {
            TestClass testClass = TestClass.Of(引数);
        },
        Throws.Type<ArgumentException>()
    );
}
```

### オブジェクト同士の比較

* Is.EqualToは便利だが、既存のもの以外のオブジェクトは比較できない
```
// 初期の状態だと以下のメソッドは比較出来ないため、エラーが出る
[Test]
[TestCase(引数)]
    :
    :
[Description("[正常] テスト内容")]
public void TestMethod(引数) {
    BulletType bulletType = BulletType.Normal;
    BulletAP bulletAP = BulletAP.Of(10);
    BulletSpeed bulletSpeed = BulletSpeed.Of(25);

    Bullet bullet = Bullet.Generate(引数);

    Assert.That(bullet.Type, Is.EqualTo(bulletType));
    Assert.That(bullet.AP, Is.EqualTo(bulletAP));
    Assert.That(bullet.Speed, Is.EqualTo(bulletSpeed));
}
```
-> 解決策：GetHashCodeとEqualsをオーバーライドし、比較できる状態にする

* 解決策実装例
```
// オブジェクト内で以下を追加する
public override int GetHashCode() {
    return (フィールド１, フィールド２, フィールド３, ...).GetHashCode();
}

public override bool Equals(object obj) {
    return obj is 構造体名 other && this.Equals(other);
}

public bool Equals(構造体名 other) {
    return this.GetHashCode() == other.GetHashCode();
}

public static bool operator==(構造体名 lh, 構造体名 rh) {
    return lh.Equals(rh);
}

public static bool operator!=(構造体名 lh, 構造体名 rh) {
    return !(lh == rh);
}

public static bool operator<(構造体名 lh, 構造体名 rh) {
    return lh.Value < rh.Value;
}

public static bool operator>(構造体名 lh, 構造体名 rh) {
    return lh.Value > rh.Value;
}

public static bool operator<=(構造体名 lh, 構造体名 rh) {
    return lh.Value <= rh.Value;
}

public static bool operator>=(構造体名 lh, 構造体名 rh) {
    return lh.Value >= rh.Value;
}
```

### 値オブジェクトのnull判定

```
PlayerHP hp = PlayerHP.Of(100);
if (ReferenceEquals(hp, null)) {
    Debug.Log("null");
} else {
    Debug.Log($"HP: {hp}");
}
```

### スクリプトのサイズテスト

```
[Test]
[TestCase(バイト数)]
[Description("[正常] スクリプト自体のサイズとインスタンスのサイズが、バイト数以下であること")]
public void ValidScriptBytes(バイト数) {
    オブジェクトのインスタンスを生成

    Assert.That(Marshal.SizeOf(typeof(スクリプト)), Is.LessThanOrEqualTo(バイト数));
    Assert.That(Marshal.SizeOf(インスタンス), Is.LessThanOrEqualTo(バイト数));
}
```
