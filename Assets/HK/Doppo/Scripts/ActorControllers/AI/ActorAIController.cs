using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo.ActorControllers.AISystems
{
    /// <summary>
    /// AIを監視して適宜AIを切り替えるクラス
    /// </summary>
    public sealed class ActorAIController : MonoBehaviour
    {
        [SerializeField]
        private AIBundle aiBundle = default;

        /// <summary>
        /// 追いかけている<see cref="Actor"/>
        /// </summary>
        public Actor ChaseTarget { get; set; }

        private string currentAIName;

        private IReadOnlyList<AIElement> anyAIElements = default;

        private IReadOnlyList<AIElement> currentElements = default;

        private Actor owner;

        private readonly Dictionary<string, IReadOnlyList<AIElement>> cachedAIElements = new Dictionary<string, IReadOnlyList<AIElement>>();

        void Start()
        {
            this.owner = this.GetComponent<Actor>();
            Assert.IsNotNull(this.owner);

            this.anyAIElements = this.aiBundle.AnyAIElements;
            foreach (var ai in this.anyAIElements)
            {
                ai.Enter(this.owner, this);
            }

            this.ChangeAI(this.aiBundle.EntryPointName);
        }

        void OnDestroy()
        {
            foreach (var ai in this.anyAIElements)
            {
                ai.Exit(this.owner, this);
            }
            this.ExitAI();
        }

        public void ChangeAI(string name)
        {
            this.ExitAI();

            this.currentAIName = name;

            this.currentElements = this.GetAIElements(name);
            foreach (var element in this.currentElements)
            {
                element.Enter(this.owner, this);
            }
        }

        private void ExitAI()
        {
            if (this.currentElements == null)
            {
                return;
            }

            foreach (var element in this.currentElements)
            {
                element.Exit(this.owner, this);
            }
        }

        private IReadOnlyList<AIElement> GetAIElements(string name)
        {
            if (this.cachedAIElements.ContainsKey(name))
            {
                return this.cachedAIElements[name];
            }

            var aiElements = this.aiBundle.Get(name).AIElements;
            this.cachedAIElements.Add(name, aiElements);

            return aiElements;
        }
    }
}
