using UnityEngine;
using UnityEngine.UI;

public class PopUpContainer : MonoBehaviour
{
    private const string CloseAnimationKey = "Close";

    [SerializeField] private Canvas _mainCanvas;
    [SerializeField] private Transform _container;
    [SerializeField] private Animator _backgroundAnimator;
    [SerializeField] private Button _closeArea;

    public Transform Container => _container;

    public void Construct(Camera camera, IPopUpNavigator popUpNavigator)
    {
        _mainCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        _mainCanvas.worldCamera = camera;
        _closeArea.onClick.AddListener(() => popUpNavigator.ClosePopUp());
    }

    public void Close()
    {
        _backgroundAnimator.Play(CloseAnimationKey);
    }

    public void DestroyContainer()
    {
        Destroy(gameObject);
    }
}