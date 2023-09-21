namespace Game.Runtime.WaveSpawner.WaveCommands
{
    [System.Serializable]
    public class ClearAllEnemiesCommand : WaveCommand
    {
        public override bool IsFinished => _isFinished;
        private bool _isFinished;
        
#if UNITY_EDITOR
        public ClearAllEnemiesCommand()
        {
            _editorName = "Clear All Enemies Cmd";
        }
#endif
        
        public override void Init(IWaveSpawner waveSpawner)
        {
            waveSpawner.EnemiesManager.RemoveAllEnemies();
            _isFinished = true;
        }

        public override void Update(float deltaTime)
        {
            
        }
    }
}