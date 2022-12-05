using System;

public class BotStateInteractWithRefresher : BotState
{
	private NeedRefresher TargetRefresher => Context.TargetRefresher;
	
	public override void EnterState()
	{
		if (TargetRefresher == null)
		{
			throw new InvalidOperationException("No refresher set!");
		}

		Context.Agent.SetDestination(TargetRefresher.transform.position);
	}
}