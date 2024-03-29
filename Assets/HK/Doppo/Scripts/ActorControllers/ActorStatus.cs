using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class ActorStatus
    {
        public int hitPoint;

        public float moveSpeed;

        public ActorStatus(ActorStatus other)
        {
            this.hitPoint = other.hitPoint;
            this.moveSpeed = other.moveSpeed;
        }
    }
}
