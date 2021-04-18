using UnityEngine;
using UnityEngine.Assertions;
using UniRx;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ActorStatusController : MonoBehaviour
    {
        public ActorStatus Base { get; private set; }

        public ActorStatus Current { get; private set; }

        private void Awake()
        {
            var actor = GetComponent<Actor>();
            actor.Events.OnTakeDamageSafe()
                .Subscribe(x =>
                {
                    Current.hitPoint -= x.power;
                    if (Current.hitPoint <= 0)
                    {
                        actor.Return();
                    }
                });
        }

        public void Setup(ActorStatus actorStatus)
        {
            Base = new ActorStatus(actorStatus);
            Current = new ActorStatus(actorStatus);
        }
    }
}
