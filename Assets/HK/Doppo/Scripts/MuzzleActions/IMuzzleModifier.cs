using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMuzzleModifier
    {
        void OnGiveDamage(OnGiveDamageData data);

        public class OnGiveDamageData
        {
            public float powerRate = 1.0f;
        }
    }
}
