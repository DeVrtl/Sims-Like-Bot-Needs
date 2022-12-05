using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Bot))]
public abstract class Need<TRefresher> : MonoBehaviour, INeed
    where TRefresher : NeedRefresher
{
    [SerializeField] private float _secondsNeedDecreaseDelay;
    [SerializeField] private float _secondsNeedIncreaseDelay;
    [SerializeField] private int _maxNeedAmount = 100;

    private Bot _bot;
    
    public int Amount { get; private set; }
    public bool IsInNeed => Amount < 50;
    public NeedRefresher TargetRefresher { get; private set; }

    private Coroutine _needDecreaseRoutine;
    private Coroutine _needIncreaseRoutine;

    private void Awake()
    {
        _bot = GetComponent<Bot>();
        
        Amount = Random.Range(0, 100);
        _needDecreaseRoutine = StartCoroutine(CountDecrease());
    }

    private IEnumerator CountDecrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(_secondsNeedDecreaseDelay);
            Amount = Math.Max(0, Amount - 1);
        }
    }

    public void SetTargetRefresher(NeedRefresher refresher)
    {
        TargetRefresher = refresher;
    }

    protected IEnumerator CountIncrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(_secondsNeedIncreaseDelay);
            
            var oldAmount = Amount;

            Amount = Math.Min(_maxNeedAmount, Amount + 1);

            if (Amount == 100 && oldAmount != Amount && TargetRefresher != null)
            {
                TargetRefresher.NotifyBotRefreshed(_bot);
                TargetRefresher = null;

                var stateMachine = _bot.StateMachine;
                stateMachine.Context.TargetRefresher = null;
                stateMachine.SwitchState(stateMachine.Patrol);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TRefresher refresher))
        {
            if (_needDecreaseRoutine != null)
            {
                StopCoroutine(_needDecreaseRoutine);
            }

            _needIncreaseRoutine = StartCoroutine(CountIncrease());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out TRefresher refresher))
        {
            if (_needIncreaseRoutine != null)
            {
                StopCoroutine(_needIncreaseRoutine);
            }

            _needDecreaseRoutine = StartCoroutine(CountDecrease());
        }
    }
}
