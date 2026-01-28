using TMPro;
using UnityEngine;

public class BatteryInfoManager : MonoBehaviour
{
    public TextMeshProUGUI BatteryType;
    public TextMeshProUGUI BatteryState;
    public TextMeshProUGUI Caracteristics;
    public GameObject InfoPanel;
    public bool PLayMODE = false;
    private void Awake()
    {
        InfoPanel.SetActive(false);
    }

    public void ShowBatteryInfo(string batteryTypeText, string batteryStateText, string caracteristicsText)
    {
        if (PLayMODE) return;
        BatteryType.text = batteryTypeText;
        BatteryState.text = batteryStateText;
        Caracteristics.text = caracteristicsText;
        InfoPanel.SetActive(true);
    }
    public void HideBatteryInfo()
    {
        InfoPanel.SetActive(false);
    }
}
