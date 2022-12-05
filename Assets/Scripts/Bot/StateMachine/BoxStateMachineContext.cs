using UnityEngine;
using UnityEngine.AI;

public class BoxStateMachineContext : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _self;

    public Transform[] WayPoints => _wayPoints;
    public NavMeshAgent Agent => _agent; 
    public Transform Self  => _self;

    public NeedRefresher TargetRefresher;
}