using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Game.Runtime.MusketeerEvents;
using UnityEngine;

namespace Game
{
    public class FloatingTextHandler : MonoBehaviour
    {
        [field: SerializeField] public MusketeerEvent Disabled { get; private set; }
        [SerializeField] private Vector2 _offset;
        [SerializeField] private float _lifeDuration = 1f;

        [SerializeField] private TMPro.TMP_Text _text;

        private CancellationTokenSource _cancellationTokenSource;

        private void OnEnable()
        {
            _cancellationTokenSource = new();
            _ = DisableAfterLifeTime();
        }
        
        private void OnDisable()
        {
            Disabled.Invoke();
        }

        private async Task DisableAfterLifeTime()
        {
            await Task.Delay((int)(_lifeDuration * 1000f), _cancellationTokenSource.Token);
            gameObject.SetActive(false);
        } 
        
        public FloatingTextHandler SetPosition(Vector2 worldPosition)
        {
            transform.position = worldPosition + _offset;
            return this;
        }

        public FloatingTextHandler SetText(string text)
        {
            _text.text = text;
            return this;
        }
    }
}
