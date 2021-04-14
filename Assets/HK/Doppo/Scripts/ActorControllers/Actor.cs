using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Actor : MonoBehaviour
    {
        public CharacterController CharacterController
        {
            get;
            private set;
        }

        public MuzzleController MuzzleController
        {
            get;
            private set;
        }

        private void Awake()
        {
            CharacterController = GetComponent<CharacterController>();
            Assert.IsNotNull(CharacterController);

            MuzzleController = GetComponent<MuzzleController>();
            Assert.IsNotNull(MuzzleController);
        }
    }
}
