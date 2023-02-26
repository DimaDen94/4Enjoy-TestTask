using TMPro;
using UnityEngine;

public class LivesWidget : MonoBehaviour
{
    private const string FullText = "Full";
    [SerializeField] private TextMeshProUGUI _remainingTime;
    [SerializeField] private TextMeshProUGUI _lifeCount;

    [SerializeField] private bool _hideTimerWhenFull;

    private ILifeService _lifeService;
    private ITimeConverter _timeConverter;

    public void Construct(ILifeService lifeService, ITimeConverter timeConverter) {
        _lifeService = lifeService;
        _timeConverter = timeConverter;

        UpdateLifeCount(_lifeService.CurrentLifeCount);
        UpdateTimer(_lifeService.RemainingTimeToNewLife);

        _lifeService.LifeCountChanged += UpdateLifeCount;
        _lifeService.TimeToNewLifeChanged += UpdateTimer;
        _lifeService.LivesFull += OnLivesFull;
    }


    private void UpdateTimer(int remainingTimeToNewLife)
    {
        if(!_remainingTime.gameObject.activeSelf)
            _remainingTime.gameObject.SetActive(true);
        _remainingTime.text = _timeConverter.SecondToMMSS(remainingTimeToNewLife);
    }

    private void UpdateLifeCount(int count) =>
        _lifeCount.text = count.ToString();

    private void OnLivesFull()
    {
        if (_hideTimerWhenFull)
            _remainingTime.gameObject.SetActive(false);
        else
            _remainingTime.text = FullText;
    }

    private void OnDestroy()
    {
        _lifeService.LifeCountChanged -= UpdateLifeCount;
        _lifeService.TimeToNewLifeChanged -= UpdateTimer;
        _lifeService.LivesFull -= OnLivesFull;
    }
}
