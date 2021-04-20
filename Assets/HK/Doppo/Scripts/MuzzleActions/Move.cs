using UnityEngine;
using UnityEngine.Assertions;
using UniRx;
using System.Collections.Generic;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Move : IMuzzleAction
    {
        [SerializeField]
        private float m_Angle = default;

        [SerializeField]
        private float m_Speed = default;

        public void Invoke(Actor spawnedActor, Actor spawnedActorOwner, List<IMuzzleModifier> modifiers, CompositeDisposable disposable)
        {
            spawnedActor.Events.UpdateSafeAsObservable()
                .Subscribe(_ =>
                {
                    var rotation = spawnedActor.transform.localRotation.eulerAngles;
                    rotation.y += m_Angle;
                    spawnedActor.Locomotion.Move(Quaternion.Euler(rotation) * Vector3.forward * m_Speed * Time.deltaTime);
                })
                .AddTo(disposable);
        }
    }
}
