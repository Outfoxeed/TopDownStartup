using Game.Runtime.UpdateSystem;
using UnityEngine;

namespace Game.Runtime.WaveSpawner.WaveCommands
{
    [System.Serializable]
    public abstract class WaveCommand : IUpdate
    {
#if UNITY_EDITOR
        [SerializeField] protected string _editorName;
#endif
        
        public abstract void Init(IWaveSpawner waveSpawner);
        public abstract void Update(float deltaTime);
        public abstract bool IsFinished { get; }
    }
}