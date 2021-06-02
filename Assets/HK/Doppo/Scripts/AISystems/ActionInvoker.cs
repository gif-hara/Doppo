using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.AISystems
{
    /// <summary>
    /// <see cref="IAction"/>を実行するクラス
    /// </summary>
    [Serializable]
    public sealed class ActionInvoker
    {
        [SerializeField]
        private string m_Comment = default;

        [SerializeReference, SubclassSelector(type: typeof(IIgnition))]
        private List<IIgnition> m_Ignitions = default;

        [SerializeReference, SubclassSelector(type: typeof(IAction))]
        private List<IAction> m_Actions = default;

        public void Enter(IOwner owner, AIController controller)
        {
            var ignition = m_Ignitions
                .Select(x => x.AsObservable(owner))
                .Merge();
            foreach (var i in m_Actions)
            {
                i.Enter(owner, controller, ignition);
            }
        }

        public void Exit()
        {
            foreach (var i in m_Actions)
            {
                i.Exit();
            }
        }
    }
}
