using System.ComponentModel;
using Game.Runtime.UpdateSystem;
using Zenject;

namespace Game.Runtime.Guns.Factory
{
    public class GunFactory : IGunFactory
    {
        [Inject] private IUpdateSystem _updateSystem;
        public IGun Create(IShooter owner, GunsType gunType)
        {
            return gunType switch
            {
                GunsType.Debug => new DebugGune(owner, _updateSystem),
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}