using System;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;
using System.Collections.Generic;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DestroyFromOnTriggerEnterStage : IMuzzleAction
    {
        [SerializeField]
        private int m_Penetrate = default;

        private int m_CurrentPenetrate = 0;

        public void Invoke(Actor spawnedActor, Actor spawnedActorOwner, List<IMuzzleModifier> modifiers, CompositeDisposable disposable)
        {
            m_CurrentPenetrate = m_Penetrate;
            spawnedActor.Events.OnTriggerEnterStageSafe()
                .Subscribe(_ =>
                {
                    m_CurrentPenetrate--;
                    if (m_CurrentPenetrate <= 0)
                    {
                        spawnedActor.Return();
                    }
                })
                .AddTo(disposable);
        }
    }
}
