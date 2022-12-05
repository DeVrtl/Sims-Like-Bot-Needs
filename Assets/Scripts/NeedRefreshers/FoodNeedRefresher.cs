public class FoodNeedRefresher : NeedRefresher
{
	protected override INeed GetTargetNeed(Bot bot)
	{
		return bot.FoodNeed;
	}
}
