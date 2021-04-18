using System;
using System.Collections.Generic;
using HK.Doppo.TriggerSystems;
using UniRx;
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
        private float m_CoolTimeSeconds = default;

        [SerializeField]
        private List<Element> m_Elements = default;

        private bool m_CanFire = true;

        public void Invoke(Vector3 position, Quaternion rotation, Actor owner, CompositeDisposable disposables)
        {
            if (!m_CanFire)
            {
                return;
            }

            foreach (var e in m_Elements)
            {
                e.Fire(position, rotation, owner, disposables);
            }

            m_CanFire = false;
            owner.Events.TimerSafe(TimeSpan.FromSeconds(m_CoolTimeSeconds))
                .Subscribe(_ => m_CanFire = true);
        }

        [Serializable]
        public class Element
        {
            [SerializeField]
            private ActorBlueprint m_Blueprint = default;

            [SerializeReference, SubclassSelector(false, typeof(IMuzzleAction))]
            private List<IMuzzleAction> m_Triggers = default;

            public void Fire(Vector3 position, Quaternion rotation, Actor spawnedActorOwner, CompositeDisposable disposables)
            {
                var actor = m_Blueprint.Spawn(position, rotation);
                foreach (var i in m_Triggers)
                {
                    i.Invoke(actor, spawnedActorOwner, disposables);
                }
            }
        }
    }
}
