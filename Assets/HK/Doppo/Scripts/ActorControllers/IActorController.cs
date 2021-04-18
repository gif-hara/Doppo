using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public interface IActorController
    {
        Actor Actor { get; }

        void Setup(Actor actor);
    }
}
