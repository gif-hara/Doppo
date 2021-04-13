using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class GameCameraController
    {
        [SerializeField]
        private Cameraman m_Cameraman = default;

        private Transform m_ChaseTarget = default;

        private readonly CompositeDisposable m_Disposables = new CompositeDisposable();

        public void Setup()
        {
            GameEvents.SpawnedActor
                .Where(x => x.tag == "Player")
                .Subscribe(x =>
                {
                    m_ChaseTarget = x.transform;
                })
                .AddTo(m_Disposables);

            Observable.EveryGameObjectUpdate()
                .Subscribe(_ =>
                {
                    if (m_ChaseTarget != null)
                    {
                        m_Cameraman.Position = m_ChaseTarget.localPosition;
                    }
                })
                .AddTo(m_Disposables);
        }
    }
}
