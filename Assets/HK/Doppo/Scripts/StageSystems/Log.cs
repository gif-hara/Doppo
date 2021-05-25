using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.StageSystems.Events
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Log : IStageTriggerEvent
    {
        [SerializeField]
        private string m_Message = default;

        public IObservable<Unit> Invoke()
        {
            return Observable.Defer(() =>
            {
                Debug.Log(m_Message);

                return Observable.ReturnUnit();
            });
        }
    }
}
