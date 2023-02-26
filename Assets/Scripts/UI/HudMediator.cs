using UnityEngine;
using UnityEngine.UI;

public class HudMediator : MonoBehaviour
{
    [SerializeField] private Button _livesButton;
    [SerializeField] private Canvas _mainCanvas;
    [SerializeField] private LivesWidget _livesWidget;

    private ILifeService _lifeService;
    private ITimeConverter _timeConverter;
    private IPopUpNavigator _popUpNavigator;

    public void Construct(ILifeService lifeService, ITimeConverter timeConverter, IPopUpNavigator popUpNavigator, Camera camera)
    {
        _mainCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        _mainCanvas.worldCamera = camera;

        _lifeService = lifeService;
        _timeConverter = timeConverter;
        _popUpNavigator = popUpNavigator;
        _livesWidget.Construct(_lifeService, _timeConverter);
        _livesButton.onClick.AddListener(OpenLifePopUp);
    }

    private void OpenLifePopUp()
    {
        PopUpView popUp = _popUpNavigator.OpenPopUp(PopUpType.Lives);
        popUp.GetComponent<LivesPopUpMediator>().Construct(_lifeService, _timeConverter, _popUpNavigator);
    }
}
