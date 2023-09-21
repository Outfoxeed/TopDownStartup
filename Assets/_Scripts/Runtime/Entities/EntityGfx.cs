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
    }
}