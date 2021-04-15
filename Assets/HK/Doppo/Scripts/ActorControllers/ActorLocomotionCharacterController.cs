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
    }
}
