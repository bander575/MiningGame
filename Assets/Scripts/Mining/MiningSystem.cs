using UnityEngine;

/// <summary>
/// نظام الحفر والتنقيب
/// </summary>
public class MiningSystem : MonoBehaviour
{
    [SerializeField] private float miningSpeed = 1f;
    [SerializeField] private int resourcesPerHit = 1;
    private float miningTimer = 0f;
    private bool isCurrentlyMining = false;

    private ResourceManager resourceManager;

    private void Start()
    {
        resourceManager = ResourceManager.Instance;
    }

    private void Update()
    {
        if (isCurrentlyMining)
        {
            miningTimer += Time.deltaTime;

            if (miningTimer >= miningSpeed)
            {
                Mine();
                miningTimer = 0f;
            }
        }
    }

    /// <summary>
    /// بدء الحفر
    /// </summary>
    public void StartMining()
    {
        isCurrentlyMining = true;
        Debug.Log("بدأ التنقيب!");
    }

    /// <summary>
    /// إيقاف الحفر
    /// </summary>
    public void StopMining()
    {
        isCurrentlyMining = false;
        Debug.Log("توقف التنقيب!");
    }

    /// <summary>
    /// الحفر الفعلي
    /// </summary>
    private void Mine()
    {
        // اختيار مورد عشوائي
        string[] resources = { "Gold", "Silver", "Diamond", "Iron" };
        string randomResource = resources[Random.Range(0, resources.Length)];

        // احتمالية الحصول على موارد نادرة (الماس)
        if (Random.value > 0.95f)
        {
            resourceManager.AddResource("Diamond", resourcesPerHit);
            Debug.Log("🎉 لقد حصلت على ماسة!");
        }
        else if (Random.value > 0.7f)
        {
            resourceManager.AddResource("Gold", resourcesPerHit);
            Debug.Log("✨ لقد حصلت على ذهب!");
        }
        else if (Random.value > 0.5f)
        {
            resourceManager.AddResource("Silver", resourcesPerHit);
            Debug.Log("⭐ لقد حصلت على فضة!");
        }
        else
        {
            resourceManager.AddResource("Iron", resourcesPerHit);
            Debug.Log("🔨 لقد حصلت على حديد!");
        }
    }

    /// <summary>
    /// تعديل سرعة الحفر
    /// </summary>
    public void SetMiningSpeed(float newSpeed)
    {
        miningSpeed = newSpeed;
        Debug.Log($"تم تعديل سرعة الحفر إلى: {newSpeed}");
    }

    /// <summary>
    /// تعديل كمية الموارد المحصول عليها
    /// </summary>
    public void SetResourcesPerHit(int newAmount)
    {
        resourcesPerHit = newAmount;
        Debug.Log($"تم تعديل الموارد المحصول عليها إلى: {newAmount}");
    }

    /// <summary>
    /// التحقق من حالة التنقيب
    /// </summary>
    public bool IsMining()
    {
        return isCurrentlyMining;
    }
}
