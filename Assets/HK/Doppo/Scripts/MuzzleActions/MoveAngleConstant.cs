using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MoveAngleConstant : IMoveAngleSelector
    {
        [SerializeField]
        private float m_Angle = default;

        public float GetAngle()
        {
            return m_Angle;
        }
    }
}
