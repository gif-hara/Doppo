using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.AISystems.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class ChangeNode : Action
    {
        [SerializeField]
        private string m_NodeName = default;

        protected override void OnEnter(IOwner owner, AIController controller, IObservable<Unit> ignition)
        {
            ignition
                .Subscribe(_ => controller.Change(m_NodeName))
                .AddTo(m_Disposables);
        }
    }
}
