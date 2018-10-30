using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform m_playerTransform;
    private float m_spawnZ = 0.0f;
    private float m_tileLength = 324.0f;
    private int m_amountOfTilesOnScreen = 7;
	
	void Start () {

        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        SpawnTile ();
        SpawnTile ();
        SpawnTile ();
        SpawnTile ();
    }
	
	
	void Update () {
		
	}

    private void SpawnTile(int prefabIndex = -1)
    {
        //put all the tiles in the TileManager
        GameObject go;
        go = Instantiate (tilePrefabs[0]) as GameObject;
        go.transform.SetParent (transform);

        go.transform.position = Vector3.forward * m_spawnZ;
        m_spawnZ += m_tileLength;
    }
}
