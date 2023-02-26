using System;

public class LifeService : ILifeService
{
    private int _currentLifeCount;
    private int _remainingTimeToNewLife;

    public event Action<int> TimeToNewLifeChanged;
    public event Action<int> LifeCountChanged;
    public event Action LivesFull;

    public LifeService(IGameTimer gameTimer)
    {
        SetStartSetup();
        gameTimer.SecondPassed += OnSecondPassed;
    }

    public int CurrentLifeCount => _currentLifeCount; 
    public int RemainingTimeToNewLife => _remainingTimeToNewLife;

    private void SetStartSetup()
    {
        _currentLifeCount = GameConfig.StartLifeCount;
        if (_currentLifeCount != GameConfig.MaxLives)
            _remainingTimeToNewLife = GameConfig.TimeBetweenLife;
    }

    private void OnSecondPassed()
    {
        if (IsMaxLives())
            return;

        if (CanAddNewLife())
            AddNewLife();
        else
            DecreaseTimer();
    }

    private bool IsMaxLives() =>
        _currentLifeCount == GameConfig.MaxLives;

    private void AddNewLife()
    {
        _remainingTimeToNewLife = GameConfig.TimeBetweenLife;
        TimeToNewLifeChanged?.Invoke(_remainingTimeToNewLife);

        _currentLifeCount++;
        LifeCountChanged?.Invoke(_currentLifeCount);

        if (_currentLifeCount == GameConfig.MaxLives)
            LivesFull?.Invoke();
    }

    private bool CanAddNewLife() =>
        _remainingTimeToNewLife <= 1;

    private void DecreaseTimer()
    {
        _remainingTimeToNewLife--;
        TimeToNewLifeChanged?.Invoke(_remainingTimeToNewLife);
    }

    public void UseLife()
    {
        _currentLifeCount--;
        LifeCountChanged?.Invoke(_currentLifeCount);
        TimeToNewLifeChanged?.Invoke(_remainingTimeToNewLife);
    }

    public void RefillLives()
    {
        _remainingTimeToNewLife = GameConfig.TimeBetweenLife;
        _currentLifeCount = GameConfig.MaxLives;
        LifeCountChanged?.Invoke(_currentLifeCount);
            LivesFull?.Invoke();
    }
}
