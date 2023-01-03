namespace Promeetec.EDMS.Settings;

public class Options: IOptions
{
    public static Dictionary<int, string> PageSizes => new() { { 5, "5" }, { 10, "10" }, { 25, "25" }, { 50, "50" }, { 100, "100" }, { 250, "250" } };
}