using UnityEngine;

/// <summary>
/// نظام المتجر والترقيات
/// </summary>
public class Shop : MonoBehaviour
{
    [System.Serializable]
    public class ToolUpgrade
    {
        public string upgradeName;
        public float cost;
        public string description;
        public int level = 0;
    }

    private ToolUpgrade[] upgrades = new ToolUpgrade[]
    {
        new ToolUpgrade { upgradeName = "سرعة الحفر", cost = 100f, description = "زيادة سرعة الحفر بمقدار 20%" },
        new ToolUpgrade { upgradeName = "كمية الموارد", cost = 150f, description = "زيادة الموارد المحصول عليها بمقدار 1" },
        new ToolUpgrade { upgradeName = "العمق الأقصى", cost = 500f, description = "زيادة العمق الأقصى بمقدار 50" },
        new ToolUpgrade { upgradeName = "احتمالية الموارد النادرة", cost = 250f, description = "زيادة احتمالية الحصول على الماس" }
    };

    private ResourceManager resourceManager;

    private void Start()
    {
        resourceManager = ResourceManager.Instance;
    }

    /// <summary>
    /// عرض المتجر
    /// </summary>
    public void DisplayShop()
    {
        Debug.Log("========== المتجر ==========");
        Debug.Log($"أموالك الحالية: {resourceManager.GetTotalMoney()}");
        Debug.Log("الترقيات المتاحة:");
        
        for (int i = 0; i < upgrades.Length; i++)
        {
            Debug.Log($"{i + 1}. {upgrades[i].upgradeName} - السعر: {upgrades[i].cost} (المستوى: {upgrades[i].level})");
            Debug.Log($"   الوصف: {upgrades[i].description}");
        }
        Debug.Log("===========================");
    }

    /// <summary>
    /// شراء ترقية
    /// </summary>
    public bool BuyUpgrade(int upgradeIndex)
    {
        if (upgradeIndex < 0 || upgradeIndex >= upgrades.Length)
        {
            Debug.Log("الترقية المختارة غير موجودة!");
            return false;
        }

        if (resourceManager.SpendMoney(upgrades[upgradeIndex].cost))
        {
            upgrades[upgradeIndex].level++;
            Debug.Log($"تم شراء: {upgrades[upgradeIndex].upgradeName}");
            Debug.Log($"المستوى الحالي: {upgrades[upgradeIndex].level}");
            return true;
        }
        else
        {
            Debug.Log("ليس لديك أموال كافية!");
            return false;
        }
    }

    /// <summary>
    /// الحصول على مستوى ترقية معينة
    /// </summary>
    public int GetUpgradeLevel(int upgradeIndex)
    {
        if (upgradeIndex >= 0 && upgradeIndex < upgrades.Length)
        {
            return upgrades[upgradeIndex].level;
        }
        return 0;
    }

    /// <summary>
    /// الحصول على كل الترقيات
    /// </summary>
    public ToolUpgrade[] GetAllUpgrades()
    {
        return upgrades;
    }
}
