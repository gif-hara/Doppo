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
        [SerializeField]
        private StageEventHolder m_Event = default;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == Layer.Index.Player)
            {
                m_Event.Invoke();
            }
        }
    }
}
