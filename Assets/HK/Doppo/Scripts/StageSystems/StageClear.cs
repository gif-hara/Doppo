using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.StageSystems.Events
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class StageClear : IStageTriggerEvent
    {
        public IObservable<Unit> Invoke()
        {
            return Observable.Defer(() =>
            {
                Debug.Log("TODO: Stage Clear");

                return Observable.ReturnUnit();
            });
        }
    }
}
