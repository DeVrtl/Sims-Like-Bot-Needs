using UnityEngine;

public class Bot : MonoBehaviour
{
	[SerializeField] BotStateMachine _stateMachine;
	[SerializeField] private BatheNeed _batheNeed;
	[SerializeField] private FoodNeed _foodNeed;
	[SerializeField] private RestNeed _restNeed;

	public BatheNeed BatheNeed => _batheNeed;
	public FoodNeed FoodNeed => _foodNeed;
	public RestNeed RestNeed => _restNeed;
	public BotStateMachine StateMachine => _stateMachine;

	public bool HasTargetRefresher => BatheNeed.TargetRefresher
	                                  || FoodNeed.TargetRefresher
	                                  || RestNeed.TargetRefresher;
}
