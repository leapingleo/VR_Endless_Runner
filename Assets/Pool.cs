using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject[] zone1Prefabs;
    public GameObject[] zone2Prefabs;
    public GameObject[] zone3Prefabs;

    private Queue<GameObject> zone1Pool;
    private Queue<GameObject> zone2Pool;
    private Queue<GameObject> zone3Pool;


    void Start()
    {
        zone1Pool = new Queue<GameObject>();
        zone2Pool = new Queue<GameObject>();
        zone3Pool = new Queue<GameObject>();
        zone1Pool = InitializePool(zone1Prefabs);
        zone2Pool = InitializePool(zone2Prefabs);
        zone3Pool = InitializePool(zone3Prefabs);
    }


    public GameObject GetFromZone(int index)
    {
      //  if (zone1Pool.Count == 0)
      //      return null;

        // GameObject g = zone1Pool.Dequeue();

        // while (g.activeSelf) {
        //     g = zone1Pool.Dequeue();
        // }
        int foundIndex = -1;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).gameObject.activeSelf)
            {
                if (index == 0 && transform.GetChild(i).CompareTag("Industrial"))
                    return transform.GetChild(i).gameObject;
                else if (index == 1 && transform.GetChild(i).CompareTag("Suburb"))
                    return transform.GetChild(i).gameObject;
                else if (index == 2 && transform.GetChild(i).CompareTag("Urban"))
                    return transform.GetChild(i).gameObject;
            }
                
        }

        return null;
    }
    
    public void RandomPool() 
    {
         for (int i = 0; i < transform.childCount; i++)
        {
        transform.GetChild(i).SetSiblingIndex(Random.Range(0, transform.childCount - 1));
        }
    }

    Queue<GameObject> InitializePool(GameObject[] zonePrefabs) {
        Queue<GameObject> queue = new Queue<GameObject>();

        for (int i = 0; i < zonePrefabs.Length * 10; i++) 
        {
            GameObject go = Instantiate(zonePrefabs[i % zonePrefabs.Length], Vector3.zero, Quaternion.identity);
            go.transform.parent = transform;
            go.SetActive(false);
            queue.Enqueue(go);
        }

        return queue;
    }
}
