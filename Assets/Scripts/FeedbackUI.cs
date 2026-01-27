using UnityEngine;
using TMPro;

public class FeedbackUI : MonoBehaviour
{
    [Header("References")]
    public GameObject feedbackPrefab;
    public TextMeshProUGUI textFeedback;
    public TextMeshProUGUI score;
    public bool PlayMODE = false;

    private ScoreManager scoreManager;


    private void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    public void ShowFeedback(string message)
    {
        if (PlayMODE) return;
        feedbackPrefab.SetActive(true);
        textFeedback.text = message;
        score.text = "score : " + scoreManager.GeneralScore;
    }
}
