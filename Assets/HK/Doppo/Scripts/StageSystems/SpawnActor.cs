using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.StageSystems.Events
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SpawnActor : IStageTriggerEvent
    {
        [SerializeField]
        private ActorBlueprint m_Blueprint = default;

        [SerializeField]
        private Transform m_SpawnPoint = default;

        public IObservable<Unit> Invoke()
        {
            return Observable.Defer(() =>
            {
                m_Blueprint.Spawn(m_SpawnPoint.position, m_SpawnPoint.rotation);

                return Observable.ReturnUnit();
            });
        }
    }
}
