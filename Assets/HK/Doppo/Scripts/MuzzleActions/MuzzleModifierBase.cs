using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MuzzleModifierBase : IMuzzleModifier
    {
        public virtual void OnGiveDamage(IMuzzleModifier.OnGiveDamageData data)
        {
        }
    }
}
