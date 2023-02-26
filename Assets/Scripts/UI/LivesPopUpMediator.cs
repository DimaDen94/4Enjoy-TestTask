using System;
using UnityEngine;
using UnityEngine.UI;

public class LivesPopUpMediator : MonoBehaviour
{
    [SerializeField] private Button _useLifeButton;
    [SerializeField] private Button _refillLivesButton;
    [SerializeField] private Button _close;
    [SerializeField] private LivesWidget _livesWidget;
    private ILifeService _lifeService;
    private IPopUpNavigator _popUpNavigator;

    public void Construct(ILifeService lifeService, ITimeConverter timeConverter, IPopUpNavigator popUpNavigator) {
        _lifeService = lifeService;
        _popUpNavigator = popUpNavigator;
        _livesWidget.Construct(_lifeService, timeConverter);

        _useLifeButton.onClick.AddListener(UseLife);
        _refillLivesButton.onClick.AddListener(RefillLives);

        _lifeService.LifeCountChanged += OnLifeCountChanged;
        _lifeService.LivesFull += HideRefillLivesButton;

        _close.onClick.AddListener(ClosePopUp);
    }


    private void RefillLives() => _lifeService.RefillLives();

    private void UseLife()
    {
        _lifeService.UseLife();
    }

    private void OnLifeCountChanged(int count)
    {
        if (count <= 0)
            HideUseLifeButton();
        else
            ShowUseLifeButton();
        if (count < GameConfig.MaxLives)
            ShowRefillLivesButton();
    }

    private void ShowRefillLivesButton()
    {
        if(!_refillLivesButton.gameObject.activeSelf)
            _refillLivesButton.gameObject.SetActive(true);
    }

    private void HideRefillLivesButton() =>
        _refillLivesButton.gameObject.SetActive(false);


    private void HideUseLifeButton() =>
        _useLifeButton.gameObject.SetActive(false);

    private void ShowUseLifeButton()
    {
        if(!_useLifeButton.gameObject.activeSelf)
            _useLifeButton.gameObject.SetActive(true);
    }

    private void ClosePopUp() => _popUpNavigator.ClosePopUp();

    private void OnDestroy()
    {
        _lifeService.LifeCountChanged -= OnLifeCountChanged;
        _lifeService.LivesFull -= HideRefillLivesButton;
    }
}
