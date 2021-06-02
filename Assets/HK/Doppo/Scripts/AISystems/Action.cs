using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.AISystems
{
    /// <summary>
    /// <see cref="IAction"/>の抽象クラス
    /// </summary>
    public abstract class Action : IAction
    {
        protected readonly CompositeDisposable m_Disposables = new CompositeDisposable();

        public void Enter(IOwner owner, AIController controller, IObservable<Unit> ignition)
        {
            OnEnter(owner, controller, ignition);
        }

        public void Exit()
        {
            OnExit();
            m_Disposables.Clear();
        }

        protected virtual void OnEnter(IOwner owner, AIController controller, IObservable<Unit> ignition)
        {
        }

        protected virtual void OnExit()
        {
        }
    }
}
