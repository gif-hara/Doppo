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
        private Actor prefab;

        private void Start()
        {
            var actor = Instantiate(prefab, transform.position, transform.rotation);
            GameEvents.SpawnedActor.OnNext(actor);
        }
    }
}
