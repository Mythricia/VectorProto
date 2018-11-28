using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    public Transform crystalPrefab;
    public Transform[] spawnPoints;

    public Crystal[] crystals;

    // Use this for initialization
    void Start()
    {
        if (!crystalPrefab)
        {
            print("CrystalSpawner:: Missing Crystal prefab! Disabling self.");
            this.enabled = false;
            return;
        }

        if (spawnPoints.Length == 0)
        {
            print("CrystalSpawner:: No spawn points defined. Disabling self.");
            this.enabled = false;
            return;
        }
        else
        {
            populateSpawnPoints();
        }


        crystals = GetComponentsInChildren<Crystal>();
        if (crystals.Length == 0)
        {
            print("CrystalSpawner:: Could not find any Crystal children! Disabling self.");
            this.enabled = false;
            return;
        }
        else
        {
            string s = string.Format("CrystalSpawner:: Spawned {0}", crystals.Length);
            print(s);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            foreach (Crystal c in crystals) c.SetState(Crystal.GrowthState.Dormant);
            print("Dormant");
        }
        else if (Input.GetKeyDown("y"))
        {
            foreach (Crystal c in crystals) c.SetState(Crystal.GrowthState.Growing);
            print("Growing");
        }
        else if (Input.GetKeyDown("u"))
        {
            foreach (Crystal c in crystals) c.SetState(Crystal.GrowthState.Harvestable);
            print("Harvestable");
        }
        else if (Input.GetKeyDown("r"))
        {
            foreach (Crystal c in crystals) c.Respawn();
            print("Respawning");
        }
        else if (Input.GetKeyDown("h"))
        {
            foreach (Crystal c in crystals) c.Harvest();
            print("Harvested");
        }
    }


    void populateSpawnPoints()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(crystalPrefab, spawnPoint.transform);
            spawnPoint.gameObject.AddComponent<Crystal>();
        }
    }
}