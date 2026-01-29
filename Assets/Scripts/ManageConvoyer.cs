using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;


public class ManageConvoyer : MonoBehaviour
{
    public float materialSpeed = 0.8f;
    public float batterySpeed = 2f;
    public bool batteryOnBelt = false;
    public float MoveDuration = 3f;

    private GameObject battery;
    private Material conveyerBelt;
    private Vector2 MovingVector;
    private Vector3 direction;
    private float MovingDuration;
    private void Start()
    {
        conveyerBelt = GetComponent<Renderer>().material;
        MovingDuration = MoveDuration;
    }
    public void GateCar()
    {
        direction = Vector3.left;
        MovingVector = new Vector2(0, materialSpeed);
        MovingDuration = MoveDuration;
    }
    public void GateVolt()
    {
        MovingDuration = 0f;
    }
    public void GateNikon()
    {
        direction = Vector3.right;
        MovingVector = - new Vector2(0, materialSpeed);
        MovingDuration = MoveDuration;
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
            StopAllCoroutines();
            battery = null;
            batteryOnBelt = false;
        }
    }

    IEnumerator MovingBelt()
    {
        float elapsedTime = 0f;
        battery.transform.Translate(Vector3.forward * batterySpeed * Time.deltaTime, Space.World);
        while (elapsedTime < MovingDuration)
        {
            conveyerBelt.mainTextureOffset += MovingVector * Time.deltaTime;
            battery.transform.Translate(direction * batterySpeed * Time.deltaTime, Space.World);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(MovingBeltForward());
    }

    IEnumerator MovingBeltForward()
    {
        while (battery)
        {
            battery.transform.Translate(Vector3.forward * batterySpeed * Time.deltaTime, Space.World);
            yield return null;
        }
    }
}
