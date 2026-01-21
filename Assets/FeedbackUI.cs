using UnityEngine;
using TMPro;

public class FeedbackUI : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;
    public GameObject feedbackPrefab;   // le prefab de la fenêtre

    [Header("Display Settings")]
    public float distanceFromCamera = 1.5f;

    private GameObject currentFeedback;

    // -----------------------------
    // Fonction principale à appeler
    // -----------------------------
    public void ShowFeedback(string message)
    {
        // Si un feedback est déjà affiché → on ne recrée pas
        if (currentFeedback != null)
            return;

        // Instancie la fenêtre
        currentFeedback = Instantiate(feedbackPrefab);

        // Position devant la caméra
        Transform cam = playerCamera.transform;
        currentFeedback.transform.position = cam.position + cam.forward * distanceFromCamera;
        currentFeedback.transform.rotation = Quaternion.LookRotation(cam.forward);

        // Met le texte
        TextMeshProUGUI txt = currentFeedback.GetComponentInChildren<TextMeshProUGUI>();
        txt.text = message;

        // Récupère le bouton pour fermer
        FeedbackWindow window = currentFeedback.GetComponent<FeedbackWindow>();
        window.manager = this;
    }

    // Appelée quand on ferme la fenêtre
    public void CloseFeedback()
    {
        if (currentFeedback != null)
        {
            Destroy(currentFeedback);
            currentFeedback = null;
        }
    }
}
