namespace HK.Doppo.ActorControllers.AISystems
{
    /// <summary>
    /// 1個単位のAIのインターフェイス
    /// </summary>
    public interface IAIElement
    {
        void Enter(Actor owner, ActorAIController ownerAI);

        void Exit(Actor owner, ActorAIController ownerAI);
    }
}
