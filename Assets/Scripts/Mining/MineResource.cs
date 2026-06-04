using UnityEngine;

/// <summary>
/// نظام الموارد المعدنية
/// </summary>
public class MineResource : MonoBehaviour
{
    [SerializeField] private string resourceName;
    [SerializeField] private int resourceValue;
    [SerializeField] private float rarity = 0.5f;

    /// <summary>
    /// الحصول على اسم المورد
    /// </summary>
    public string GetResourceName()
    {
        return resourceName;
    }

    /// <summary>
    /// الحصول على قيمة المورد
    /// </summary>
    public int GetResourceValue()
    {
        return resourceValue;
    }

    /// <summary>
    /// الحصول على ندرة المورد
    /// </summary>
    public float GetRarity()
    {
        return rarity;
    }
}
