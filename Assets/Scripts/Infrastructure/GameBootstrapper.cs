using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
    private IUIFactory _uiFactory;
    private ILifeService _lifeService;
    private ITimeConverter _timeConverter;
    private IPopUpNavigator _popUpNavigator;
    private IGameTimer _gameTimer;
    private IDailyBonusService _dailyBonusService;

    [Inject]
    private void Construct(IUIFactory uiFactory, ILifeService lifeService, ITimeConverter timeConverter, IPopUpNavigator popUpNavigator, IGameTimer gameTimer, IDailyBonusService dailyBonusService )
    {
        _uiFactory = uiFactory;
        _lifeService = lifeService;
        _timeConverter = timeConverter;
        _popUpNavigator = popUpNavigator;
        _gameTimer = gameTimer;
        _dailyBonusService = dailyBonusService;
    }

    private void Start()
    {
        _gameTimer.Start();
        GameObject hud = _uiFactory.CreateHud();
        hud.GetComponent<HudMediator>().Construct(_lifeService, _timeConverter,_popUpNavigator, Camera.main);
        PopUpView dailyBonusPopUp = _popUpNavigator.OpenPopUp(PopUpType.DailyBonus);
        dailyBonusPopUp.GetComponent<DailyBonusPopUpMediator>().Construct(_popUpNavigator,_dailyBonusService);

    }
}
