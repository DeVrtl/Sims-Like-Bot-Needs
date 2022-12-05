using UnityEngine;

public class BotStatePatrol : BotState
{
    private int _waypointIndex;
    private Vector3 _target;

    public override void EnterState()
    {
        UpdateDestination();
    }

    public override void UpdateState()
    {
        if (Context.TargetRefresher != null)
        {
            StateMachine.SwitchState(StateMachine.InteractWithRefresher);
            return;
        }
        
        if (Vector3.Distance(Context.Self.position, _target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    private void UpdateDestination()
    {
        _target = Context.WayPoints[_waypointIndex].position;
        Context.Agent.SetDestination(_target);
    }

    private void IterateWaypointIndex()
    {
        _waypointIndex++;

        if (_waypointIndex == Context.WayPoints.Length)
        {
            _waypointIndex = 0;
        }
    }
}
