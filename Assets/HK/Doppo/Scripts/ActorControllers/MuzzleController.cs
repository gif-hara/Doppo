using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MuzzleController : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> m_Muzzles = default;

        public void Fire(int muzzleIndex)
        {
            Debug.Log("Fire!");
        }
    }
}
