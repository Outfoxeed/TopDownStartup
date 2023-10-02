using UnityEngine;

namespace Game.Runtime.WaveSpawner.WaveCommands
{
    public class CombinedCommand : WaveCommand
    {
        public override bool IsFinished
        {
            get
            {
                for (int i = 0; i < _waveCommands.Length; i++)
                {
                    if (_waveCommands[i].IsFinished)
                    {
                        continue;
                    }

                    return false;
                }

                return true;
            }
        }

        [SerializeReference] private WaveCommand[] _waveCommands;
        
        public override void Init(IWaveSpawner waveSpawner)
        {
            for (var i = 0; i < _waveCommands.Length; i++)
            {
                var waveCommand = _waveCommands[i];
                waveCommand.Init(waveSpawner);
            }
        }

        public override void Update(float deltaTime)
        {
            for (var i = 0; i < _waveCommands.Length; i++)
            {
                var waveCommand = _waveCommands[i];
                waveCommand.Update(deltaTime);
            }
        }
    }
}