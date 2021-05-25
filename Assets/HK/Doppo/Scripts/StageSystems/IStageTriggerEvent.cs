using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.StageSystems.Events
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStageTriggerEvent
    {
        IObservable<Unit> Invoke();
    }
}
