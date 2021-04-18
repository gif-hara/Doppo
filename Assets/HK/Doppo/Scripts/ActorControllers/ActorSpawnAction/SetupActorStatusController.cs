using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SetupActorStatusController : IActorSpawnAction
    {
        [SerializeField]
        private ActorStatus m_Status = default;

        public void Invoke(Actor actor)
        {
            var statusController = actor.GetComponentSafe<ActorStatusController>();
            statusController.Setup(m_Status);
        }
    }
}
