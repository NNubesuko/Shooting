public interface Bullet {

    BulletAP AP { get; }
    BulletMoveSpeed MoveSpeed { get; }

    void Init(
        BulletAP ap,
        BulletMoveSpeed moveSpeed
    );

    void Fire();

}