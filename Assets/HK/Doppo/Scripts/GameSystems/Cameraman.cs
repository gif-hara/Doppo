using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Cameraman : MonoBehaviour
    {
        [SerializeField]
        private Transform m_RootObject = default;

        [SerializeField]
        private Transform m_PivotObject = default;

        [SerializeField]
        private Transform m_DistanceObject = default;

        [SerializeField]
        private Transform m_RigObject = default;

        [SerializeField]
        private Camera m_Camera = default;

        public Vector3 Position
        {
            get => m_RootObject.localPosition;
            set => m_RootObject.localPosition = value;
        }

        public Vector3 Pivot
        {
            get => m_PivotObject.localRotation.eulerAngles;
            set => m_PivotObject.localRotation = Quaternion.Euler(value);
        }

        public float Distance
        {
            get => m_DistanceObject.localPosition.z;
            set
            {
                var pos = m_DistanceObject.localPosition;
                pos.z = value;
                m_DistanceObject.localPosition = pos;
            }
        }

        public Vector3 Rig
        {
            get => m_RigObject.localRotation.eulerAngles;
            set => m_RigObject.localRotation = Quaternion.Euler(value);
        }

        public Camera Camera => m_Camera;
    }
}
