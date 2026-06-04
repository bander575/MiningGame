using UnityEngine;

/// <summary>
/// نظام حفظ واستعادة اللعبة
/// </summary>
public class SaveSystem : MonoBehaviour
{
    private const string SAVE_KEY_MONEY = "PlayerMoney";
    private const string SAVE_KEY_DEPTH = "PlayerDepth";
    private const string SAVE_KEY_TIME = "GameTime";
    private const string SAVE_KEY_GOLD = "Gold";
    private const string SAVE_KEY_SILVER = "Silver";
    private const string SAVE_KEY_DIAMOND = "Diamond";
    private const string SAVE_KEY_IRON = "Iron";

    private ResourceManager resourceManager;
    private GameManager gameManager;

    private void Start()
    {
        resourceManager = ResourceManager.Instance;
        gameManager = GameManager.Instance;
    }

    /// <summary>
    /// حفظ حالة اللعبة
    /// </summary>
    public void SaveGame()
    {
        // حفظ الأموال والموارد
        PlayerPrefs.SetFloat(SAVE_KEY_MONEY, resourceManager.GetTotalMoney());
        PlayerPrefs.SetInt(SAVE_KEY_GOLD, resourceManager.GetResourceAmount("Gold"));
        PlayerPrefs.SetInt(SAVE_KEY_SILVER, resourceManager.GetResourceAmount("Silver"));
        PlayerPrefs.SetInt(SAVE_KEY_DIAMOND, resourceManager.GetResourceAmount("Diamond"));
        PlayerPrefs.SetInt(SAVE_KEY_IRON, resourceManager.GetResourceAmount("Iron"));

        // حفظ معلومات اللعبة
        PlayerPrefs.SetInt(SAVE_KEY_DEPTH, gameManager.GetCurrentDepth());
        PlayerPrefs.SetFloat(SAVE_KEY_TIME, gameManager.GetGameTime());

        PlayerPrefs.Save();
        Debug.Log("✅ تم حفظ اللعبة بنجاح!");
    }

    /// <summary>
    /// استعادة حالة اللعبة
    /// </summary>
    public void LoadGame()
    {
        if (HasSavedGame())
        {
            // استعادة الأموال والموارد
            float savedMoney = PlayerPrefs.GetFloat(SAVE_KEY_MONEY, 0f);
            int savedGold = PlayerPrefs.GetInt(SAVE_KEY_GOLD, 0);
            int savedSilver = PlayerPrefs.GetInt(SAVE_KEY_SILVER, 0);
            int savedDiamond = PlayerPrefs.GetInt(SAVE_KEY_DIAMOND, 0);
            int savedIron = PlayerPrefs.GetInt(SAVE_KEY_IRON, 0);

            // استعادة معلومات اللعبة
            int savedDepth = PlayerPrefs.GetInt(SAVE_KEY_DEPTH, 0);

            resourceManager.AddMoney(savedMoney);
            resourceManager.AddResource("Gold", savedGold);
            resourceManager.AddResource("Silver", savedSilver);
            resourceManager.AddResource("Diamond", savedDiamond);
            resourceManager.AddResource("Iron", savedIron);
            gameManager.SetDepth(savedDepth);

            Debug.Log("✅ تم استعادة اللعبة بنجاح!");
        }
        else
        {
            Debug.Log("⚠️ لا توجد لعبة محفوظة!");
        }
    }

    /// <summary>
    /// التحقق من وجود لعبة محفوظة
    /// </summary>
    public bool HasSavedGame()
    {
        return PlayerPrefs.HasKey(SAVE_KEY_MONEY);
    }

    /// <summary>
    /// حذف اللعبة المحفوظة
    /// </summary>
    public void DeleteSavedGame()
    {
        PlayerPrefs.DeleteKey(SAVE_KEY_MONEY);
        PlayerPrefs.DeleteKey(SAVE_KEY_DEPTH);
        PlayerPrefs.DeleteKey(SAVE_KEY_TIME);
        PlayerPrefs.DeleteKey(SAVE_KEY_GOLD);
        PlayerPrefs.DeleteKey(SAVE_KEY_SILVER);
        PlayerPrefs.DeleteKey(SAVE_KEY_DIAMOND);
        PlayerPrefs.DeleteKey(SAVE_KEY_IRON);

        PlayerPrefs.Save();
        Debug.Log("✅ تم حذف اللعبة المحفوظة!");
    }
}
