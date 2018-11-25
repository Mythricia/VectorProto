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
		if(!crystalPrefab)
		{
			print("CrystalSpawner:: Missing Crystal prefab! Disabling self.");
			this.enabled = false;
			return;
		}

		if(spawnPoints.Length == 0)
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
