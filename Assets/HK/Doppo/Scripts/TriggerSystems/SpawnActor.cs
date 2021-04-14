using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.TriggerSystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SpawnActor : ITrigger
    {
        [SerializeField]
        private Actor m_Prefab = default;

        public void Invoke()
        {
            Debug.Log($"{nameof(SpawnActor)}");
        }
    }
}
