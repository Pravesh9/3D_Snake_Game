using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Creater : MonoBehaviour {
	public static Food_Creater instance;
	public GameObject []Food;
	// Use this for initialization
	void Start () {
		instance = this;
		Create_Food ();	
	}

	public void Create_Food()
	{DeleteAllFood ();
		for (int i = 0; i < Food.Length; i++) {
			GameObject obj = Instantiate (Food [i]);
			obj.transform.position = new Vector3 (Random.Range (-6, 6), 0.31f, Random.Range (-6, 6));
		}
	}

	void DeleteAllFood ()
	{
		foreach (var foodobj in GameObject.FindObjectsOfType<Food>()) {
			Destroy (foodobj.gameObject);
		}
	}

}
