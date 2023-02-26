using System.Collections.Generic;

public class AssetPath
{
    public static readonly Dictionary<PopUpType, string> PopUpPaths = new Dictionary<PopUpType, string> {
        {
            PopUpType.Lives , "UI/LivesPopUp"
        },
        {
            PopUpType.DailyBonus , "UI/DailyBonusPopUp"
        },
    };
    public static readonly string HudPath = "UI/Hud Canvas";
    public static readonly string PopUpContainerPath = "UI/PopUpContainer";
}
