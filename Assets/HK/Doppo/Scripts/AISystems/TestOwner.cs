using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.AISystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TestOwner : MonoBehaviour, IOwner
    {
        IObservable<Unit> IOwner.UpdateAsObservable()
        {
            return this.UpdateAsObservable();
        }
    }
}
