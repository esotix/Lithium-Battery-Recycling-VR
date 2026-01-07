using UnityEngine;

public class BatterySpawner : MonoBehaviour
{
    public ObjectPool pool;
    public Transform spawnPoint;

    public float spawnInterval = 1.5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            pool.GetFromPool(spawnPoint.position);
        }
    }
}
