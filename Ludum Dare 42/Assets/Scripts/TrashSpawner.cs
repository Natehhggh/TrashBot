using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour {

    public GameObject trashPrefab;

    public float mapWidth = 48;
    public float mapLength = 48;
    public float dropHeight = 20;
    public float difficultyMultiplier = 1;
    public int baseTrashPerWave = 10;
    public float spawnDelay = .2f;
    public int wave = 1;
    public int waveDelay = 10;
    public int trashCount;
    private int trashThisWave;
    public LevelManager levelManager;
    private int loseCondition;
	void Start () 
    {
        trashThisWave = (int)((baseTrashPerWave + (wave * 2)) * difficultyMultiplier);
        loseCondition = 200;
        StartCoroutine(spawnWaves());
	}
	

    IEnumerator spawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < trashThisWave; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-mapWidth / 2, mapWidth / 2), dropHeight, Random.Range(-mapLength / 2, mapLength / 2));
                GameObject trash = Instantiate(trashPrefab, spawnPosition, Random.rotation) as GameObject;
                trash.transform.parent = this.transform;
                yield return new WaitForSeconds(spawnDelay);

            }
            wave += 1;
            trashThisWave = (int)((baseTrashPerWave + (wave * 2)) * difficultyMultiplier);
            yield return new WaitForSeconds(waveDelay);

        }

    }


    void Update()
    {
        trashCount = this.transform.childCount;

        if (trashCount >= loseCondition)
        {
            foreach (Transform child in this.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            levelManager.loadLevel("Lose");
        }
    }

}
