using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MuzzleController : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> m_Muzzles = default;

        private List<MuzzleAction> m_MuzzleActions = default;

        private CompositeDisposable m_Disposable = new CompositeDisposable();

        private void OnDestroy()
        {
            m_Disposable.Dispose();
        }

        public void Setup(List<MuzzleAction> muzzleActions)
        {
            m_MuzzleActions = muzzleActions;
        }

        public void Fire(int muzzleIndex)
        {
            var muzzle = m_Muzzles[muzzleIndex];
            m_MuzzleActions[muzzleIndex].Invoke(muzzle.position, muzzle.rotation, m_Disposable);
        }
    }
}
