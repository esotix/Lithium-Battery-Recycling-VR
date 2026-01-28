using System.Collections;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{
    public float materialSpeed = 1f;
    public float batterySpeed = 2f;

    public bool batteryOnBelt = false;

    private GameObject battery;
    private Material conveyerBelt;

    private void Start()
    {
        conveyerBelt = GetComponent<Renderer>().material;
    }
    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Reusable" || tag == "Recyclable" || tag == "Broken")
        {
            battery = collision.gameObject;
            batteryOnBelt = true;
            StartCoroutine(MovingBelt());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Reusable" || tag == "Recyclable" || tag == "Broken")
        {
            battery = null;
            batteryOnBelt = false;
            StopAllCoroutines();

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
