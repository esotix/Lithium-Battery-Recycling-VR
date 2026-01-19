using System.Collections;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{
    public float materialSpeed = 5f;
    public float batterySpeed = 2f;

    private float firstMoveDuration = 3;
    private GameObject battery;
    private Material conveyerBelt;

    private void Start()
    {
        conveyerBelt = GetComponent<Renderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter");
        if (collision.gameObject.CompareTag("Battery"))
        {
            battery = collision.gameObject;
            StartCoroutine(FirstMovingBelt());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit");
        if (collision.gameObject.CompareTag("Battery"))
        {
            battery = null;
        }
    }

    IEnumerator FirstMovingBelt()
    {
        float elapsedTime = 0f;
        while (elapsedTime < firstMoveDuration)
        {
            conveyerBelt.mainTextureOffset += new Vector2(0, materialSpeed * Time.deltaTime);
            battery.transform.Translate(Vector3.left * batterySpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator MovingBelt()
    {
        while (battery)
        {
            conveyerBelt.mainTextureOffset += new Vector2(0, materialSpeed * Time.deltaTime);
            battery.transform.Translate(Vector3.left * batterySpeed * Time.deltaTime);
            yield return null;
        }
    }
}
