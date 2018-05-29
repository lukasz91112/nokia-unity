using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
	void Start()
	{
		_currentHealth = maxHealth;
		ui = GameObject.FindGameObjectWithTag("GameController").GetComponent<Initializer>().ui;
	}
	void Update () 
	{
		ListenToActions();		
	}
	protected override void GetHit(Collision other)
    {
		Bullet bullet = other.gameObject.GetComponent<Bullet>();
		if(bullet.ownerTag != "Player")
		{
			TakeDamage(bullet.damage);
			if(_currentHealth <= 0)
				GameOver(false);
		}		
		Destroy(other.gameObject);
    }	
	private void ListenToActions()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Shot();
		}
	}    
}
