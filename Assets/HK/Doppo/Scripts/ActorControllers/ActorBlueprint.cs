using System.Collections.Generic;
using HK.Doppo.MuzzleActions;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "Doppo/ActorBlueprints")]
    public sealed class ActorBlueprint : ScriptableObject
    {
        [SerializeField]
        private Actor m_Actor = default;

        [SerializeField]
        private List<MuzzleAction> m_MuzzleActions = default;

        public Actor Spawn(Vector3 position, Quaternion rotation)
        {
            var instance = Instantiate(m_Actor, position, rotation);
            instance.MuzzleController.Setup(m_MuzzleActions);

            GameEvents.SpawnedActor.OnNext(instance);

            return instance;
        }
    }
}
