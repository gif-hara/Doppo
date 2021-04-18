using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GiveDamage : IMuzzleAction
    {
        [SerializeField]
        private int m_Power = default;

        public void Invoke(Actor spawnedActor, Actor spawnedActorOwner, CompositeDisposable disposable)
        {
            spawnedActor.Events.OnTriggerEnterActorSafe()
                .Subscribe(x =>
                {
                    x.target.Events.OnTakeDamageSubject.OnNext(new ActorEvents.OnTakeDamageData
                    {
                        giveDamageActor = spawnedActorOwner,
                        power = m_Power
                    });
                })
                .AddTo(disposable);
        }
    }
}
