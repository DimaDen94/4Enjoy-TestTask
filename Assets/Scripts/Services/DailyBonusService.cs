using System;
using UnityEngine;

public class DailyBonusService : IDailyBonusService
{
    public long GetDailyBonus()
    {
        DateTime currentDate = DateTime.Now;

        DateTime seasonStart = GetStartSeason(currentDate);
        int firstDayBonus = GetFirstDayBonus(currentDate);

        int daysSinceSeasonStart = (currentDate - seasonStart).Days + 1;
        Debug.Log(firstDayBonus.ToString());
        return CalculateBonus(firstDayBonus, daysSinceSeasonStart);
    }

    private DateTime GetStartSeason(DateTime currentDate)
    {
        DateTime seasonStart;

        switch (currentDate.Month)
        {
            case 1:
            case 2:
                seasonStart = new DateTime(currentDate.Year - 1, 12, 1);
                break;
            case 12:
                seasonStart = new DateTime(currentDate.Year, 12, 1);
                break;
            case 3:
            case 4:
            case 5:
                seasonStart = new DateTime(currentDate.Year, 3, 1);
                break;
            case 6:
            case 7:
            case 8:
                seasonStart = new DateTime(currentDate.Year, 6, 1);
                break;
            case 9:
            case 10:
            case 11:
                seasonStart = new DateTime(currentDate.Year, 9, 1);
                break;
            default:
                seasonStart = new DateTime(currentDate.Year, 9, 1);
                break;

        }
        return seasonStart;

    }

    private int GetFirstDayBonus(DateTime currentDate)
    {
        int firstDayBonus;
        switch (currentDate.Month)
        {
            case 1:
            case 2:
            case 12:
                firstDayBonus = GameConfig.WinterFirstDayBonus;
                break;
            case 3:
            case 4:
            case 5:
                firstDayBonus = GameConfig.SpringFirstDayBonus;
                break;
            case 6:
            case 7:
            case 8:
                firstDayBonus = GameConfig.SummerFirstDayBonus;
                break;
            case 9:
            case 10:
            case 11:
                firstDayBonus = GameConfig.AutumnFirstDayBonus;
                break;
            default:
                firstDayBonus = GameConfig.AutumnFirstDayBonus;
                break;

        }
        return firstDayBonus;

    }

    private long CalculateBonus(int firstDayBonus,int dayOfYear)
    {
        long bonus = 0;

        switch (dayOfYear)
        {
            case 1:
                return firstDayBonus;
            case 2:
                return firstDayBonus + 1;
            default:
                long twoDaysAgoBonus = firstDayBonus;
                long previousDayBonus = firstDayBonus + 1;

                for (int i = 3; i <= dayOfYear; i++)
                {
                    bonus = (long)Math.Round(previousDayBonus * 0.6f + twoDaysAgoBonus);
                    twoDaysAgoBonus = previousDayBonus;
                    previousDayBonus = bonus;
                }
                return bonus;
        }
    }

    private int CalculateBonusRecursively(int dayOfYear)
    {
        switch (dayOfYear)
        {
            case 1:
                return 2;
            case 2:
                return 3;
            default:
                int previousDayBonus = CalculateBonusRecursively(dayOfYear - 1);
                int twoDaysAgoBonus = CalculateBonusRecursively(dayOfYear - 2);
                return (int)Math.Round(previousDayBonus * 0.6f + twoDaysAgoBonus);
        }
    }
}

