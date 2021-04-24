using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class InstantiateOnTriggerEnterActor : IMuzzleAction
    {
        [SerializeField]
        private PoolableObject m_Prefab = default;

        public void Invoke(Actor spawnedActor, Actor spawnedActorOwner, List<IMuzzleModifier> modifiers, CompositeDisposable disposable)
        {
            spawnedActor.Events.OnTriggerEnterActorSafe()
                .Subscribe(x =>
                {
                    var direction = Vector3.Scale(spawnedActor.transform.position - x.target.transform.position, new Vector3(1.0f, 0.0f, 1.0f)).normalized;
                    var targetPosition = x.target.transform.position;
                    targetPosition.y = spawnedActor.transform.position.y;
                    targetPosition -= spawnedActor.transform.forward;
                    targetPosition = x.targetCollider.ClosestPoint(targetPosition);
                    var instance = m_Prefab.Clone();
                    instance.transform.position = targetPosition;
                    instance.transform.rotation = spawnedActor.transform.rotation;
                })
                .AddTo(disposable);
        }
    }
}
