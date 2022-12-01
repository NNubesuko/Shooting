public interface Bullet : IMovable {

    BulletAP AP { get; }
    BulletMoveSpeed MoveSpeed { get; }

    void Init(
        BulletAP ap,
        BulletMoveSpeed moveSpeed
    );

}