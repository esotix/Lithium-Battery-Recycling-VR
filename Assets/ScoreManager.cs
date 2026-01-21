using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int GeneralScore = 0;

    public void Scored(){
        GeneralScore += 1;
    }
}
