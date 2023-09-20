using UnityEngine;

namespace Game.Runtime
{
    public interface IHasTransform
    {
        public Transform Transform { get; }
    }
}