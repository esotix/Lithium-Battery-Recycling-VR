using UnityEngine;

public class FeedbackWindow : MonoBehaviour
{
    public FeedbackUI manager;

    // Bouton "Close" appelle cette fonction
    public void Close()
    {
        manager.CloseFeedback();
    }
}
