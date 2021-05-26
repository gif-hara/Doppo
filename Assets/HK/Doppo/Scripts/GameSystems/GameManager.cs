using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField]
        private PlayerInputController m_PlayerInputController = default;

        [SerializeField]
        private GameCameraController m_GameCameraController = default;

        [SerializeField]
        private int m_TargetFrameRate = default;

        public Actor Player { get; private set; }

        private void Awake()
        {
            Instance = this;

            m_PlayerInputController.Setup();

            m_GameCameraController.Setup();

            this.OnDestroyAsObservable()
                .Subscribe(_ =>
                {
                    m_PlayerInputController.Dispose();
                    m_GameCameraController.Dispose();
                });

            GameEvents.SpawnedActor
                .Where(x => x.gameObject.tag == "Player")
                .Subscribe(x =>
                {
                    Player = x;
                })
                .AddTo(this);

            Application.targetFrameRate = m_TargetFrameRate;
        }
    }
}
