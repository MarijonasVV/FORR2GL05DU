using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Array sem geymir dýrin
    public GameObject[] animalPrefabs;

    //Staðsetning þar sem dýra spawna
    private float spawnRangeX = 10f;
    private float spawnPosZ = 20f;

    //bil á milli dýr að spawna
    private float startDelay = 2;
    private float spawnInterval = 2.5f;
    
    void Start()
    {
        //kallar á SpawnRandomAnimal fallið á sérstakan tímabil
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Fall sem spawnar dýr
    void SpawnRandomAnimal()
    {
        //Gerir random spawnpoint hjá dýr
        Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        //Veljir random dýr úr array
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        //gerir nýtt animal og setjir á skjáinn
        Instantiate(animalPrefabs[animalIndex], spawnpos, animalPrefabs[animalIndex].transform.rotation);

    }
}
