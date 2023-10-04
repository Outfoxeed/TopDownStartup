using ScriptableObjectArchitecture;
using UnityEngine;

namespace Game.Runtime.UI
{
    public class TimerPatcher : MonoBehaviour
    {
        [SerializeField] private FloatVariable _gameTime;
        [SerializeField] private TMPro.TMP_Text _text;
        
        private void OnEnable()
        {
            OnGameTimeUpdated(_gameTime.Value);
            _gameTime.AddListener(OnGameTimeUpdated);
        }

        private void OnDisable()
        {
            _gameTime.RemoveListener(OnGameTimeUpdated);
        }

        private void OnGameTimeUpdated(float time)
        {
            _text.text = $"{((int)time / 60):00}:{((int)time % 60):00}";
        }
    }
}