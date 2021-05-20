using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRotationSelector
    {
        Quaternion GetAddRotation(Quaternion origin);
    }
}
