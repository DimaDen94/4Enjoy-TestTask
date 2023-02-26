using UnityEngine;

public interface IUIFactory
{
    GameObject CreateHud();
    PopUpContainer CreatePopUpContainer();
    PopUpView CreatePopUp(PopUpType type, Transform container);
}