using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public interface IActorSpawnAction
    {
        void Invoke(Actor actor);
    }
}
