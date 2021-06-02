using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.AISystems
{
    /// <summary>
    /// <see cref="AIElement"/>をまとめるクラス
    /// </summary>
    [Serializable]
    public sealed class Node
    {
        [SerializeField]
        private string m_NodeName = default;

        [SerializeField]
        private List<ActionInvoker> m_Elements = default;
    }
}
