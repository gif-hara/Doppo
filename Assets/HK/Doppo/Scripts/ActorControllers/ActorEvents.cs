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

        public Subject<OnTriggerEnterActorData> OnTriggerEnterActor = new Subject<OnTriggerEnterActorData>();

        public class OnTriggerEnterActorData
        {
            public Actor owner;

            public Actor target;
        }
    }
}
