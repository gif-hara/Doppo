using System.Collections.Generic;
using UniRx;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMuzzleAction
    {
        void Invoke(Actor spawnedActor, Actor spawnedActorOwner, List<IMuzzleModifier> modifiers, CompositeDisposable disposable);
    }
}
