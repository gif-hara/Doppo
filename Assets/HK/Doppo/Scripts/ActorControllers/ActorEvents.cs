using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ActorEvents
    {
        public readonly Subject<FireRequestData> FireRequest = new Subject<FireRequestData>();

        public sealed class FireRequestData
        {
            public int muzzleIndex;
        }
    }
}
