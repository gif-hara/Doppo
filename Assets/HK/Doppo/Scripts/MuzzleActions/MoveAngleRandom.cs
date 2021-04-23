using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MoveAngleRandom : IMoveAngleSelector
    {
        [SerializeField]
        private float m_Offset = default;

        [SerializeField]
        private float m_Min = default;

        [SerializeField]
        private float m_Max = default;

        public float GetAngle()
        {
            return m_Offset + Random.Range(m_Min, m_Max);
        }
    }
}
