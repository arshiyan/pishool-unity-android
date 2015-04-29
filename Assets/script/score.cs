using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

	public int sort=50;
	string username;
	PersianMaker pm ;
	void Start()
	{
		this.renderer.sortingOrder=100;
		this.gameObject.GetComponent<MeshRenderer>().sortingOrder =100;
		username = PlayerPrefs.GetString("Player name");
		pm = new PersianMaker();


	}

	void FixedUpdate () {
		//this.gameObject.GetComponent<MeshRenderer>().sortingOrder =50;
		//this.renderer.sortingOrder=sort;

		this.GetComponent<TextMesh>().text =entry.username + "\n "+ level.second_display.ToString();
	}


}
