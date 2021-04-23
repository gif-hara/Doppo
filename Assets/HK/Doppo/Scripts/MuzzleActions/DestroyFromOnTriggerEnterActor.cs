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
    public sealed class DestroyFromOnTriggerEnter : IMuzzleAction
    {
        public void Invoke(Actor spawnedActor, Actor spawnedActorOwner, List<IMuzzleModifier> modifiers, CompositeDisposable disposable)
        {
            spawnedActor.Events.OnTriggerEnterActorSafe()
                .Subscribe(_ =>
                {
                    spawnedActor.Return();
                })
                .AddTo(disposable);
        }
    }
}
