using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{
	public void Play()
	{
		int numberOfEnemies = int.Parse(GetComponentInChildren<InputField>().text);
		if(numberOfEnemies > 10)
			numberOfEnemies = 10;
		else if(numberOfEnemies < 1)
			numberOfEnemies = 1;
		GameplayManager.numberOfEnemies = numberOfEnemies;
		GameplayManager.enemiesRemain = numberOfEnemies;
		SceneManager.LoadScene("SampleScene");
	}

	public void Quit()
	{
		Application.Quit();
	}
	
}
