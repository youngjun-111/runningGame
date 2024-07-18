using System.Collections.Generic;
using UnityEngine;

public class GimmickPool : MonoBehaviour
{
    public GameObject prefab;
    public int initialPoolSize = 5;

    private List<GameObject> pool;

    void Start()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        foreach (var obj in pool)
        {
            if (obj != null && !obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }

    public void ReturnObject(GameObject obj)
    {
        if(obj != null)
        {
            obj.SetActive(false);
        }
    }
}