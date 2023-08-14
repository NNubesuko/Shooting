namespace ShootingGame.Gun
{
    public interface IGunFireUseCase
    {
        void Handle(GunFireInputData inputData);
    }
}