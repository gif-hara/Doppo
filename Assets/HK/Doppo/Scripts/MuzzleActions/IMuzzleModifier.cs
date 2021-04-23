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

        void OnCoolTime(OnCoolTimeData data);

        public class OnGiveDamageData
        {
            public float powerRate = 1.0f;
        }

        public class OnCoolTimeData
        {
            public float coolTimeRate = 1.0f;
        }
    }
}
