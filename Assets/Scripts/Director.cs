using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
	[SerializeField] private List<NeedRefresher> _needRefreshers;

	private Bot[] _bots;

    private void Start()
    {
		_bots = GetComponentsInChildren<Bot>();
	}

    private void Update()
	{
		foreach (var refresher in _needRefreshers)
		{
			if (!refresher.IsFull)
			{
				foreach (var bot in _bots)
				{
					if (refresher.CanAssignBot(bot)
					    && bot.StateMachine.CurrentState is not BotStateInteractWithRefresher)
					{
						refresher.AssignBot(bot);
					}
				}
			}
		}
	}
}
