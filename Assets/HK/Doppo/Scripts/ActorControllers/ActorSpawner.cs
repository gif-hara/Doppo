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
        private ActorBlueprint m_Blueprint;

        private void Start()
        {
            m_Blueprint.Spawn(transform.localPosition, transform.localRotation);
        }
    }
}
