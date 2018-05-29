using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Controller : MonoBehaviour 
{
	public GameObject gun;	
	public Image healthBar;
	public float maxHealth;
	protected float _currentHealth;
	protected GameObject ui;
	
	public void OnCollisionEnter(Collision collision)
	{
		//Debug.Log("HIT");
		if(collision.gameObject.tag == "Bullet")
		{
			GetHit(collision);
		}		
	}
	protected void Shot()
	{
		gun.GetComponent<Gun>().Shot(gameObject.tag);
	}
	protected void GameOver(bool win)
	{
		PopupMenu menu = ui.GetComponent<PopupMenu>();
		menu.win = win;
		menu.GameOver();
	}
	protected void TakeDamage(float amount)
	{
		_currentHealth -= amount;
		healthBar.fillAmount = _currentHealth/maxHealth;
	}
	protected abstract void GetHit(Collision other);	
}
