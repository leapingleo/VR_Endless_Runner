using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class TrackManager : MonoBehaviour
{
    public Transform player;
    public ThemeData themeData;
    private Vector3 spawnPos;
    public Pool pool;
    public int index;

    void Start()
    {
        spawnPos = Vector3.zero;
//        Debug.Log(themeData.zone[0].prefabList[0].transform.GetChild(1).name);

     //   Spawn();
    }

    void Update()
    {
        if (Vector3.Distance(player.position, spawnPos) < 80f)
            Spawn();
    }


    void Spawn()
    {
        for (int i = 0; i < 6; i++){
          //  GameObject toSpawnPrefab = themeData.zone[2].prefabList[Random.Range(0, themeData.zone[2].prefabList.Length - 1)];
          // GameObject toSpawnPrefab = themeData.zone[2].prefabList[6];
            GameObject toSpawnPrefab = pool.GetFromZone(index);
            toSpawnPrefab.SetActive(true);
            toSpawnPrefab.transform.position = spawnPos;

            Track track = toSpawnPrefab.GetComponent<Track>();
         //   GameObject toSpawnObject = Instantiate(toSpawnPrefab , spawnPos, Quaternion.identity);
           // spawnPos += toSpawnPrefab.transform.GetChild(2).GetChild(1).position - 
           // toSpawnPrefab.transform.GetChild(2).GetChild(0).position;
            spawnPos += track.GetExitPoint() - track.GetEntryPoint();
            
        }
        pool.RandomPool();
    }
}
