using System;
using System.Collections;
using UnityEngine;

public class GameTimer : IGameTimer
{
    private readonly ICoroutineRunner _coroutineRunner;

    public event Action SecondPassed;
    public GameTimer(ICoroutineRunner coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
    }

    public void Start()
    {
        _coroutineRunner.StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            SecondPassed?.Invoke();
        }
    }
}