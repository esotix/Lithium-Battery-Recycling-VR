using System.Collections;
using UnityEngine;

public class FirstConveyer : MonoBehaviour
{
    public float materialSpeed = 1f;
    public float batterySpeed = 2f;

    public bool batteryOnBelt = false;

    private float firstMoveDuration = 2;
    private GameObject battery;
    private Material conveyerBelt;
    private bool beltIsActive = true;

    private void Start()
    {
        conveyerBelt = GetComponent<Renderer>().material;
    }
    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "BatteryNikon" || tag == "BatteryCar" || tag == "BatteryVolt")
        {
            battery = collision.gameObject;
            batteryOnBelt = true;
            if (!beltIsActive) return;
            StartCoroutine(FirstMovingBelt());
            beltIsActive = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "BatteryNikon" || tag == "BatteryCar" || tag == "BatteryVolt")
        {
            battery = null;
            batteryOnBelt = false;
        }
    }

    public void MoveBelt()
    {
        if (batteryOnBelt)
        {
            StartCoroutine(MovingBelt());
            beltIsActive = true;
        }
    }

    IEnumerator FirstMovingBelt()
    {
        float elapsedTime = 0f;
        while (elapsedTime < firstMoveDuration)
        {
            conveyerBelt.mainTextureOffset += new Vector2(0, materialSpeed * Time.deltaTime);
            battery.transform.Translate(Vector3.left * batterySpeed * Time.deltaTime, Space.World);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator MovingBelt()
    {
        while (battery)
        {
            conveyerBelt.mainTextureOffset += new Vector2(0, materialSpeed * Time.deltaTime);
            battery.transform.Translate(Vector3.left * batterySpeed * Time.deltaTime, Space.World);
            yield return null;
        }
    }

}
