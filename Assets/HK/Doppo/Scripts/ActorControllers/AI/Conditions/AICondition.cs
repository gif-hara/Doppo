using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.ActorControllers.AISystems
{
    /// <summary>
    /// <see cref="IAICondition"/>の抽象クラス
    /// </summary>
    public abstract class AICondition : IAICondition
    {
        public abstract IObservable<Unit> Evalute(Actor owner, ActorAIController ownerAI);
    }
}
