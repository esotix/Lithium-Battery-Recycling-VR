using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPool : MonoBehaviour
{

    public List<GameObject> batteryPrefabs;
    public int poolSize = 3;

    private List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        for (int i = 0; i < batteryPrefabs.Count; i++)
        {
            GameObject obj = Instantiate(batteryPrefabs[i], transform);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
    public GameObject GetFromPool(Vector3 position)
    {
        int randomIndex = Random.Range(0, pool.Count);
        GameObject obj = pool[randomIndex];

        obj.transform.position = position;
        obj.SetActive(true);

        return obj;
    }


    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
    }
}
