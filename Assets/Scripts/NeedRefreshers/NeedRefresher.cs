using UnityEngine;

public abstract class NeedRefresher : MonoBehaviour
{
    [SerializeField] private int _maxBots;

    private int _currentBotsAmount;

    public bool IsFull { get; private set; }

    protected bool UpdateIsFull()
    {
	    return IsFull = _currentBotsAmount >= _maxBots;
    }

    protected abstract INeed GetTargetNeed(Bot bot);

    public void AssignBot(Bot bot)
    {
	    var need = GetTargetNeed(bot);

	    need.SetTargetRefresher(this);
	    bot.StateMachine.Context.TargetRefresher = this;

	    _currentBotsAmount += 1;
	    UpdateIsFull();
    }

    public void NotifyBotRefreshed(Bot bot)
    {
	    _currentBotsAmount -= 1;
	    UpdateIsFull();
    }
    
    public bool CanAssignBot(Bot bot)
    {
	    var need = GetTargetNeed(bot);

	    return !IsFull && !bot.HasTargetRefresher && need.IsInNeed;
    }
}
