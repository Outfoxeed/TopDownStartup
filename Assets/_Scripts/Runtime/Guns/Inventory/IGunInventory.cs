using Game.Runtime.Guns;

namespace Game.Runtime
{
    public interface IGunInventory
    {
        bool HasGun(GunsType gunsType);
        bool AddGun(GunsType gunType);
    }
}