using UnityEngine;

public class BatteryMover : MonoBehaviour
{
    public float speed = 1.5f;
    public float lifeTime = 5f;

    private float timer;
    private ObjectPool pool;

    public void Init(ObjectPool objectPool)
    {
        pool = objectPool;
        timer = 0f;
    }

    void Update()
    {
        // Déplacement gauche → droite
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            pool.ReturnToPool(gameObject);
        }
    }
}
