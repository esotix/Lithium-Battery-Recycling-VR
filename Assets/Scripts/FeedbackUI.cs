using UnityEngine;
using TMPro;

public class FeedbackUI : MonoBehaviour
{
    [Header("References")]
    public GameObject feedbackPrefab;
    public TextMeshProUGUI textFeedback;
    public TextMeshProUGUI score;

    private ScoreManager scoreManager;


    private void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    public void ShowFeedback(string message)
    {
        feedbackPrefab.SetActive(true);
        textFeedback.text = message;
        score.text = "score : " + scoreManager.GeneralScore;
    }
}
