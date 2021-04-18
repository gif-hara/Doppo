using System;
using System.Collections.Generic;
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

        private readonly Dictionary<Type, IActorController> m_Controllers = new Dictionary<Type, IActorController>();

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

            Events = new ActorEvents(this);
        }

        public void Return()
        {
            m_Pool.Return(this);
        }

        public T Attach<T>() where T : IActorController, new()
        {
            var type = typeof(T);
            if (m_Controllers.ContainsKey(type))
            {
                return (T)m_Controllers[type];
            }

            var controller = new T();
            controller.Setup(this);

            m_Controllers.Add(type, controller);
            return controller;
        }

        public T GetController<T>() where T : IActorController
        {
            m_Controllers.TryGetValue(typeof(T), out var value);
            return (T)value;
        }

        private void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponentInParent<Actor>();
            if (target == null)
            {
                return;
            }

            Events.OnTriggerEnterActorSubject.OnNext(new ActorEvents.OnTriggerEnterActorData { owner = this, target = target });
        }
    }
}
