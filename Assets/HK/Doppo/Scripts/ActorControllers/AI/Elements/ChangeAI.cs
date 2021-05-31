using UniRx;
using UnityEngine;

namespace HK.Doppo.ActorControllers.AISystems
{
    /// <summary>
    /// AIを切り替えるAI
    /// </summary>
    public sealed class ChangeAI : AIElement
    {
        [SerializeField]
        private string nextAIName = default;

        public override void Enter(Actor owner, ActorAIController ownerAI)
        {
            base.Enter(owner, ownerAI);

            this.GetObserver(owner)
                .SubscribeWithState2(this, owner, (_, _this, _owner) =>
                {
                    ownerAI.ChangeAI(this.nextAIName);
                })
                .AddTo(this.events);
        }
    }
}
