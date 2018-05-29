using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : Controller
{			
	private GameObject _player;	

	void Start()
	{
		_currentHealth = maxHealth;
		ui = GameObject.FindGameObjectWithTag("GameController").GetComponent<Initializer>().ui;
		_player = GameObject.FindGameObjectWithTag("Player");
		StartCoroutine(ShotRandomly());
	}	
	void Update()
	{
		SpotPlayer();
	}
	public IEnumerator ShotRandomly()
	{		
		while(true)
		{
			//Debug.Log("Shot");
			float seconds = UnityEngine.Random.Range(1.0f, 5.0f);
			Shot();
			yield return new WaitForSeconds(seconds);
		}		
	}
    protected override void GetHit(Collision other)
    {
		Bullet bullet = other.gameObject.GetComponent<Bullet>();
        if(bullet.ownerTag != "Enemy")
		{
			TakeDamage(bullet.damage);
			if(_currentHealth <= 0)
			{
				Destroy(gameObject);
				GameplayManager.enemiesRemain -= 1;
				if(GameplayManager.enemiesRemain == 0)
				{
					GameOver(true);
				}
			}			
		}
		Destroy(other.gameObject);
    }	
	private void SpotPlayer()
	{		
		transform.LookAt(_player.transform);
	}	
}
