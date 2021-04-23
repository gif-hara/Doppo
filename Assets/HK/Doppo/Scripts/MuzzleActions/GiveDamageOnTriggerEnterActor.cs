using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GiveDamageOnTriggerEnterActor : IMuzzleAction
    {
        [SerializeField]
        private int m_Power = default;

        public void Invoke(Actor spawnedActor, Actor spawnedActorOwner, List<IMuzzleModifier> modifiers, CompositeDisposable disposable)
        {
            spawnedActor.Events.OnTriggerEnterActorSafe()
                .Subscribe(x =>
                {
                    var data = new IMuzzleModifier.OnGiveDamageData();
                    foreach (var i in modifiers)
                    {
                        i.OnGiveDamage(data);
                    }

                    x.target.Events.OnTakeDamageSubject.OnNext(new ActorEvents.OnTakeDamageData
                    {
                        giveDamageActor = spawnedActorOwner,
                        power = Mathf.FloorToInt(m_Power * data.powerRate)
                    });
                })
                .AddTo(disposable);
        }
    }
}
