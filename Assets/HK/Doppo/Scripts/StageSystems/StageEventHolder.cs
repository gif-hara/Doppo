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
        private List<IStageTriggerEvent> m_Events = default;

        [SerializeField]
        private List<StageEventHolder> m_OnCompletedEvents = default;

        public void Invoke()
        {
            m_Events
                .Select(x => x.Invoke())
                .WhenAll()
                .DoOnCompleted(() =>
                {
                    foreach (var i in m_OnCompletedEvents)
                    {
                        i.Invoke();
                    }
                })
                .Subscribe()
                .AddTo(this);
        }
    }
}
