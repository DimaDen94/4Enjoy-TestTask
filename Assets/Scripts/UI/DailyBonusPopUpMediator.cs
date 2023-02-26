using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonusPopUpMediator : MonoBehaviour
{
    [SerializeField] private Button _close;
    [SerializeField] private Button _claim;
    [SerializeField] private TextMeshProUGUI _bonusCount;

    private IPopUpNavigator _popUpNavigator;

    public void Construct(IPopUpNavigator popUpNavigator, IDailyBonusService dailyBonusService)
    {
        _popUpNavigator = popUpNavigator;
        _close.onClick.AddListener(ClosePopUp);
        _claim.onClick.AddListener(ClosePopUp);
        _bonusCount.text = dailyBonusService.GetDailyBonus().ToString();
    }

    private void ClosePopUp() =>
        _popUpNavigator.ClosePopUp();
}
