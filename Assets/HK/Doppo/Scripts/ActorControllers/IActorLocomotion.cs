using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public interface IActorLocomotion
    {
        void Move(Vector3 vector);

        void SetRotation(Quaternion rotation);

        void AddRotation(Quaternion addValue);

        void Warp(Vector3 position, Quaternion rotation);
    }
}
