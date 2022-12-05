public interface INeed
{
	int Amount { get; }
	bool IsInNeed { get; }
	NeedRefresher TargetRefresher { get; }

	public void SetTargetRefresher(NeedRefresher refresher);
}