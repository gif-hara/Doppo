using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class PlayerInputController : IDisposable
    {
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
                    actor.CharacterController.Move(vector);
                })
                .AddTo(disposables);
        }
    }
}
