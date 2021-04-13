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

        private void Awake()
        {
            playerInputController = new PlayerInputController();
            playerInputController.Setup();

            this.OnDestroyAsObservable()
                .Subscribe(_ =>
                {
                    playerInputController.Dispose();
                });
        }
    }
}
