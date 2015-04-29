using UnityEngine;
using System.Collections;

public class mainController : MonoBehaviour
{
	public btnInfo touched_btn;
	RaycastHit hit;
	public GameObject _menu;
	public GameObject _level;

	void Start () 
	{
		
	}
	

	void FixedUpdate () 
	{
		readTouch();
	}

	void readTouch()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{

				if (hit.collider.gameObject.GetComponent<btnInfo>())
				{
					touched_btn=hit.collider.gameObject.GetComponent<btnInfo>();

					switch(touched_btn.type)
					{
						case "menu_btn":
						{
							_menu.animation.Play(touched_btn._anim.name);



							break;
						}
						case "level_btn":
						{
							_level.animation.Play(touched_btn._anim.name);
							break;
						}

						
					}

				}
			}

		}

	}


	
}
