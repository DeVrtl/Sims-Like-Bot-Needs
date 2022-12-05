public class BotState
{
    public BotStateMachine StateMachine;
    public BoxStateMachineContext Context;

    public void Initialize(BotStateMachine stateMachine, BoxStateMachineContext context)
    {
        StateMachine = stateMachine;
        Context = context;
    }
    
    public virtual void EnterState() { }
    public virtual void UpdateState() { }
}
