using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ActorLocomotionRigidbody : MonoBehaviour, IActorLocomotion
    {
        public Rigidbody Rigidbody
        {
            get;
            private set;
        }

        void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Assert.IsNotNull(Rigidbody);
        }

        public void Move(Vector3 vector)
        {
            Rigidbody.position += vector;
        }

        public void Rotation(Quaternion addValue)
        {
            Rigidbody.rotation *= addValue;
        }
    }
}
