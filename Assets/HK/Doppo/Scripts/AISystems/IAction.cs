using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.AISystems
{
    /// <summary>
    /// 何かしらの行動を実行するインターフェイス
    /// </summary>
    public interface IAction
    {
        void Enter(IOwner owner, IObservable<Unit> ignition);

        void Exit();
    }
}
