using UnityEngine;
using System.Collections;
using System;
using System.Text;

public class level : MonoBehaviour {

	public static int levelNo=1;
	public static float speed=0f;
	public static float creatore_retry_time=1f;
	public static int monster_power=1;
	public static int _score=0;
	public static int second=0;
	public static int second_display=0;
	public static bool is_starting_game = false;
	public static bool is_pausing_game = false;
	public static bool fine=false;
	public static bool stop=false;
	public bool stop_buffer=false;
	public GameObject touchEffect;
	public AudioClip touchEffect_sound;
	public string icode="";//ingame code
	public string ingame_url="";//ingame code
	/* start menu */
	public GameObject _menu;
	public btnInfo touched_btn;
	/* end menu */

	RaycastHit2D hit;

	public GameObject levelUP;
	public AudioClip levelup_sound;
	private static Vector3 _default_pishool;
	private static Transform _pishool;

	public GameObject pause_btn;
	public GameObject back_btn;
	private float nextTime=0.5f;

	public TextMesh info;

	/*limit touch*/

	private float next_time_limit_touch=0.01f;
	private float current_time_limit_touch;
	private static float current_power=10f;
	public GUITexture power;
	public GUIText power_text;
	private PersianMaker pm;

	//facebook
	private const string FACEBOOK_APP_ID = "284541635083794";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";

	public GameObject[] _monster;

	void Start () {

		levelNo=1;
		_default_pishool = (Vector3)GameObject.FindGameObjectWithTag("pishool").transform.position;
		_pishool = (Transform)GameObject.FindGameObjectWithTag("pishool").transform;
		pause_btn.SetActive(false);

		foreach(GUIText chosentext in FindObjectsOfType(typeof(GUIText)) as GUIText[])
		{
			chosentext.fontSize = Mathf.FloorToInt(Screen.height * 0.05f);
		}
		QualitySettings.vSyncCount = 0;
		power.enabled = false;
		pm = new PersianMaker();
		power_text.text = pm.ToPersian1("انرژی");
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

	}
	
	// Update is called once per frame
	void Update () 
	{
		stop_buffer=stop;
		check_stop();
		get_touch();

		if(level.stop)
			return;
		level_mannager();

		levelInfo();

		if(level.fine)
			mission_fail();

		pause_btn_status();

	}

	void FixedUpdate()
	{
		limit_touch();
	}

