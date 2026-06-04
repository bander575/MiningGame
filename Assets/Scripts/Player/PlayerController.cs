using UnityEngine;

/// <summary>
/// التحكم بلاعب اللعبة
/// </summary>
public class PlayerController : MonoBehaviour
{
    private MiningSystem miningSystem;
    private ResourceManager resourceManager;
    private Shop shop;

    private void Start()
    {
        miningSystem = GetComponent<MiningSystem>();
        resourceManager = ResourceManager.Instance;
        shop = GetComponent<Shop>();
    }

    private void Update()
    {
        HandleInput();
    }

    /// <summary>
    /// التعامل مع مدخلات اللاعب
    /// </summary>
    private void HandleInput()
    {
        // الضغط على M للبدء بالحفر
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!miningSystem.IsMining())
            {
                miningSystem.StartMining();
            }
            else
            {
                miningSystem.StopMining();
            }
        }

        // الضغط على S لعرض الحالة
        if (Input.GetKeyDown(KeyCode.S))
        {
            DisplayGameStatus();
        }

        // الضغط على H لعرض المتجر
        if (Input.GetKeyDown(KeyCode.H))
        {
            shop.DisplayShop();
        }

        // الضغط على B لبيع جميع الموارد
        if (Input.GetKeyDown(KeyCode.B))
        {
            SellAllResources();
        }

        // الضغط على 1-4 لشراء ترقيات
        if (Input.GetKeyDown(KeyCode.Alpha1))
            shop.BuyUpgrade(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            shop.BuyUpgrade(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            shop.BuyUpgrade(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            shop.BuyUpgrade(3);
    }

    /// <summary>
    /// عرض حالة اللعبة الحالية
    /// </summary>
    private void DisplayGameStatus()
    {
        Debug.Log("========== حالة اللعبة ==========");
        Debug.Log($"الأموال: {resourceManager.GetTotalMoney()}");
        Debug.Log($"الذهب: {resourceManager.GetResourceAmount("Gold")}");
        Debug.Log($"الفضة: {resourceManager.GetResourceAmount("Silver")}");
        Debug.Log($"الماس: {resourceManager.GetResourceAmount("Diamond")}");
        Debug.Log($"الحديد: {resourceManager.GetResourceAmount("Iron")}");
        Debug.Log($"العمق: {GameManager.Instance.GetCurrentDepth()} / {GameManager.Instance.GetMaxDepth()}");
        Debug.Log($"الوقت المنقضي: {GameManager.Instance.GetGameTime():F2}");
        Debug.Log("================================");
    }

    /// <summary>
    /// بيع جميع الموارد
    /// </summary>
    private void SellAllResources()
    {
        int goldAmount = resourceManager.GetResourceAmount("Gold");
        int silverAmount = resourceManager.GetResourceAmount("Silver");
        int diamondAmount = resourceManager.GetResourceAmount("Diamond");
        int ironAmount = resourceManager.GetResourceAmount("Iron");

        resourceManager.SellResource("Gold", goldAmount);
        resourceManager.SellResource("Silver", silverAmount);
        resourceManager.SellResource("Diamond", diamondAmount);
        resourceManager.SellResource("Iron", ironAmount);

        Debug.Log("تم بيع جميع الموارد!");
        DisplayGameStatus();
    }
}
