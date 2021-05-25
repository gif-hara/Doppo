using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.StageSystems.Events
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SetActiveGameObject : IStageTriggerEvent
    {
        [SerializeField]
        private GameObject m_Target = default;

        [SerializeField]
        private bool m_IsActive = default;

        public IObservable<Unit> Invoke()
        {
            return Observable.Defer(() =>
            {
                m_Target.SetActive(m_IsActive);

                return Observable.ReturnUnit();
            });
        }
    }
}
