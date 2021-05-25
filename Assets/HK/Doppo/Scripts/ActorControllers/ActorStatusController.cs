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

        public void Setup(ActorStatus actorStatus)
        {
            Base = new ActorStatus(actorStatus);
            Current = new ActorStatus(actorStatus);

            var actor = GetComponent<Actor>();
            actor.Events.OnTakeDamageSafe()
                .Subscribe(x =>
                {
                    Current.hitPoint -= x.power;
                    if (Current.hitPoint <= 0)
                    {
                        actor.Events.OnDeadSubject.OnNext(Unit.Default);
                        actor.Return();
                    }
                });
        }
    }
}
