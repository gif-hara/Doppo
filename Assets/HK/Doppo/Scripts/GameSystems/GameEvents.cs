using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public static class GameEvents
    {
        public static readonly Subject<Actor> SpawnedActor = new Subject<Actor>();
    }
}
