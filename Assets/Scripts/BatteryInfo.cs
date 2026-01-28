using TMPro;
using UnityEngine;

public class BatteryInfo : MonoBehaviour
{
    public string BatteryTypeText;
    public string BatteryStateText;
    public string CaracteristicsText;

    private BatteryInfoManager batteryInfoManager;

    private void Awake()
    {
        batteryInfoManager = FindFirstObjectByType<BatteryInfoManager>();
    }
    public void OnGrab()
    {
        batteryInfoManager.ShowBatteryInfo(BatteryTypeText, BatteryStateText, CaracteristicsText);
    }

    public void OnRelease()
    {
        batteryInfoManager.HideBatteryInfo();
    }
}
