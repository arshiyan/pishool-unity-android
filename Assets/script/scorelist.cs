using UnityEngine;
using System.Collections;

public class scorelist : MonoBehaviour {
	

	void OnEnable()
	{
		//this.GetComponent<SpriteRenderer>().enabled = scorelist.can_sumbit();
		//PlayerPrefs.SetInt("Player Score",0);
	}

	public static void set_score()
	{
		if((scorelist.get_score() != null) || (scorelist.get_score() <= 0))
		PlayerPrefs.SetInt("Player Score", level.second_display);
		else
		PlayerPrefs.SetInt("Player Score",0);
	}

	public static int get_score()
	{
		return PlayerPrefs.GetInt("Player Score");
	}

	public static bool can_sumbit()
	{
		if(level.second_display > PlayerPrefs.GetInt("Player Score"))
		{
			return true;
		}
		return false;
	}
}
