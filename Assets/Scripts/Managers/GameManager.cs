using UnityEngine;

/// <summary>
/// إدارة اللعبة الرئيسية
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int currentDepth = 0;
    [SerializeField] private int maxDepth = 100;
    private float gameTime = 0f;
    private bool isPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("لعبة التنقيب قد بدأت!");
    }

    private void Update()
    {
        if (!isPaused)
        {
            gameTime += Time.deltaTime;
        }
    }

    /// <summary>
    /// الحصول على العمق الحالي
    /// </summary>
    public int GetCurrentDepth()
    {
        return currentDepth;
    }

    /// <summary>
    /// تغيير العمق
    /// </summary>
    public void SetDepth(int newDepth)
    {
        currentDepth = Mathf.Clamp(newDepth, 0, maxDepth);
        Debug.Log($"العمق الحالي: {currentDepth} / {maxDepth}");
    }

    /// <summary>
    /// الحصول على الحد الأقصى للعمق
    /// </summary>
    public int GetMaxDepth()
    {
        return maxDepth;
    }

    /// <summary>
    /// إيقاف / استئناف اللعبة
    /// </summary>
    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        Debug.Log(isPaused ? "تم إيقاف اللعبة" : "تم استئناف اللعبة");
    }

    /// <summary>
    /// الحصول على وقت اللعبة
    /// </summary>
    public float GetGameTime()
    {
        return gameTime;
    }
}
