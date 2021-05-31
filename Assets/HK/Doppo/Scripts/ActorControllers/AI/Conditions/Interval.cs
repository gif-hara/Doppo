using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.ActorControllers.AISystems
{
    /// <summary>
    /// 一定間隔で条件を満たす<see cref="ScriptableAICondition"/>
    /// </summary>
    public sealed class Interval : AICondition
    {
        [SerializeField]
        private float seconds = default;

        public override IObservable<Unit> Evalute(Actor owner, ActorAIController ownerAI)
        {
            return Observable.Interval(TimeSpan.FromSeconds(this.seconds)).AsUnitObservable();
        }
    }
}
