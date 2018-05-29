using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour 
{	
	public GameObject ui;
	private int _numberOfSpawnPoints;
	private List<Vector3> _pointList;
	void Start()
	{
		_numberOfSpawnPoints = GameplayManager.numberOfEnemies;
		_pointList = GenerateRandomSpawnPoints();
		SpawnEnemies();
	}
	public void SpawnEnemies()
	{		
		for(int enemyCounter = 0; enemyCounter < _numberOfSpawnPoints; enemyCounter++)
		{
			Instantiate(Resources.Load("Enemy"), _pointList[enemyCounter], transform.rotation);
		}		
	}

	private List<Vector3> GenerateRandomSpawnPoints()
	{
        List<Vector3> pointList = new List<Vector3>();
        Vector3 terrainSize = Terrain.activeTerrain.terrainData.size;
		float xDensity = terrainSize.x/_numberOfSpawnPoints;
		float zDensity = terrainSize.z/_numberOfSpawnPoints;
		for(int pointCounter = 0; pointCounter < _numberOfSpawnPoints; pointCounter++)
		{
			float x = ((float)Random.Range(0,101) / 100) * xDensity + (pointCounter * xDensity);
			float z = ((float)Random.Range(0,101) / 100) * zDensity + (pointCounter * zDensity);
			Vector3 point = new Vector3(x, 1, z);
			pointList.Add(point);
		}
		return pointList;
	}	
}
