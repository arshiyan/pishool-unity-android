using UnityEngine;
using System.Collections;

public class secound : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
		GUI.matrix = Matrix4x4.Scale(new Vector3(Screen.width/400f,Screen.height/300f,1f)); 
		level.second_display=0;
		InvokeRepeating ("add_second", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

			

	}
	void add_second()
	{
		if(!level.stop)
		{
			level.second_display++;

		}
		this.gameObject.SetActive(!level.stop);
		this.guiText.text=level.second_display.ToString()+ " : " +entry.username;
		
	}
	
}
