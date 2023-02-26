using System;

public interface ILifeService
{
    int CurrentLifeCount { get; }
    int RemainingTimeToNewLife { get; }

    event Action<int> TimeToNewLifeChanged;
    event Action<int> LifeCountChanged;
    event Action LivesFull;

    void UseLife();
    void RefillLives();
}