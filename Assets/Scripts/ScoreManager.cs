using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int GeneralScore = 0;

    public void Scored(int score = 1){
        GeneralScore += score;
        if (GeneralScore < 0) GeneralScore = 0;
        if (GameManager.Instance != null)
        {
            GameManager.Instance.DisplayScore(GeneralScore);
        }
    }
}
