using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// إدارة الموارد والأموال في اللعبة
/// </summary>
public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    [System.Serializable]
    public class Resource
    {
        public string resourceName;
        public int amount;
        public float sellPrice;
    }

    private Dictionary<string, Resource> resources = new Dictionary<string, Resource>();
    private float totalMoney = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeResources();
    }

    /// <summary>
    /// تهيئة الموارد الأساسية
    /// </summary>
    private void InitializeResources()
    {
        resources["Gold"] = new Resource { resourceName = "Gold", amount = 0, sellPrice = 100f };
        resources["Silver"] = new Resource { resourceName = "Silver", amount = 0, sellPrice = 50f };
        resources["Diamond"] = new Resource { resourceName = "Diamond", amount = 0, sellPrice = 500f };
        resources["Iron"] = new Resource { resourceName = "Iron", amount = 0, sellPrice = 25f };
    }

    /// <summary>
    /// إضافة مورد
    /// </summary>
    public void AddResource(string resourceName, int amount)
    {
        if (resources.ContainsKey(resourceName))
        {
            resources[resourceName].amount += amount;
            Debug.Log($"تم إضافة {amount} {resourceName}");
        }
    }

    /// <summary>
    /// الحصول على كمية مورد معين
    /// </summary>
    public int GetResourceAmount(string resourceName)
    {
        if (resources.ContainsKey(resourceName))
        {
            return resources[resourceName].amount;
        }
        return 0;
    }

    /// <summary>
    /// بيع مورد معين
    /// </summary>
    public void SellResource(string resourceName, int amount)
    {
        if (resources.ContainsKey(resourceName))
        {
            if (resources[resourceName].amount >= amount)
            {
                float moneyGained = amount * resources[resourceName].sellPrice;
                resources[resourceName].amount -= amount;
                totalMoney += moneyGained;
                Debug.Log($"تم بيع {amount} {resourceName} بمبلغ {moneyGained}");
            }
        }
    }

    /// <summary>
    /// الحصول على إجمالي الأموال
    /// </summary>
    public float GetTotalMoney()
    {
        return totalMoney;
    }

    /// <summary>
    /// استخدام الأموال (للشراء من المتجر)
    /// </summary>
    public bool SpendMoney(float amount)
    {
        if (totalMoney >= amount)
        {
            totalMoney -= amount;
            return true;
        }
        return false;
    }

    /// <summary>
    /// إضافة أموال (للمكافآت والبيع)
    /// </summary>
    public void AddMoney(float amount)
    {
        totalMoney += amount;
    }
}
