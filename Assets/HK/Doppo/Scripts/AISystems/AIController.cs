using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.AISystems
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AIController : IDisposable
    {
        private readonly Dictionary<string, Node> m_Nodes = default;

        private readonly IOwner m_Owner = default;

        private string m_CurrentNodeName = default;

        public AIController(AI ai, IOwner owner, string initialNodeName)
        {
            m_Nodes = ai.Nodes.ToDictionary(x => x.NodeName);
            m_Owner = owner;
            Change(initialNodeName);
        }

        public void Change(string nextNodeName)
        {
            if (!string.IsNullOrEmpty(m_CurrentNodeName))
            {
                m_Nodes[m_CurrentNodeName].Exit();
            }

            m_CurrentNodeName = nextNodeName;
            Assert.IsTrue(m_Nodes.ContainsKey(m_CurrentNodeName), $"{m_CurrentNodeName}に紐づく{typeof(Node)}が存在しません");
            m_Nodes[m_CurrentNodeName].Enter(m_Owner, this);
        }

        public void Dispose()
        {
            if (string.IsNullOrEmpty(m_CurrentNodeName))
            {
                return;
            }

            m_Nodes[m_CurrentNodeName].Exit();
        }
    }
}
