using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Collision : MonoBehaviour {
	Snake_Controller snake_controller;

	string previous_food,current_food;
	void Start()
	{
		snake_controller =transform.parent.GetComponent<Snake_Controller> ();
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Food"||col.tag == "BlueFood"||col.tag == "RedFood") 
		{ print ("This is foood");
			Food (col.gameObject);
			//Pick the food and make a score and snake lenght will be increase

		}
		if (col.tag == "Wall") 
		{
			Wall_Touch ();
			//it means snake have no more path so game over screen will appear

		}
		if (col.tag == "Node") 
		{
			It_Self_Touch ();
			//it means snake have touch his body part so game over screen will appear

		}
	
	}

	void Food(GameObject col)
	{   current_food = col.tag;
		
			
			if (previous_food != current_food) 
			{  Debug.LogWarning ("Previous food was not same as current food");
				snake_controller.Increase_Snake_Lenght ();
				int points = col.GetComponent<Food> ().points;
				LevelUI.instance.score = points;
				Destroy (col);
				Food_Creater.instance.Create_Food ();	
					previous_food = col.tag;
			}
			else
			{
				Score_Increase (col);
			}

//		}
//		else 
//		{
//			Score_Increase (col);
//		}

	}

	void Score_Increase(GameObject col)
	{
		snake_controller.Increase_Snake_Lenght ();
		int points = col.GetComponent<Food> ().points;
		LevelUI.instance.ScoreChange (points);

		Food_Creater.instance.Create_Food ();	
		previous_food = col.tag;
		Destroy (col);
	}

	void Wall_Touch()
	{
		LevelUI.instance.Game_Over ();
	}

	void It_Self_Touch()
	{
		Wall_Touch ();
	}


}
