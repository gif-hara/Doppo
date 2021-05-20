using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class RotationConstant : IRotationSelector
    {
        [SerializeField]
        private Vector3 m_Value = default;

        public Quaternion GetAddRotation(Quaternion origin)
        {
            return Quaternion.Euler(m_Value * Time.deltaTime);
        }
    }
}
