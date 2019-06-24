using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Controller : MonoBehaviour {
	public GameObject Node_Prefab;
	public float step_lenght=0.2f;
	public float movement_speed = 0.1f;
	public float counter;
	public bool move;


	List<Vector3> del_position;
	GameObject head_obj,my_body_obj;


	public  enum  Snake_Dir
	{
		Right=0,
		Left=1,
		Up=2,
		Down=3
	}
	public  Snake_Dir snake_dir;

	public List<GameObject> Nodes=new List<GameObject>(); //it will contain all the chid of the snake
	// Use this for initialization
	void Start () 
	{   
		snake_dir = (Snake_Dir)Random.Range (0, 4);


		my_body_obj = transform.gameObject;
		del_position = new List<Vector3>{ 
			new Vector3(step_lenght,0,0),//Right_Side
			new Vector3(-step_lenght,0,0),  //left_side
			new Vector3(0,0,step_lenght),//Up_side

			new Vector3(0,0,-step_lenght)//Down_Side
		};


		for (int i = 0; i < transform.childCount; i++) 
		{
			Nodes.Add(transform.GetChild(i).gameObject);
		}
		head_obj = Nodes [0];
			Init_Player ();
	}

	void Init_Player()
	{

		switch (snake_dir) 
		{

		case Snake_Dir.Right: 
			Nodes [1].transform.position = Nodes [0].transform.position - new Vector3 (1f, 0f, 0f);
			Nodes [2].transform.position = Nodes [0].transform.position - new Vector3 (2f, 0f, 0f);
					break;

					case Snake_Dir.Left:
						Nodes[1].transform.position = Nodes[0].transform.position + new Vector3(1f,0f,0f);
						Nodes[2].transform.position = Nodes[0].transform.position + new Vector3(2f,0f,0f);
							break;

					case Snake_Dir.Up: 
						Nodes[1].transform.position = Nodes[0].transform.position - new Vector3(0f,0f,1f);
						Nodes[2].transform.position = Nodes[0].transform.position - new Vector3(0f,0f,2f);
							break;

					case Snake_Dir.Down: 
						Nodes[1].transform.position = Nodes[0].transform.position + new Vector3(0f,0f,1f);
						Nodes[2].transform.position = Nodes[0].transform.position + new Vector3(0f,0f,2f);
							break;
					default:
					
						Nodes[1].transform.position = Nodes[0].transform.position - new Vector3(1f,0f,0f);
							Nodes[2].transform.position = Nodes[0].transform.position - new Vector3(2f,0f,0f);

					break;
		}
	}

	// Update is called once per frame
	void Update () {
		Chech_Movement_Status ();
	}
	void FixedUpdate()
	{

		if (move) 
		{
			Move ();
			move = false;
		}
	}

	void Move()
	{

		Vector3 temp_del_pos = del_position [(int)snake_dir];

		Vector3 temp_head_pos = head_obj.transform.position;
		Vector3 temp_previous_pos;
		 
		//my_body_obj.transform.position += temp_del_pos;
		head_obj.transform.position += temp_del_pos;

		for (int i = 1; i < Nodes.Count; i++) {
			temp_previous_pos = Nodes [i].transform.localPosition;

			Nodes [i].transform.localPosition = temp_head_pos;
			temp_head_pos = temp_previous_pos;
		}



	}

	void Chech_Movement_Status()
	{
		counter += Time.deltaTime;

		if (counter >= movement_speed) 
		{
			counter = 0f;
			move = true;
		}
	}

	public void Increase_Snake_Lenght()
	{
		GameObject obj = Instantiate (Node_Prefab,Nodes[Nodes.Count-1].transform.position,Quaternion.identity,transform);
		//obj.transform.SetParent (transform);
		Nodes.Add (obj);

	}

}
