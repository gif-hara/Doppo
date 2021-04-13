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
        private PlayerInputController playerInputController = default;

        [SerializeField]
        private GameCameraController gameCameraController = default;

        private void Awake()
        {
            playerInputController.Setup();

            gameCameraController.Setup();

            this.OnDestroyAsObservable()
                .Subscribe(_ =>
                {
                    playerInputController.Dispose();
                });
        }
    }
}
