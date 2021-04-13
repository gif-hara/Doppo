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
    public sealed class PlayerInputController : IDisposable
    {
        [SerializeField]
        private Cameraman m_Cameraman = default;

        private CompositeDisposable disposables = new CompositeDisposable();

        public void Setup()
        {
            GameEvents.SpawnedActor
                .Where(x => x.gameObject.tag == "Player")
                .Subscribe(x =>
                {
                    Register(x);
                })
                .AddTo(disposables);
        }

        public void Dispose()
        {
            disposables.Dispose();
        }

        private void Register(Actor actor)
        {
            Observable.EveryGameObjectUpdate()
                .Subscribe(_ =>
                {
                    var vector = new Vector3(
                        Input.GetAxis("Horizontal"),
                        0.0f,
                        Input.GetAxis("Vertical")
                        )
                    .normalized;
                    var cameraTransform = m_Cameraman.Camera.transform;
                    var cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;
                    var cameraRight = Vector3.Scale(cameraTransform.right, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

                    vector = (vector.z * cameraForward + vector.x * cameraRight).normalized;
                    actor.CharacterController.Move(vector * Time.deltaTime);
                })
                .AddTo(disposables);
        }
    }
}
