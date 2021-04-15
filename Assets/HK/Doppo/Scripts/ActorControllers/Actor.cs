using System;
using HK.Doppo.MuzzleActions;
using HK.Framework;
using UniRx;
using UniRx.Triggers;
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

        public MuzzleController MuzzleController
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

            MuzzleController = GetComponent<MuzzleController>();
            Assert.IsNotNull(MuzzleController);

            Events = new ActorEvents(this);
        }

        public void Return()
        {
            m_Pool.Return(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponentInParent<Actor>();
            if (target == null)
            {
                return;
            }

            Events.OnTriggerEnterActor.OnNext(new ActorEvents.OnTriggerEnterActorData { owner = this, target = target });
        }
    }
}
