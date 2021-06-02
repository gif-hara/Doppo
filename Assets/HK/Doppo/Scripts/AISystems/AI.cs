using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.AISystems
{
    /// <summary>
    /// AI機能を持つクラス
    /// </summary>
    [CreateAssetMenu(menuName = "Doppo/AI")]
    public sealed class AI : ScriptableObject
    {
        [SerializeField]
        private List<Node> m_Nodes = default;

        public List<Node> Nodes => m_Nodes;
    }
}
