public class BatheNeedRefresher : NeedRefresher
{
	protected override INeed GetTargetNeed(Bot bot)
	{
		return bot.BatheNeed;
	}
}
