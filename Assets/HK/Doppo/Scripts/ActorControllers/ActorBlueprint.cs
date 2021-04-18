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

        [SerializeReference, SubclassSelector]
        private List<IActorSpawnAction> m_SpawnActions = default;

        public Actor Spawn(Vector3 position, Quaternion rotation)
        {
            var instance = m_Actor.Spawn();
            instance.transform.localPosition = position;
            instance.transform.localRotation = rotation;

            foreach (var i in m_SpawnActions)
            {
                i.Invoke(instance);
            }

            GameEvents.SpawnedActor.OnNext(instance);

            return instance;
        }
    }
}
