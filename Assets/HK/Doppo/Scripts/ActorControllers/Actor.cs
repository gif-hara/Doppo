using HK.Framework;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Actor : MonoBehaviour
    {
        public IActorLocomotion Locomotion
        {
            get;
            private set;
        }

        public ActorEvents Events
        {
            get;
            private set;
        }

        private static ObjectPoolBundle<Actor> m_Bundle = new ObjectPoolBundle<Actor>();

        private ObjectPool<Actor> m_Pool;

        public Actor Spawn()
        {
            var pool = m_Bundle.Get(this);
            var instance = pool.Rent();
            instance.m_Pool = pool;

            return instance;
        }

        private void Awake()
        {
            Locomotion = GetComponent<IActorLocomotion>();
            Assert.IsNotNull(Locomotion);

            Events = new ActorEvents(this);
        }

        public void Return()
        {
            m_Pool.Return(this);
        }

        public T GetComponentSafe<T>() where T : class
        {
            var component = GetComponent<T>();
            Assert.IsNotNull(component, $"{this.name}に{typeof(T)}は存在しません");

            return component;
        }

        private void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponentInParent<Actor>();
            if (target != null)
            {
                Events.OnTriggerEnterActorSubject.OnNext(new ActorEvents.OnTriggerEnterActorData
                {
                    owner = this,
                    target = target,
                    targetCollider = other
                });
            }

            if (other.gameObject.layer == Layer.Index.Stage)
            {
                Events.OnTriggerEnterStageSubject.OnNext(new ActorEvents.OnTriggerEnterStageData
                {
                    targetCollider = other
                });
            }
        }
    }
}
