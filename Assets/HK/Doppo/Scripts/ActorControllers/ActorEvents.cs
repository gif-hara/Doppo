using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ActorEvents
    {
        private Actor m_Actor;

        public ActorEvents(Actor actor)
        {
            m_Actor = actor;
        }

        public IObservable<Unit> UpdateSafeAsObservable()
        {
            return m_Actor.UpdateAsObservable().TakeUntilDisable(m_Actor);
        }

        public IObservable<long> TimerSafe(TimeSpan dueTime)
        {
            return Observable.Timer(dueTime).TakeUntilDisable(m_Actor);
        }

        public IObservable<OnTriggerEnterActorData> OnTriggerEnterActorSafe()
        {
            return OnTriggerEnterActorSubject.TakeUntilDisable(m_Actor);
        }

        public IObservable<OnTriggerEnterStageData> OnTriggerEnterStageSafe()
        {
            return OnTriggerEnterStageSubject.TakeUntilDisable(m_Actor);
        }

        public IObservable<OnTakeDamageData> OnTakeDamageSafe()
        {
            return OnTakeDamageSubject.TakeUntilDisable(m_Actor);
        }

        public IObservable<Unit> OnDeadSafe() => OnDeadSubject.TakeUntilDisable(m_Actor);

        public readonly Subject<OnTriggerEnterActorData> OnTriggerEnterActorSubject = new Subject<OnTriggerEnterActorData>();

        public readonly Subject<OnTriggerEnterStageData> OnTriggerEnterStageSubject = new Subject<OnTriggerEnterStageData>();

        public readonly Subject<OnTakeDamageData> OnTakeDamageSubject = new Subject<OnTakeDamageData>();

        public readonly Subject<Unit> OnDeadSubject = new Subject<Unit>();

        public class OnTriggerEnterActorData
        {
            public Actor owner;

            public Actor target;

            public Collider targetCollider;
        }

        public class OnTriggerEnterStageData
        {
            public Collider targetCollider;
        }

        public class OnTakeDamageData
        {
            /// <summary>
            /// ダメージを与えた<see cref="Actor"/>
            /// </summary>
            public Actor giveDamageActor;

            public int power;
        }
    }
}
