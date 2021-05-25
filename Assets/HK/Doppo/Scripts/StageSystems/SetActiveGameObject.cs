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

        public void Invoke()
        {
            m_Target.SetActive(m_IsActive);
        }
    }
}
