using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopupMenu : MonoBehaviour 
{

	public bool win;
	private Text _resultText;
	
	void Start () 
	{
		gameObject.SetActive(false);
		_resultText = GetComponentInChildren<Text>();
	}
	public void GameOver()
	{
		Time.timeScale = 0;
		SetResultText();
		gameObject.SetActive(true);
	} 

	public void PlayAgain()
	{
		GameplayManager.enemiesRemain = GameplayManager.numberOfEnemies;
		Time.timeScale = 1;
		SceneManager.LoadScene("SampleScene");
	}

	public void Quit()
	{
		Application.Quit();
	}
	
	private void SetResultText()
	{
		if(win)
			_resultText.text = "Gratulacje, wygrałeś!";
		else
			_resultText.text = "Porażka";
	}	
}
