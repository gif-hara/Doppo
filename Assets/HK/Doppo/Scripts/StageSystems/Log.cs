using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.StageSystems.Events
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Log : IStageTriggerEvent
    {
        [SerializeField]
        private string m_Message = default;

        public void Invoke()
        {
            Debug.Log(m_Message);
        }
    }
}
