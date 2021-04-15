using UnityEngine;
using UnityEngine.Assertions;
using UniRx;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Move : IMuzzleAction
    {
        [SerializeField]
        private float m_Angle = default;

        [SerializeField]
        private float m_Speed = default;

        public void Invoke(Actor actor, CompositeDisposable disposable)
        {
            actor.Events.UpdateSafeAsObservable()
                .Subscribe(_ =>
                {
                    var rotation = actor.transform.localRotation.eulerAngles;
                    rotation.y += m_Angle;
                    actor.Locomotion.Move(Quaternion.Euler(rotation) * Vector3.forward * m_Speed * Time.deltaTime);
                })
                .AddTo(disposable);
        }
    }
}
