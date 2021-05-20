using UnityEngine;
using UnityEngine.Assertions;
using UniRx;
using System.Collections.Generic;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Rotation : IMuzzleAction
    {
        [SerializeReference, SubclassSelector(type: typeof(IRotationSelector))]
        private IRotationSelector m_RotationSelector = default;

        public void Invoke(Actor spawnedActor, Actor spawnedActorOwner, List<IMuzzleModifier> modifiers, CompositeDisposable disposable)
        {
            spawnedActor.Events.UpdateSafeAsObservable()
                .Subscribe(_ =>
                {
                    spawnedActor.Locomotion.Rotation(m_RotationSelector.GetAddRotation(spawnedActor.transform.rotation));
                })
                .AddTo(disposable);
        }
    }
}
