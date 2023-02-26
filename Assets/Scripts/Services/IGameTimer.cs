using System;

public interface IGameTimer
{
    event Action SecondPassed;

    void Start();
}