public class RestNeedRefresher : NeedRefresher
{
	protected override INeed GetTargetNeed(Bot bot)
	{
		return bot.RestNeed;
	}
}
