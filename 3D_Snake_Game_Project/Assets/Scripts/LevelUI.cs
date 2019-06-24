using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelUI : MonoBehaviour {
	public static LevelUI instance;
	public GameObject Game_Over_Panel;
    public Text current_Score_Text,Final_Score_Text,Best_Score_Text;
	public int score;
	void Start()
	{

		instance = this;
	}

	public void Update()
	{
		Best_Score_Text.text = "Best : " + PlayerPrefs.GetInt ("BestScore", 0).ToString ();
		current_Score_Text.text = "Score : "+score.ToString ();
		Final_Score_Text.text = "Score : "+score.ToString ();
	}


	public void Game_Over()
	{   SetScore ();
		Time.timeScale = 0f;
		Game_Over_Panel.SetActive (true);
	}
	void SetScore ()
	{
		if (score >= PlayerPrefs.GetInt ("BestScore", 0)) 
		{
			PlayerPrefs.SetInt ("BestScore", score);
		}
	}
	public void Restart()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Main");
	}
	public void Menu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Menu");
	}


	public void ScoreChange(int sc)
	{   
		score += sc;
	}

}
