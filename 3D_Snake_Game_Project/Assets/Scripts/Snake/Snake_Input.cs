using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Input : MonoBehaviour {
	Snake_Controller snake_controller;
	public Snake_Controller.Snake_Dir current_dir;
	bool snake_going_horizontal;
	bool snake_going_vertical;
	// Use this for initialization
	void Start () {
		snake_controller = GetComponent<Snake_Controller> ();
	}
	
	// Update is called once per frame
	void Update () {
		TakeInput ();
	}

	void TakeInput()
	{
		

		if ((int)snake_controller.snake_dir ==0 ||(int)snake_controller.snake_dir ==1) 
		{
			snake_going_horizontal = true;
			snake_going_vertical = false;
		}
		if ((int)snake_controller.snake_dir ==2 ||(int)snake_controller.snake_dir ==3) 
		{
			snake_going_vertical = true;
			snake_going_horizontal = false;
		}
	
		if(snake_going_vertical)
		{
			if(Input.GetKeyDown(KeyCode.RightArrow)){snake_controller.snake_dir = Snake_Controller.Snake_Dir.Right; }
			if(Input.GetKeyDown(KeyCode.LeftArrow)){snake_controller.snake_dir = Snake_Controller.Snake_Dir.Left; }

		}
		if(snake_going_horizontal)
	    { 
			if(Input.GetKeyDown(KeyCode.UpArrow)){snake_controller.snake_dir = Snake_Controller.Snake_Dir.Up; }
			if(Input.GetKeyDown(KeyCode.DownArrow)){snake_controller.snake_dir = Snake_Controller.Snake_Dir.Down; }

	    }

	}

}

