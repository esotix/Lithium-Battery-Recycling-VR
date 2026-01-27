using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    private float elapsedTime = 0f;
    private float EndTimer = 300f;
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
        StartCoroutine(DisplayTime());
    }

    public void DisplayScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator DisplayTime()
    {
        while(elapsedTime < EndTimer)
        {
            yield return new WaitForSeconds(1f);
            // Display Time from 5 min to 0 seconds
            elapsedTime += 1f;
            float timeLeft = EndTimer - elapsedTime;
            int minutes = Mathf.FloorToInt(timeLeft / 60f);
            int seconds = Mathf.FloorToInt(timeLeft % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
