using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
	public Text Best_SCore_Text;
	// Use this for initialization
	void Start () {
		Best_SCore_Text.text = "Best : " + PlayerPrefs.GetInt ("BestScore", 0);
	}
	
	public void Play()
	{
		SceneManager.LoadScene ("Main");

	}
}
