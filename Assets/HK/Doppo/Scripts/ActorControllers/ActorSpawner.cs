using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ActorSpawner : MonoBehaviour
    {
        [SerializeField]
        private Actor m_Prefab;

        private void Start()
        {
            var actor = Instantiate(m_Prefab, transform.position, transform.rotation);
            GameEvents.SpawnedActor.OnNext(actor);
        }
    }
}
