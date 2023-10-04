using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace Game.Runtime.Entities
{
    public class EntityGfx : MonoBehaviour
    {
        [SerializeField, Required] private SpriteRenderer _sr;

        public void SetSprite(Sprite sprite)
        {
            _sr.sprite = sprite;
        }

        public void LaunchDamageAnim()
        {
            _sr.DOColor(Color.red, 0.2f).OnComplete(() => _sr.DOColor(Color.white, 0.2f));
        }
    }
}