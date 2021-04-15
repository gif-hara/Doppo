using System;
using HK.Doppo.MuzzleActions;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Actor : MonoBehaviour
    {
        public IActorLocomotion Locomotion
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
            Locomotion = GetComponent<IActorLocomotion>();
            Assert.IsNotNull(Locomotion);

            MuzzleController = GetComponent<MuzzleController>();
            Assert.IsNotNull(MuzzleController);
        }

        public IObservable<Unit> UpdateSafeAsObservable()
        {
            return this.UpdateAsObservable().TakeUntilDisable(this);
        }
    }
}
