using UnityEngine;
using System.Collections;

public class monster_behavior : MonoBehaviour {


	public Transform _pishool;
	public Transform _transform;
	public float speed=4f;
	public bool canMove=false;
	public bool moveDirection=false;
	public Vector2 pishoolPos;
	public Vector2 parentPos;
	public int power=0;

	public AudioClip attack;
	public AudioClip moveback;

	public bool canTakePishool=true;

	public bool takenPishool=false;

	public bool active=false;
	private Transform holder;
	private Transform sound_place;
	Vector3 thePosition;
	// Use this for initialization
	void Start () {

		_transform=transform;
		_pishool=(Transform)GameObject.FindGameObjectWithTag("pishool").transform;
		pishoolPos=new Vector2(_pishool.position.x,_pishool.position.y-5f);
		holder = _transform.FindChild("body").FindChild("r_arm").FindChild("holder");
		sound_place = GameObject.FindWithTag("sound_place").transform;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		 if(!canMove) return;
		if(!_pishool) 
		{
			power = 0;
			canTakePishool = false;
		}

		//give_pishool();



		if(!moveDirection)
		{
			move_forward();
		}
		else
		{
			move_backward();
		}

		if(takenPishool)
		{
			call_monster();
		}

		if(level.stop)
		{
			call_monster();
		}


	}

	void move_forward()
	{
		//_transform.position = Vector2.Lerp(_transform.position,pishoolPos,level.speed*Time.deltaTime);

		thePosition = _transform.TransformPoint(-pishoolPos);
		_transform.Translate(-thePosition*level.speed*Time.deltaTime);

		//_transform.Translate((_transform.position-_pishool.position) * Time.deltaTime*level.speed);

	    //audio.PlayOneShot(attack);

		//AudioSource.PlayClipAtPoint(attack,sound_place.position);

	}

	void move_backward()
	{

		thePosition = _transform.TransformPoint(-pishoolPos);
		_transform.Translate(thePosition*level.speed*Time.deltaTime);

		//_transform.position = Vector2.Lerp(_transform.position,parentPos,level.speed*Time.deltaTime);
		//_transform.Translate((_transform.position-_pishool.position) * Time.deltaTime*level.speed);

		//audio.PlayOneShot(moveback);


		//AudioSource.PlayClipAtPoint(moveback,sound_place.position);

		if(power <= 0)
		{
			this.GetComponent<Animator>().SetBool("damaged",true);

		}
		backward_setup();
	}

	void give_pishool()
	{
		if(canTakePishool)
		{
			//if(Vector2.Distance(_transform.position,pishoolPos) <= 10f)
			StartCoroutine("pishool_sound");	
			StartCoroutine("wait_for");	

			this.GetComponent<Animator>().SetBool("take",true);
			//_pishool.transform.parent=_transform.FindChild("body").FindChild("r_arm").FindChild("holder").transform;
			
			_pishool.transform.parent=holder;
			this.GetComponent<Animator>().enabled=false;
			_pishool.localPosition=Vector3.zero;
			//_pishool.collider2D.tag="Untagged";	
			
			_pishool.GetComponent<BoxCollider2D>().enabled=false;
			moveDirection=true;
			takenPishool=true;
			level.fine=true;
			 call_monster();
					
		}
	}
void OnTriggerEnter2D(Collider2D other)
{
	if(other.collider2D.tag=="pishool")
	{
			this.give_pishool();
	}
}
	void backward_setup()
	{
		if(Vector2.Distance(_transform.position,parentPos) <= 5f)
		{


			gameObject.SetActive(false);

			active=false;
			canMove = false;
			moveDirection = false;
			canTakePishool = true;
			//enemy_maker.free_ready = true;

		}

	}

	public void add_dammage()
	{
		if(takenPishool) return;
		power--; 

		if(power <= 0)
		{
			canTakePishool=false;
			moveDirection=true;
		}
	}


	void call_monster()
	{
		foreach(GameObject mon in GameObject.FindGameObjectsWithTag("monster"))
		{

			if(!mon.transform.GetComponent<monster_behavior>()) continue;

			if((mon.transform.GetComponent<monster_behavior>().active) && (!mon.transform.GetComponent<monster_behavior>().takenPishool))
			{
				mon.transform.GetComponent<monster_behavior>().power = 0;
				mon.transform.GetComponent<monster_behavior>().moveDirection=true;


				//mon.transform.GetComponent<monster_behavior>().active=false;

			}
		}
	}

	void reset_can_take_pishool()
	{
		foreach(GameObject mon in GameObject.FindGameObjectsWithTag("monster"))
		{
			if(mon.transform.GetComponent<monster_behavior>())
			{
				mon.transform.GetComponent<monster_behavior>().takenPishool = false;
			}
		}
	}


	IEnumerator wait_for()
	{
	
		yield return new WaitForSeconds(2f);	

		level.stop=true;
		//reset_can_take_pishool();
	}

	IEnumerator pishool_sound()
	{
		_pishool.transform.GetComponent<Animator>().SetBool("mioo",true);
		_pishool.transform.audio.Play();

		yield return new WaitForSeconds(0.25f);	
		_pishool.transform.GetComponent<Animator>().SetBool("mioo",false);
		
	}
}
