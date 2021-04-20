using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AddDamage : MuzzleModifierBase
    {
        [SerializeField]
        private float m_Rate = default;

        public override void OnGiveDamage(IMuzzleModifier.OnGiveDamageData data)
        {
            data.powerRate += m_Rate;
        }
    }
}
