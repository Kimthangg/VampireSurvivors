using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_randomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoint;
    public List<GameObject> propPrefabs;
    void Start()
    {
        SpawnProps();
    }

    void Update()
    {

    }
    void SpawnProps()
    {
        foreach (GameObject sp in propSpawnPoint)
        {
            int rand = Random.Range(0, propPrefabs.Count);
            GameObject prop = Instantiate(propPrefabs[rand], sp.transform.position, Quaternion.identity);
            prop.transform.parent = sp.transform;
        }
    }
}
