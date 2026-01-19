using System.Collections;
using UnityEngine;

public class GateScore : MonoBehaviour
{
    public Material mat_True;
    public Material mat_False;
    public Material mat_Origin;

    public string Tag;

    public bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
        if (other.CompareTag(Tag))
        {
            StartCoroutine(ChangeMaterial(mat_True));
        }
        else
        {
            StartCoroutine(ChangeMaterial(mat_False));
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
