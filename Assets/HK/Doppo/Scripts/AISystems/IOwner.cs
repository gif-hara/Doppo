using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.AISystems
{
    /// <summary>
    /// AIによって行動を行えるオブジェクトを表すインターフェイス
    /// </summary>
    public interface IOwner
    {
        IObservable<Unit> UpdateAsObservable();
    }
}
