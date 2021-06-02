using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.AISystems
{
    /// <summary>
    /// 何かしらのイベントを発火するインターフェイス
    /// </summary>
    public interface IIgnition
    {
        IObservable<Unit> AsObservable(IOwner owner);
    }
}
