# Shooting
Shooting Game

### 目的
 * TDDのようなものをゲーム開発に落とし込みたい<br>
 　-> ただの興味本位
 * ゲーム開発方法の見直し<br>
 　-> オブジェクト指向を理解できているのか不安であるため
 * Webサイトとゲームの開発の考え方を統一したい<br>
 　-> ゲームのWebAPIを提供するときに、開発方法を同じにしておけば楽になると考えたから

### メモ
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
public void ThrowsMethod() {
    var exception = Assert.Throws<ArgumentException>(() => {
        // スローが発生する処理
    });

    Assert.That(
        exception.Message,
        Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
    );
}
```
