namespace Game.Runtime.Guns.Factory
{
    public interface IGunFactory
    {
        IGun Create(IShooter owner, GunsType gunType);
    }
}