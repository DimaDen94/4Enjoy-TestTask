using UnityEngine;

public class PopUpNavigator : IPopUpNavigator
{
    private Camera _camera;
    private PopUpContainer _popUpContainer;
    private PopUpView _currentPopUp;

    private IUIFactory _uiFactory;

    public PopUpNavigator(IUIFactory uiFactory)
    {
        _camera = Camera.main;
        _uiFactory = uiFactory;
    }

    public PopUpView OpenPopUp(PopUpType type)
    {
        CreatePopUpContainer();
        _currentPopUp = _uiFactory.CreatePopUp(type, _popUpContainer.Container);
        return _currentPopUp;
    }

    public void ClosePopUp()
    {
        _popUpContainer.Close();
        _popUpContainer = null;
        _currentPopUp.PlayCloseAnimation();
        _currentPopUp = null;
    }

    private void CreatePopUpContainer()
    {
        if (_popUpContainer == null)
        {
            _popUpContainer = _uiFactory.CreatePopUpContainer();
            _popUpContainer.Construct(_camera, this);
        }
    }
}
