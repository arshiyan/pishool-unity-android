using UnityEngine;
using System.Collections;

public class play_character_anim : MonoBehaviour {

	public AnimationClip anim;

	// Use this for initialization
	void Start () {
		StartCoroutine("_play");
	}
	
	IEnumerator _play()
	{
		yield return new WaitForSeconds(3);
		_play_anim();
	}

	void _play_anim()
	{
		if((Random.Range(2,20)%2) == 0)
		{
			if(this.animation["c_ltr"])
			{
				this.animation["c_ltr"].speed=Random.Range(0.9f,1.1f);
			}
				

			if(this.animation["c_rtl"])
			{
				this.animation["c_rtl"].speed=Random.Range(0.9f,1.1f);
			}
				
			this.audio.Play();
			this.animation.Play();

		}
		StartCoroutine("_play");
	}
}
