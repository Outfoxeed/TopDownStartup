using UnityEngine;
using UnityEngine.Pool;

namespace Game
{
    public interface IPoolFactory
    {
        ObjectPool<T> CreatePool<T>(GameObject prefab, int maxCapactity) where T : Component;
    }
}