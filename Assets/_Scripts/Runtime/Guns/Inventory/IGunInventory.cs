using Game.Runtime.Guns;

namespace Game.Runtime
{
    public interface IGunInventory
    {
        GunsType[] GetGunTypes();
        bool HasGun(GunsType gunsType);
        bool AddGun(GunsType gunType);

        int GunCount();
    }
}