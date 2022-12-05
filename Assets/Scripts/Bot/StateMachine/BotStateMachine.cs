using UnityEngine;

public class BotStateMachine : MonoBehaviour
{
    [SerializeField] private BoxStateMachineContext _context;

    public BoxStateMachineContext Context => _context;
    public BotState CurrentState { get; private set; }
    public BotStatePatrol Patrol { get; private set; } = new ();
    public BotStateInteractWithRefresher InteractWithRefresher { get; private set; } = new();

    private void Awake()
    {
        Patrol.Initialize(this, _context);
        InteractWithRefresher.Initialize(this, _context);

        SwitchState(Patrol);
    }

    private void Update()
    {
        CurrentState.UpdateState();
    }

    public void SwitchState(BotState state)
    {
        CurrentState = state;
        CurrentState.EnterState();
    }
}
