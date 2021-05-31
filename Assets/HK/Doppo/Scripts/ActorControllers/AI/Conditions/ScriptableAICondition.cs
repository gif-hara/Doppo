﻿using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.ActorControllers.AISystems
{
    /// <summary>
    /// <see cref="ScriptableObject"/>で定義可能な<see cref="IAICondition"/>
    /// </summary>
    public abstract class ScriptableAICondition : ScriptableObject, IAICondition
    {
        public abstract IObservable<Unit> Satisfy(Actor owner, ActorAIController ownerAI);
    }
}
