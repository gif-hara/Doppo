using System.Collections.Generic;
using HK.Doppo.TriggerSystems;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "Doppo/MuzzleAction")]
    public sealed class MuzzleAction : ScriptableObject, ITrigger
    {
        [SerializeReference, SubclassSelector]
        private List<ITrigger> m_Triggers = default;

        public void Invoke()
        {
        }
    }
}
