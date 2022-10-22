# Shooting
Shooting Game

### 目的
 * 簡単なTDDのをゲーム開発に落とし込みたい<br>
 　-> TDDはゲーム開発で取り込むには、難しいところが多いと聞いたため、実際に書いて確認する
 * ゲーム開発方法の見直し<br>
 　-> オブジェクト指向を理解できているのか不安であるため
 * Webサイトとゲームの開発の考え方を統一したい<br>
 　-> ゲームのWebAPIを提供するときに、開発方法を同じにしておけば楽になると考えたから

## メモ
 * ValueObjectのスクリプト自体のサイズとインスタンスのサイズは、8byte未満であること<br>
   -> Unityで2Dゲーム開発に一番使用される構造体であるVector2のスクリプト自体のサイズとインスタンスのサイズが8byteであるため

### テスト方法

* 2022/10/18 テスト方法（正常）
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

* 2022/10/18 テスト方法（異常）
```
[Test]
[TestCase(引数)]
    :
    :
[Description("[異常] テスト内容")]
public void TestMethod(引数) {
    var exception = Assert.Throws<ArgumentException>(() => {
        TestClass testClass = TestClass.Of(引数);
    });

    Assert.That(
        exception.Message,
        Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
    );
}
```

### オブジェクト同士の比較

* Is.EqualToは便利だが、既存の者以外のオブジェクトは比較できない
```
// 初期の状態だと以下のメソッドは比較出来ないため、エラーが出る
[Test]
[TestCase(引数)]
    :
    :
[Description("[正常] テスト内容")]
public void TestMethod(引数) {
    BulletType responseBulletType = BulletType.Normal;
    BulletAP responseBulletAP = BulletAP.Of(10);
    BulletSpeed responseBulletSpeed = BulletSpeed.Of(25);

    Bullet bullet = Bullet.Of(引数);

    Assert.That(bullet.Type, Is.EqualTo(responseBulletType));
    Assert.That(bullet.AP, Is.EqualTo(responseBulletAP));
    Assert.That(bullet.Speed, Is.EqualTo(responseBulletSpeed));
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