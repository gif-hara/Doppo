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
        [SerializeField]
        private PlayerInputController m_PlayerInputController = default;

        [SerializeField]
        private GameCameraController m_GameCameraController = default;

        private void Awake()
        {
            m_PlayerInputController.Setup();

            m_GameCameraController.Setup();

            this.OnDestroyAsObservable()
                .Subscribe(_ =>
                {
                    m_PlayerInputController.Dispose();
                    m_GameCameraController.Dispose();
                });
        }
    }
}
