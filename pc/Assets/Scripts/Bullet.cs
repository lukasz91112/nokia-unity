using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	public string ownerTag;
	public float damage;
	private Vector3 _terrainSize;
	private void Start()
	{
		_terrainSize = Terrain.activeTerrain.terrainData.size;
	}
	private void Update()
	{
		Fly();
		SelfDestroy();
	}
    private void Fly()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * 3);
	}
	private void SelfDestroy()
	{
		if(transform.position.x > _terrainSize.x || transform.position.x < 0)
		{
			Destroy(gameObject);
		}
		if(transform.position.z > _terrainSize.z || transform.position.z < 0)
		{
			Destroy(gameObject);
		}
	}

}
