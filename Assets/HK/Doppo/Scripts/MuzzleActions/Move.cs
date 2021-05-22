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
        [SerializeReference, SubclassSelector(type: typeof(IMoveAngleSelector))]
        private IMoveAngleSelector m_AngleSelector = default;

        [SerializeField]
        private float m_Speed = default;

        public void Invoke(Actor spawnedActor, Actor spawnedActorOwner, List<IMuzzleModifier> modifiers, CompositeDisposable disposable)
        {
            var startTime = Time.realtimeSinceStartup;
            var angle = m_AngleSelector.GetAngle();
            spawnedActor.Events.UpdateSafeAsObservable()
                .Subscribe(_ =>
                {
                    var rotation = spawnedActor.transform.rotation.eulerAngles;
                    rotation.y += angle;
                    var velocity = Quaternion.Euler(rotation) * Vector3.forward * m_Speed * Time.deltaTime;
                    spawnedActor.Locomotion.Move(velocity);
                })
                .AddTo(disposable);
            spawnedActor.Events.OnTriggerEnterActorSafe()
                .Subscribe(_ =>
                {
                    Debug.Log($"TotalTime = {Time.realtimeSinceStartup - startTime}");
                })
                .AddTo(disposable);
        }
    }
}
