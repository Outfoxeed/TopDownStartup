using System;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Runtime.UI
{
    public class HealthBar : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] private IntVariable _healthVar;
        [SerializeField] private IntVariable _healthMaxVar;

        [Header("UI")] 
        [SerializeField] private Slider _slider;
        [SerializeField] private TMPro.TMP_Text _text;

        private void OnEnable()
        {
            if (_slider != null)
            {
                _slider.maxValue = _healthMaxVar.Value;
            }
            
            OnHealthUpdated(_healthVar.Value);
            _healthVar.AddListener(OnHealthUpdated);
        }

        private void OnDisable()
        {
            _healthVar.RemoveListener(OnHealthUpdated);
        }

        private void OnHealthUpdated(int health)
        {
            if (_slider != null)
            {
                _slider.value = health;
            }
            
            if (_text != null)
            {
                _text.text = $"{health} / {_healthMaxVar.Value}";
            }
        }
    }
}