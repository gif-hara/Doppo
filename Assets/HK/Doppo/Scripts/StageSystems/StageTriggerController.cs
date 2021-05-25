using System.Collections.Generic;
using HK.Doppo.StageSystems.Events;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.StageSystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class StageTriggerController : MonoBehaviour
    {
        [SerializeReference, SubclassSelector(false, typeof(IStageTriggerEvent))]
        private List<IStageTriggerEvent> m_OnTriggerEnterPlayerEvents = default;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == Layer.Index.Player)
            {
                foreach (var i in m_OnTriggerEnterPlayerEvents)
                {
                    i.Invoke().Subscribe();
                }
            }
        }
    }
}
