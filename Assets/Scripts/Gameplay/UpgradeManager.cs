using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public GameObject bulletSpreadPanel;
    public GameObject bulletStatsPanel;

    private int currentUpgradeType = 0; // 0: No upgrade, 1: Bullet Spread, 2: Bullet Stats

    public void ToggleUpgradePanel()
    {
        // Disable both panels initially
        bulletSpreadPanel.SetActive(false);
        bulletStatsPanel.SetActive(false);

        // Show type 1 on the first call, then alternate between type 2
        if (currentUpgradeType == 0)
        {
            bulletSpreadPanel.SetActive(true);
            currentUpgradeType = 1;
        }
        else
        {
            currentUpgradeType = 2;
            bulletStatsPanel.SetActive(true);
        }
    }
}
