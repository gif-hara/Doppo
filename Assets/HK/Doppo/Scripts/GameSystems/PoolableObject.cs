using HK.Framework;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class PoolableObject : MonoBehaviour
    {
        private static ObjectPoolBundle<PoolableObject> m_Bundle = new ObjectPoolBundle<PoolableObject>();

        private ObjectPool<PoolableObject> m_Pool;

        public PoolableObject Clone()
        {
            var pool = m_Bundle.Get(this);
            var instance = pool.Rent();

            instance.m_Pool = pool;

            return instance;
        }

        public void Return()
        {
            m_Pool.Return(this);
        }
    }
}