	void get_touch()
	{
		if (Input.touchCount > 0) 
		{
			for(int i = 0; i < Input.touchCount; i++) 
			{
				Touch t = Input.GetTouch(i);

				if (t.phase == TouchPhase.Began)
				{
					//limit touch
						
										

					if((current_power >= 2) && !level.stop)
					{
							current_power-=2;
							if(!level.stop)	
							Instantiate(touchEffect,new Vector2(Camera.main.ScreenToWorldPoint(t.position).x,Camera.main.ScreenToWorldPoint(t.position).y),Quaternion.identity);
							audio.PlayOneShot(touchEffect_sound);
					}
									hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(t.position), Vector2.zero);
									if (hit.collider != null) 
									{
										if (hit.collider.gameObject.GetComponent<btnInfo>())
										{
											touched_btn=hit.collider.gameObject.GetComponent<btnInfo>();
											switch(touched_btn.type)
											{
												case "menu_btn":
												{
													
													do_act(touched_btn.id);
													if(touched_btn._anim.name != null)
														_menu.animation.Play(touched_btn._anim.name);
													break;
												}
									
												
											}
											
										}
										else if(hit.collider.tag == "monster")
										{
												if(current_power >= 2 ) 
												{
													hit.collider.transform.GetComponent<monster_behavior>().add_dammage();
												}
										}
										
									}
							
				}

			}
		}
				

	}

	void do_act(string str_btn)
	{
		switch(str_btn)
		{
		case "pause":
		{
			level.is_pausing_game = true;
			level.stop=false;
			break;
		}
		case "play_level":
		{
			level.is_starting_game = true;

			level.initlevel();
			StartCoroutine("_wait");
			//call_monster();
			back_btn.SetActive(!level.fine);
			break;
		}
		case "pause_to_game":
		{
			level.is_pausing_game = false;
			level.stop=false;
			break;
		}
		case "screenshot":
		{
			/*
			string code = (level.second_display+21)+"|"+icode;
			byte[] bytesToEncode = Encoding.UTF8.GetBytes (code.ToString());
			string encodedText = Convert.ToBase64String (bytesToEncode);
			string url=ingame_url+"/?d="+encodedText+"&s="+Md5Sum(level.second_display+icode);
			Application.OpenURL(url);
			*/
			string link ="http://cafebazaar.ir/app/com.Arshiyan.pishool/?l=fa";
			string title =" رکورد من در بازی پیشول : "+level.second_display +" امتیاز";
			string description ="امتیاز من "+level.second_display;
			string coption ="بازی پیشول نسخه اندروید را دانلود کنید";
			string img ="http://ingame.ir/uploads/4/19/4c1069b17dcf6ca9a4c7ec9620ab00aa.jpg";
			string url ="http://ingame.ir/site/game/Pishool";

			ShareToFacebook(link,title,coption,description,img,url);
			break;
		}

		case "pause_to_score":
		{
			GameObject score_txt= GameObject.FindGameObjectWithTag("score_gui");
			score_txt.GetComponent<HighScore>().enabled=true;
			HighScore.isScoring = true;

			break;
		}

		case "score":
		{
			GameObject score_txt= GameObject.FindGameObjectWithTag("score_gui");
			score_txt.GetComponent<HighScore>().enabled=true;
			HighScore.isScoring = true;
			break;
		}

		case "score_to_pause":
		{
			GameObject score_txt= GameObject.FindGameObjectWithTag("score_gui");
			score_txt.GetComponent<HighScore>().enabled=false;
			HighScore.isScoring = false;
			_destroy_highscore();
			break;
		}

		case "score_to_main":
		{
			GameObject score_txt= GameObject.FindGameObjectWithTag("score_gui");
			score_txt.GetComponent<HighScore>().enabled=false;
			HighScore.isScoring = false;
			_destroy_highscore();
			break;
		}


		case "submit_score":
		{

			HighScore hs= new HighScore();
			StartCoroutine(hs.AddScore(entry.username,level.second_display));
			GameObject _submit_score= GameObject.FindGameObjectWithTag("submit_score");
			_submit_score.GetComponent<scorelist>().enabled=false;
			
			scorelist.set_score();

			break;
		}
		case "facebook_btn":
		{

			Application.OpenURL("https://www.facebook.com/pishool.game");
			break;
		}

		case "unityir":
		{
			Application.OpenURL("http://forum.unity3d.ir");
			break;
		}

		case "exit_btn":
		{
			Application.Quit();

			break;
		}

		}
		
	}


	IEnumerator _wait()
	{
		enemy_maker.retry=false;
		yield return new WaitForSeconds(3f);	
		enemy_maker.retry=true;

		
	}
	public static void initlevel()
	{
		level.levelNo=1;
		level.speed=0f;
		level.creatore_retry_time=1f;
		level.monster_power=1;
		level._score=0;
		level.second=0;
		level.second_display=0;
		level.is_pausing_game = false;
		level.fine=false;
		level._pishool.parent = null;
		level._pishool.position =new Vector3(_default_pishool.x,_default_pishool.y,_default_pishool.z);
		_pishool.GetComponent<BoxCollider2D>().enabled=true;
		enemy_maker.retry =true;
		level.stop=false;
		level.current_power=10f;


	}


	void levelInfo()
	{
		if(second_display >= second)
		{
			levelNo++;
			StartCoroutine("levelup");
		}
	}

	IEnumerator levelup()
	{
		//levelUP.transform.position = Vector2.zero;
		audio.PlayOneShot(levelup_sound);
		levelUP.SetActive(true);
		yield return new WaitForSeconds(3f);	
		info.text=level.monster_power.ToString()+"X";
		//monster_power
		levelUP.transform.position += Vector3.up * Time.smoothDeltaTime *2f;
		levelUP.SetActive(false);

	}

	void level_mannager()
	{
		switch (levelNo)
		{
			case 1:
			{
				
				speed = 1.1f;
				creatore_retry_time = 3.5f;
				monster_power = 1;
				second=20;
				
				break;
			}
			case 2:
			{
				
				speed =1.2f;
				creatore_retry_time = 3f;
				monster_power = 2;
				second=40;

				break;
			}
			case 3:
			{
				
				speed = 1.3f;
				creatore_retry_time = 2.5f;
				monster_power = 2;
				second=80;

				break;
			}
			case 4:
			{
				
				speed = 1.4f;
				creatore_retry_time = 2.3f;
				monster_power = 2;
				second=150;

				break;
			}
			case 5:
			{
				
				speed = 1.6f;
				creatore_retry_time = 2.2f;
				monster_power = 2;
				second=250;
				
				break;
			}
			case 6:
			{
				
				speed = 1.8f;
				creatore_retry_time = 2f;
				monster_power = 3;
				second=350;
				
				break;
			}
			case 7:
			{
				
				speed = 2f;
				creatore_retry_time = 1.5f;
				monster_power = 3;
				second=450;

				break;
			}
			case 8:
			{
				
				speed = 2.2f;
				creatore_retry_time = 1.3f;
				monster_power = 3;
				second=550;

				break;
			}
			case 9:
			{
				
				speed = 2.5f;
				creatore_retry_time = 1.2f;
				monster_power = 3;
				second=650;
				
				break;
			}
			case 10:
			{
				
				speed = 3.5f;
				creatore_retry_time = 1f;
				monster_power = 3;
				second=1000;

				break;
			}
		

		}

	}

     void check_stop()
	{
		if(level.is_pausing_game)
		{
			level.stop = true;
		}
		else if(!level.is_starting_game)
		{
			level.stop = true;
		}
		else if(!level.is_pausing_game && (level.stop == true) && level.fine)
		{
			level.stop=false;
		}


	}

	void mission_fail()
	{
		_menu.animation["menu_game_to_pause"].wrapMode = WrapMode.ClampForever;
		_menu.animation.Play("menu_game_to_pause");
		back_btn.SetActive(!level.fine);
		level.is_pausing_game = true;
	}

	void pause_btn_status()
	{
		pause_btn.SetActive(!level.is_pausing_game);
	}


	void call_monster()
	{
		int i=0;

		_monster =GameObject.FindGameObjectsWithTag("monster");
		foreach(GameObject mon in GameObject.FindGameObjectsWithTag("monster"))
		{

			mon.transform.GetComponent<monster_behavior>().active=false;
			mon.transform.GetComponent<monster_behavior>().power = 0;
			mon.transform.GetComponent<monster_behavior>().takenPishool = false;
			mon.transform.GetComponent<monster_behavior>().canTakePishool = true;
			i++;
		}
	}

	public bool help()
	{
		if((PlayerPrefs.GetInt("display help") != null) || (PlayerPrefs.GetInt("display help") == 0))
		{
			PlayerPrefs.SetInt("display help",1);

			return false;
		}
		else
		{
			return true;
		}

		return true;
			
	}

	public void limit_touch()
	{
		if(current_power <=10)
			current_power = ((Time.time * .005f)+current_power);

			power.pixelInset = new Rect(power.pixelInset.x,power.pixelInset.y, (current_power*10f)+5f,20f);

			power.enabled = !level.stop;
			power_text.enabled = !level.stop;
			
	}

	public void _destroy_highscore()
	{
		foreach(GUIText chosentext in FindObjectsOfType(typeof(GUIText)) as GUIText[])
		{
			if(chosentext.tag == "Score")
				Destroy(chosentext.gameObject);
		}
	}

	private string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);
		
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);
		
		string hashString = "";
		
		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}
		
		return hashString.PadLeft(32, '0');
	}

	void ShareToFacebook (string linkParameter, string nameParameter, string captionParameter, string descriptionParameter, string pictureParameter, string redirectParameter)
	{
		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
		                     "&link=" + WWW.EscapeURL(linkParameter) +
		                     "&name=" + WWW.EscapeURL(nameParameter) +
		                     "&caption=" + WWW.EscapeURL(captionParameter) + 
		                     "&description=" + WWW.EscapeURL(descriptionParameter) + 
		                     "&picture=" + WWW.EscapeURL(pictureParameter) + 
		                     "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}
	
}
