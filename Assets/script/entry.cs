using UnityEngine;
using System.Collections;

public class entry : MonoBehaviour {
	
	public string kBoardString = "";

	private string tempString = "";
	private TouchScreenKeyboard keyboard;
	private bool iskBoardOpen = true;
	
	private PersianMaker pm;
	RaycastHit2D hit;
	public static string username = "";//username 
	public static string buffer_username = "";//username 
	public GameObject login;
	
	// Use this for initialization
	void Start () {

		//this.guiText.text =PlayerPrefs.GetString("Player name").ToString();
		pm = new PersianMaker();
		keyboard = TouchScreenKeyboard.Open(kBoardString, TouchScreenKeyboardType.NamePhonePad,false,false,false,false,("نام خود را وارد کنید - نهایتا نام شما باید 20 حرفی باشد"));
		this.chack_name();
	}
	
	// Update is called once per frame
	void Update () 
	{
		do_entry();
		this.guiText.text = pm.ToPersian1( "نام شما : " + kBoardString );


		if(kBoardString.Length >= 3  && kBoardString.Length <= 20)
		{
			login.SetActive(true);
		}
		else
		{
			login.SetActive(false);
		}
		
		if(Input.GetMouseButtonDown(0))
		{
			hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (hit.collider != null) 
			{
				if(hit.transform.tag=="name")
				{
					iskBoardOpen = false;
					keyboard =TouchScreenKeyboard.Open(kBoardString, TouchScreenKeyboardType.NamePhonePad,false,false,false,false,("نام خود را وارد کنید"));

					
				}
				else if(hit.transform.tag == "enterbtn")
				{
					entry.username =pm.ToPersian1(kBoardString);
					entry.buffer_username =(kBoardString);

					//entry.buffer_username =("جواد عرشیان");
					//entry.username =pm.ToPersian1("جواد عرشیان");

					PlayerPrefs.SetString("Player name",pm.ToPersian1(kBoardString));
					PlayerPrefs.SetString("Player name buffer",(kBoardString));
					Application.LoadLevel(1);
					
				}

			}
		}
	}
	
	
	void do_entry()
	{
		if ( !iskBoardOpen ) 
		{
			
			//iskBoardOpen = true;
			
		}
		
		if ( keyboard.done && !iskBoardOpen ) 
		{
			kBoardString = keyboard.text;
			tempString = "";
			keyboard.active = false;
			iskBoardOpen = true;


		}
		else
		{
			kBoardString = keyboard.text;
			
		}
		
		
		
	}

	void chack_name()
	{

		if(PlayerPrefs.GetString("Player name buffer").Length >0)
		{
			keyboard.text = PlayerPrefs.GetString("Player name buffer");
		}
	}

}