using UniRx;

namespace HK.Doppo.MuzzleActions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMuzzleAction
    {
        void Invoke(Actor actor, CompositeDisposable disposable);
    }
}
