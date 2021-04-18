using System.Collections.Generic;
using System.Linq;
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

        private Actor m_Actor = default;

        private void Awake()
        {
            m_Actor = GetComponent<Actor>();
            Assert.IsNotNull(m_Actor);
        }

        private void OnDestroy()
        {
            m_Disposable.Dispose();
        }

        public void Setup(List<MuzzleAction> muzzleActions)
        {
            m_MuzzleActions = muzzleActions.Select(x => Instantiate(x)).ToList();
        }

        public void Fire(int muzzleIndex)
        {
            var muzzle = m_Muzzles[muzzleIndex];
            m_MuzzleActions[muzzleIndex].Invoke(muzzle.position, muzzle.rotation, m_Actor, m_Disposable);
        }
    }
}
