using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.AISystems
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class ActionLog : IAction
    {
        [SerializeField]
        private string m_Message = default;

        public void Enter(IOwner owner, AIController controller, IObservable<Unit> ignition)
        {
            ignition
                .Subscribe(_ => Debug.Log(m_Message));
        }

        public void Exit()
        {
        }
    }
}
