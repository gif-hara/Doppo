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
    public sealed class LookAt : Doppo.AISystems.Action
    {
        protected override void OnEnter(IOwner owner, AIController controller, IObservable<Unit> ignition)
        {
            var actor = owner as Actor;
            Assert.IsNotNull(actor);
            var actorStatusController = actor.GetComponent<ActorStatusController>();
            Assert.IsNotNull(actorStatusController);
            var player = GameManager.Instance.Player;

            ignition
                .Subscribe(_ =>
                {
                    var vector = player.transform.position - actor.transform.position;
                    var target = Quaternion.LookRotation(vector);
                    actor.Locomotion.SetRotation(target);
                })
                .AddTo(m_Disposables);
        }
    }
}
