using System;
using HK.Doppo.AISystems;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.ActorControllers.AISystems.Actions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Move : Doppo.AISystems.Action
    {
        protected override void OnEnter(IOwner owner, AIController controller, IObservable<Unit> ignition)
        {
            var actor = owner as Actor;
            Assert.IsNotNull(actor);
            var actorStatusController = actor.GetComponent<ActorStatusController>();
            Assert.IsNotNull(actorStatusController);

            ignition
                .Subscribe(_ =>
                {
                    actor.Locomotion.Move(actor.transform.forward * actorStatusController.Current.moveSpeed * Time.deltaTime);
                })
                .AddTo(m_Disposables);
        }
    }
}
