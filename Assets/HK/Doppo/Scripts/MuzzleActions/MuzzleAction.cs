using System;
using System.Collections.Generic;
using HK.Doppo.TriggerSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "Doppo/MuzzleAction")]
    public sealed class MuzzleAction : ScriptableObject
    {
        [SerializeField]
        private List<Element> m_Elements = default;

        public void Invoke(Vector3 position, Quaternion rotation)
        {
            foreach (var e in m_Elements)
            {
                e.Fire(position, rotation);
            }
        }

        [Serializable]
        public class Element
        {
            [SerializeField]
            private ActorBlueprint m_Blueprint = default;

            [SerializeReference, SubclassSelector(false, typeof(IMuzzleAction))]
            private List<IMuzzleAction> m_Triggers = default;

            public void Fire(Vector3 position, Quaternion rotation)
            {
                var actor = m_Blueprint.Spawn(position, rotation);
                foreach (var i in m_Triggers)
                {
                    i.Invoke(actor);
                }
            }
        }
    }
}
