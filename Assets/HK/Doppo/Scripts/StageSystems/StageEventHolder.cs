using System;
using System.Collections.Generic;
using System.Linq;
using HK.Doppo.StageSystems.Events;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.StageSystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class StageEventHolder : MonoBehaviour
    {
        [SerializeReference, SubclassSelector(false, typeof(IStageTriggerEvent))]
        private List<IStageTriggerEvent> m_OnTriggerEnterPlayerEvents = default;

        [SerializeField]
        private StageEventHolder m_OnCompletedEvent = default;

        public void Invoke()
        {
            WhenAll(m_OnTriggerEnterPlayerEvents)
                .DoOnCompleted(() =>
                {
                    m_OnCompletedEvent?.Invoke();
                })
                .Subscribe()
                .AddTo(this);
        }

        private IObservable<Unit> WhenAll(List<IStageTriggerEvent> events)
        {
            return events
                .Select(x => x.Invoke())
                .WhenAll();
        }
    }
}
