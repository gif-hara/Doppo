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

        void Rotation(Quaternion addValue);
    }
}
