using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System.Collections;


public class ManageConvoyer : MonoBehaviour
{


    public List<GameObject> ConvoyerPrefabs;
    bool convoyerMoved;
    int oldButton;
    [SerializeField] float moveDuration = 0.6f;
    Coroutine moveRoutine;

    public Vector3 initialPlaceConvoyer;
    public Vector3 Descente = new Vector3(0, -1, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator MoveSmooth(Transform obj, Vector3 target, float duration)
    {
        Vector3 start = obj.position;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            float eased = Mathf.SmoothStep(0f, 1f, t);  // easing sympa
            obj.position = Vector3.Lerp(start, target, eased);
            yield return null;
        }

        obj.position = target;
    }

    public void resetConvoyer()
    {
        moveRoutine = StartCoroutine(MoveSmooth(ConvoyerPrefabs[oldButton].transform, initialPlaceConvoyer, moveDuration));

    }
    public void MoveConvoyer(int Button)
    {
        if (moveRoutine != null) StopCoroutine(moveRoutine);

        if (convoyerMoved)
            resetConvoyer();

        oldButton = Button;
        initialPlaceConvoyer = ConvoyerPrefabs[Button].transform.position;

        Vector3 targetPos = transform.position + Descente;

        moveRoutine = StartCoroutine(MoveSmooth(ConvoyerPrefabs[Button].transform, targetPos, moveDuration));

        convoyerMoved = true;
    }


    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.digit1Key.wasPressedThisFrame) MoveConvoyer(0);
        if (kb.digit2Key.wasPressedThisFrame) MoveConvoyer(1);
        if (kb.digit3Key.wasPressedThisFrame) MoveConvoyer(2);
    }



}
