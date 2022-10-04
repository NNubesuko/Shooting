# Shooting
Shooting Game

### 目的
 * TDDのようなものをゲーム開発に落とし込みたい<br>
 　-> ただの興味本位
 * ゲーム開発方法の見直し<br>
 　-> オブジェクト指向を理解できているのか不安であるため
 * Webサイトとゲームの開発の考え方を統一したい<br>
 　-> ゲームのWebAPIを提供するときに、開発方法を同じにしておけば楽になると考えたから

## メモ
 * 全てのValueObjectは、必ずテストを行う

### スローの比較

* 初めはこの形で記述していたが
```
public void TestMethod() {
    void ThrowsMethod() {
        // スローが発生する処理
    }

    Assert.Throws<ArgumentException>(
        ThrowsMethod
    );
}
```

* 現在はこちらに変更した
```
public void TestMethod() {
    var exception = Assert.Throws<ArgumentException>(() => {
        // スローが発生する処理
    });

    Assert.That(
        // 投げられたスローが投げられるべきスローと合っているか

        exception.Message,
        Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
    );
}
```

* テストしたい数値などが複数ある場合
```
public void TestMethod() {
    List<int> invalidNumberList = new List<int>() {
        // int型の数値
    };

    foreach (int value in invalidNumberList) {
        var exception = Assert.Throws<ArgumentException>(() => {
            // スローが投げられる処理
        });

        Assert.That(
            // 投げられたスローが投げられるべきスローと合っているか

            exception.Message,
            Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
        );
    }
}
```

### オブジェクト同士の比較

* Is.EqualToは便利だが、既存の者以外のオブジェクトは比較できない
```
初期の状態だと以下のメソッドは比較出来ないため、エラーが出る
public void ValidNormalBullet() {
    BulletType responseBulletType = BulletType.Normal;
    BulletAP responseBulletAP = BulletAP.Of(10);
    BulletSpeed responseBulletSpeed = BulletSpeed.Of(25);

    Bullet bullet = Bullet.Of(BulletType.Normal);

    Assert.That(bullet.Type, Is.EqualTo(responseBulletType));
    Assert.That(bullet.AP, Is.EqualTo(responseBulletAP));
    Assert.That(bullet.Speed, Is.EqualTo(responseBulletSpeed));
}
```
-> 解決策：GetHashCodeとEqualsをオーバーライドし、比較できる状態にする

* 解決策実装例
```
オブジェクト内で以下を追加する
public override int GetHashCode() {
    return new { パラメータ }.GetHashCode();
}

public override bool Equals(object obj) {
    if (obj == null) return false;
    if (obj == this) return true;

    キャスト確認と型変換
    if (obj is オブジェクト otherObj) {
        if (this.GetHashCode() == otherObj.GetHashCode()) {
            return true;
        }
    }
    return false;
}
```