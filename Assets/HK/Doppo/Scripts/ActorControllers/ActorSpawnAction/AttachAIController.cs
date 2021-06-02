using System.Collections.Generic;
using HK.Doppo.AISystems;
using HK.Doppo.MuzzleActions;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AttachAIController : IActorSpawnAction
    {
        [SerializeField]
        private AI m_AI = default;

        [SerializeField]
        private string m_InitialNodeName = default;

        public void Invoke(Actor actor)
        {
            var aiController = new AIController(m_AI, actor, m_InitialNodeName);
            actor.Events.OnDeadSafe()
                .Subscribe(_ =>
                {
                    aiController.Dispose();
                });
        }
    }
}
