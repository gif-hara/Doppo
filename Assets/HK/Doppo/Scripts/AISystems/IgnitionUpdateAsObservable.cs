using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.AISystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class IgnitionUpdateAsObservable : IIgnition
    {
        public IObservable<Unit> AsObservable(IOwner owner)
        {
            return owner.UpdateAsObservable();
        }
    }
}
