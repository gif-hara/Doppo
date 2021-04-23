using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AddCoolTime : MuzzleModifierBase
    {
        [SerializeField]
        private float m_Rate = default;

        public override void OnCoolTime(IMuzzleModifier.OnCoolTimeData data)
        {
            data.coolTimeRate += m_Rate;
        }
    }
}
