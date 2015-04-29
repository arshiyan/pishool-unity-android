using UnityEngine;
using System.Collections;

public class user : MonoBehaviour {

	public float normalSW = 400f;
	public float normalSH = 300f;
	public static string username1 = "";//username 
	public string login_btn ="";
	PersianMaker pm;
	public GUISkin persianskin;

	// Use this for initialization
	void Start () {
		//TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true, true);
		pm=new PersianMaker();
		login_btn = pm.ToPersian1("ورود");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.skin=persianskin;
		GUI.matrix = Matrix4x4.Scale(new Vector3(Screen.width/normalSW,Screen.height/normalSH,1f)); 
		GUI.Label(new Rect(50f,20f,130f,20f),pm.ToPersian1("نام کاربری"));
		username1 = GUI.TextField(new Rect(50f, 40, 130, 20), pm.ToPersian1(username1));
		if (GUI.Button(new Rect(50f,70f,130f,40),login_btn))
		{
			if(username1.Length>3)
			{
				Application.LoadLevel(1);
			}
			else
			{
				StartCoroutine(alert());
			}
		}
	}

	IEnumerator alert()
	{
		login_btn=pm.ToPersian1("اشتباه");
		yield return new WaitForSeconds(2f);
		login_btn=pm.ToPersian1("ورود");
	}
}
