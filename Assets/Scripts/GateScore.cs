using System.Collections;
using UnityEngine;

public class GateScore : MonoBehaviour
{
    public Material mat_True;
    public Material mat_False;
    public Material mat_Origin;

    public string Tag;

    
    public bool triggered = false;
    public ScoreManager AddingScore;
    public FeedbackManager FeedbackAppel;
    public ObjectPool objectPool;
    int feedBackNumber;
    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
        if (other.CompareTag(Tag))
        {
            AddingScore.Scored();
            FeedbackAppel.displayFeedBack(4);
            StartCoroutine(ChangeMaterial(mat_True));
        }
        else if (other.CompareTag("Broken") || other.CompareTag("Recyclable") || other.CompareTag("Reusable"))
        {
            if (Tag == "Reusable")
            {
                feedBackNumber = 1;
                AddingScore.Scored(-1);
            }
            else if (Tag == "Broken")
            {
                feedBackNumber = 2;
                AddingScore.Scored(-2);
                
            }
            else if (Tag == "Recyclable") 
            { 
                feedBackNumber = 3;
                AddingScore.Scored(-1);
            }
            FeedbackAppel.displayFeedBack(feedBackNumber);
            StartCoroutine(ChangeMaterial(mat_False));
            if (GameManager.Instance != null && other.CompareTag("Broken"))
            {
                GameManager.Instance.LaunchExplosion(other.transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Broken") || other.CompareTag("Recyclable") || other.CompareTag("Reusable"))
        {
            objectPool.ReturnToPool(other.gameObject);
        }
    }

    IEnumerator ChangeMaterial(Material mat)
    {
        // Apply result material
        SetMaterialOnChildren(mat);
        

        // Wait 2 seconds
        yield return new WaitForSecondsRealtime(2);

        // Restore origin material
        SetMaterialOnChildren(mat_Origin);
    }

    private void SetMaterialOnChildren(Material mat)
    {
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer r in renderers)
        {
            r.material = mat;
        }
    }
}
