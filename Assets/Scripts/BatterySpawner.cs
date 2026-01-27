using Unity.VRTemplate;
using UnityEngine;
using System.Collections;

public class BatterySpawner : MonoBehaviour
{
    public ObjectPool pool;
    public Transform spawnPoint;
    public XRKnob knob;
    public float spawnInterval = 1.5f;
    public FirstConveyer conveyerBelt;

    private bool canSpawn;
    private bool activated = true;
    private bool knobDown = false;


    private void Start()
    {
        canSpawn = !conveyerBelt.batteryOnBelt;
        StartCoroutine(IsKnobDown());
    }
    public void Spawning()
    {
        pool.GetFromPool(spawnPoint.position);
    }

    public void VerifyKnobValue()
    {
        if (knob.value == 1f)
        {
            knobDown = true;
        }
    }

    private void SpawnBattery()
    {
        canSpawn = !conveyerBelt.batteryOnBelt;
        if (activated)
        {
            if (canSpawn)
            {
                Deactivate(activated);
                Spawning();
                StartCoroutine(ResetKnob());
            }
        }
    }

    private void Deactivate(bool active)
    {
        active = false;
    }

    private void Activate(bool active)
    {
        active = true;
    }

    private IEnumerator ResetKnob()
    {
        yield return new WaitForSeconds(spawnInterval);
        knob.value = 0f;
        Activate(activated);

    }
    private IEnumerator IsKnobDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (knobDown)
            {
                SpawnBattery();
                knobDown = false;
            }
        }
    }
}
