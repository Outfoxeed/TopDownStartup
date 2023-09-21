using UnityEngine;

namespace Game.Runtime.WaveSpawner.WaveCommands
{
    [System.Serializable]
    public class WaitCommand : WaveCommand
    {
        [SerializeField] private float _duration;
        private float _startTime;

#if UNITY_EDITOR
        public WaitCommand()
        {
            _editorName = "Wait Cmd";
        }
#endif

        public override void Init(IWaveSpawner waveSpawner)
        {
            _startTime = Time.time;
        }

        public override void Update(float deltaTime)
        {
        }

        public override bool IsFinished => _startTime + _duration <= Time.time;
    }
}