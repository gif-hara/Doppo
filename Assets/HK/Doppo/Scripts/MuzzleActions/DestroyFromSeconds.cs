using System;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;
using System.Collections.Generic;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DestroyFromSeconds : IMuzzleAction
    {
        [SerializeField]
        private float m_Seconds = default;

        public void Invoke(Actor spawnedActor, Actor spawnedActorOwner, List<IMuzzleModifier> modifiers, CompositeDisposable disposable)
        {
            spawnedActor.Events.TimerSafe(TimeSpan.FromSeconds(m_Seconds))
                .Subscribe(_ =>
                {
                    spawnedActor.Return();
                })
                .AddTo(disposable);
        }
    }
}
