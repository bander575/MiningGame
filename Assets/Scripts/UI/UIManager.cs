using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// إدارة واجهة المستخدم الرئيسية
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    [SerializeField] private Text resourceText;
    [SerializeField] private Text depthText;
    [SerializeField] private Text statusText;

    private ResourceManager resourceManager;
    private GameManager gameManager;

    private void Start()
    {
        resourceManager = ResourceManager.Instance;
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        UpdateUI();
    }

    /// <summary>
    /// تحديث الواجهة
    /// </summary>
    private void UpdateUI()
    {
        if (moneyText != null)
        {
            moneyText.text = $"الأموال: {resourceManager.GetTotalMoney():F0}";
        }

        if (resourceText != null)
        {
            string resources = $"الذهب: {resourceManager.GetResourceAmount("Gold")} | " +
                             $"الفضة: {resourceManager.GetResourceAmount("Silver")} | " +
                             $"الماس: {resourceManager.GetResourceAmount("Diamond")}";
            resourceText.text = resources;
        }

        if (depthText != null)
        {
            depthText.text = $"العمق: {gameManager.GetCurrentDepth()} / {gameManager.GetMaxDepth()}";
        }
    }

    /// <summary>
    /// عرض رسالة الحالة
    /// </summary>
    public void ShowStatus(string message)
    {
        if (statusText != null)
        {
            statusText.text = message;
        }
    }
}
