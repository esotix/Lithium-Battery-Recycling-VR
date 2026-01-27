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
    public bool testingNikon = false;
    public bool testingVolt = false;
    public bool testingCar = false;

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

    private void Update()
    {
        if (testingNikon)
        {
            GateNikon();
            testingNikon = false;
        }
        if (testingCar)
        {
            GateCar();
            testingCar = false;
        }
        if (testingVolt)
        {
            GateVolt();
            testingVolt = false;
        }
    }
    public void GateCar()
    {
        direction = Vector3.back;
        MovingVector = new Vector2(0, materialSpeed);
        MovingDuration = 2.8f;
    }
    public void GateVolt()
    {
        MovingDuration = 0f;
    }
    public void GateNikon()
    {
        direction = Vector3.forward;
        MovingVector = - new Vector2(0, materialSpeed);
        MovingDuration = 2.7f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "BatteryNikon" || tag == "BatteryCar" || tag ==  "BatteryVolt")
        {
            battery = collision.gameObject;
            batteryOnBelt = true;
            StartCoroutine(MovingBelt());
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

    IEnumerator MovingBelt()
    {
        float elapsedTime = 0f;
        battery.transform.Translate(Vector3.left * batterySpeed * Time.deltaTime, Space.World);
        while (elapsedTime < MovingDuration)
        {
            conveyerBelt.mainTextureOffset += MovingVector * Time.deltaTime;
            battery.transform.Translate(direction * batterySpeed * Time.deltaTime, Space.World);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(MovingBeltLeft());
    }

    IEnumerator MovingBeltLeft()
    {
        while (battery)
        {
            conveyerBelt.mainTextureOffset += new Vector2(materialSpeed * Time.deltaTime, 0) ;
            battery.transform.Translate(Vector3.left * batterySpeed * Time.deltaTime, Space.World);
            yield return null;
        }
    }
}
