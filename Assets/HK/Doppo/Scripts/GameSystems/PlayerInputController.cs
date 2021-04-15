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

        [SerializeField]
        private float m_MoveSpeed = default;

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
                    var camera = m_Cameraman.Camera;

                    // 移動
                    {
                        var vector = new Vector3(
                            Input.GetAxis("Horizontal"),
                            0.0f,
                            Input.GetAxis("Vertical")
                            )
                        .normalized;
                        var cameraTransform = camera.transform;
                        var cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;
                        var cameraRight = Vector3.Scale(cameraTransform.right, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

                        vector = (vector.z * cameraForward + vector.x * cameraRight).normalized;
                        actor.Locomotion.Move(vector * Time.deltaTime * m_MoveSpeed);
                    }

                    // マウス座標からActorの向きを設定する
                    // https://qiita.com/edo_m18/items/c8808f318f5abfa8af1e
                    {
                        var n = Vector3.up;
                        var x = Vector3.zero;
                        var ray = camera.ScreenPointToRay(Input.mousePosition);
                        var x0 = ray.origin;
                        var m = ray.direction;
                        var h = Vector3.Dot(n, x);

                        var actorDirectionTarget = x0 + (h - Vector3.Dot(n, x0)) / Vector3.Dot(n, m) * m;

                        var diff = actorDirectionTarget - actor.transform.localPosition;
                        diff.y = 0.0f;
                        actor.transform.localRotation = Quaternion.LookRotation(diff, Vector3.up);
                    }

                    // 攻撃
                    {
                        if (Input.GetAxis("Fire1") >= 1.0f)
                        {
                            actor.MuzzleController.Fire(0);
                        }
                    }
                })
                .AddTo(disposables);
        }
    }
}
