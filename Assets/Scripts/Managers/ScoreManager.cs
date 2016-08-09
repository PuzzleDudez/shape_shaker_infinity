using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
    private static ScoreManager instance;

    #region INSTANCE (SINGLETON)

    /// <summary>
    /// Singleton
    /// </summary>
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<ScoreManager>();
            }

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Text ScoreText;
    public int CurrentScore;

    void Start()
    {
        CurrentScore = 0;
        ScoreText = GetComponent<Text>();
        ScoreText.text = "Score: " + 0;
    }

    public void AddScore(int score)
    {
        CurrentScore += score;

        ScoreText.text = "Score: " + CurrentScore.ToString();
    }
}
