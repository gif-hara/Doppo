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
        private PlayerInputController playerInputController;

        [SerializeField]
        private GameCameraController gameCameraController = default;

        private void Awake()
        {
            playerInputController = new PlayerInputController();
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
