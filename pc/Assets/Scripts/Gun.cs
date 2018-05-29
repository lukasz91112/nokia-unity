using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{
	public void Shot(string ownerTag)
	{
		var bullet = (GameObject)Instantiate(Resources.Load("Bullet"), transform.position + (transform.forward), transform.rotation);
		bullet.GetComponent<Bullet>().ownerTag = ownerTag;		
	}
}
