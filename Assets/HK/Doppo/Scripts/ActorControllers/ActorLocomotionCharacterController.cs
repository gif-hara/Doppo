using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ActorLocomotionCharacterController : MonoBehaviour, IActorLocomotion
    {
        public CharacterController CharacterController
        {
            get;
            private set;
        }

        void Awake()
        {
            CharacterController = GetComponent<CharacterController>();
            Assert.IsNotNull(CharacterController);
        }

        public void Move(Vector3 vector)
        {
            CharacterController.Move(vector);
        }

        public void Rotation(Quaternion addValue)
        {
            CharacterController.transform.rotation *= addValue;
        }

        public void Warp(Vector3 position, Quaternion rotation)
        {
            CharacterController.enabled = false;
            CharacterController.transform.position = position;
            CharacterController.transform.rotation = rotation;
            CharacterController.enabled = true;
        }
    }
}
