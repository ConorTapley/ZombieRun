using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform m_playerTransform;
    private float m_spawnZ = -324.0f;
    private float m_tileLength = 324.0f;
    private float m_safeZone = 350.0f;
    private int m_amountOfTilesOnScreen = 10;
    private int m_lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

	void Start () {
        activeTiles = new List<GameObject>();
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        ///////////Always spawn the first tile in the list first so the player doesnt insta die////////
        for(int i = 0; i < m_amountOfTilesOnScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();////spawn the tiles randomly after the first tile has been spawned
        }
    }
	
	
	void Update () {
        //////////////as the player moves a tile behind them is deleted as a tile in front of them is spawned/////////////
        //////////////this means that the game doesnt lag the further you go and you can control how may tiles will be on screen///////////
		if(m_playerTransform.position.z - m_safeZone > (m_spawnZ - m_amountOfTilesOnScreen * m_tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
	}

    private void SpawnTile(int prefabIndex = -1)
    {
        //put all the tiles in the TileManager
        GameObject go; //call the new tile to be spawned go
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject; //choose a random tile from the list to be (go)
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

        go.transform.SetParent (transform); //make the tiles a child of the tilemanager

        go.transform.position = Vector3.forward * m_spawnZ; 
        m_spawnZ += m_tileLength;

        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        ////destroy the tile furthest behind the player////
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        //////randomly generates a number from 0 - length of the list index////////
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = m_lastPrefabIndex;

        while(randomIndex == m_lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        m_lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
