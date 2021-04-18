using System.Collections.Generic;
using HK.Doppo.MuzzleActions;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AttachMuzzleController : IActorSpawnAction
    {
        [SerializeField]
        private List<MuzzleAction> m_Actions = default;

        public void Invoke(Actor actor)
        {
            var muzzleController = actor.GetComponent<MuzzleController>();
            Assert.IsNotNull(muzzleController);

            muzzleController.Setup(m_Actions);
        }
    }
}
