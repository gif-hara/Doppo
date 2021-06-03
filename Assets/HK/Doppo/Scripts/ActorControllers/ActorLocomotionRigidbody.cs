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

        public void SetRotation(Quaternion rotation)
        {
            Rigidbody.rotation = rotation;
        }

        public void AddRotation(Quaternion addValue)
        {
            Rigidbody.rotation *= addValue;
        }

        public void Warp(Vector3 position, Quaternion rotation)
        {
            Rigidbody.transform.position = position;
            Rigidbody.transform.rotation = rotation;
        }
    }
}
