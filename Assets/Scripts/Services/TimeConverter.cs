
using System;

public class TimeConverter: ITimeConverter
{
    private const string MMSSFormat = @"mm\:ss";

    public string SecondToMMSS(int seconds) {
        TimeSpan time = TimeSpan.FromSeconds(seconds);
        return time.ToString(MMSSFormat);
    } 
}