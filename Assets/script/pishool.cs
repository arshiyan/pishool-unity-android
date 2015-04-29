using UnityEngine;
using System.Collections;

public class pishool : MonoBehaviour {

	Animator _animator;

	int randomNO;

	public bool can_play_anmin=true;
	// Use this for initialization
	void Start () {
		StartCoroutine("do_act");
		_animator=this.GetComponent<Animator>();
	}


	IEnumerator do_act()
	{
		if(can_play_anmin)
		{
			yield return new WaitForSeconds(5f);
			randomNO = Random.Range(3,1000);
			if ( (randomNO % 2) == 0)
			{
				StartCoroutine("look_around");
			}
			else if( (randomNO % 3) == 0)
			{
				StartCoroutine("sound");
			}

		}
		StartCoroutine("do_act");
		
	}

	IEnumerator look_around()
	{
		_animator.SetBool("fear",true);
		yield return new WaitForSeconds(3f);	
		_animator.SetBool("fear",false);
	}

	IEnumerator sound()
	{
		_animator.SetBool("mioo",true);
		audio.Play();
		yield return new WaitForSeconds(0.25f);	
		_animator.SetBool("mioo",false);
	
	}

}
