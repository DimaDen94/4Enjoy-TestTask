using UnityEngine;

public class UIFactory : IUIFactory
{
    private IAssetProvider _assetProvider;


    public UIFactory(IAssetProvider assetProvider) {
        _assetProvider = assetProvider;
    }
    public GameObject CreateHud() {
        return _assetProvider.Instantiate(AssetPath.HudPath);
    }

    public PopUpView CreatePopUp(PopUpType type, Transform container)
    {
        return _assetProvider.Instantiate(AssetPath.PopUpPaths[type], container).GetComponent<PopUpView>();
    }

    public PopUpContainer CreatePopUpContainer()
    {
        return _assetProvider.Instantiate(AssetPath.PopUpContainerPath).GetComponent<PopUpContainer>();
    }
}
