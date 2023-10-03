using ScriptableObjectArchitecture;
using UnityEngine;
using Zenject;

namespace Game.Runtime.Injection
{
    public class EventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Scriptable objects
            GameEventBase[] gameEvents = Resources.LoadAll<GameEventBase>("");
            foreach (GameEventBase gameEvent in gameEvents)
            {
                Container.Bind(gameEvent.GetType())
                    .WithId(gameEvent.name)
                    .FromInstance(gameEvent);
            }
        }
    }
}