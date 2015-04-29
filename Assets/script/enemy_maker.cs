using UnityEngine;
using System.Collections;

public class enemy_maker : MonoBehaviour {

	public GameObject enemisDefault; //enemis that we have
	public GameObject[] enemis;// enemis buffer
	public int buffer_enemy=10;
	public static bool free_ready=true;

	Transform _transform;
	//static Vector3 stackPosition = new Vector3(-9999, -9999, -9999);

	public bool move_to_player=false;
	public bool canMake=true;

	public static bool retry=true;

	public float levelTimeRate = 0.5F;
	private float nextTime = 0.0F;
	
	private float limit_force=0;

	private int _rand;
	public AudioClip attack;
	// Use this for initialization
	void Start () 
	{
		_transform=transform;
		init_enemis();
		//StartCoroutine("_next");
		nextTime = Time.time + level.creatore_retry_time;
		limit_force=Time.time+5f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		if ( enemy_maker.retry && !level.stop && !level.fine) 
		{
			if((Time.time > nextTime))
			{
				nextTime = Time.time + level.creatore_retry_time;
				_next();
				limit_force=Time.time+5f;
			}

		}	
		else if(!level.stop && !level.fine && Time.time > limit_force)
		{
			_next();
			limit_force=Time.time+5;
		}


	}
	


	//IEnumerator _next()
	void _next()
	{
		//yield return new WaitForSeconds(level.creatore_retry_time);	

			if((Random.Range(1,100)%3)==0)
			{
				canMake=true;
			}

			if(canMake)
			{
				_rand=Random.Range(0,buffer_enemy);

			    while(enemis[_rand].transform.GetComponent<monster_behavior>().canMove)
				{
					_rand=Random.Range(0,buffer_enemy);
				}

				init_monster(enemis[_rand]);
				canMake=false;
				//free_ready = false;
				
		}


	}

    void init_monster(GameObject _monster)
	{
		_monster.SetActive(true);
		_monster.transform.GetComponent<monster_behavior>().canMove=true;
		_monster.transform.GetComponent<monster_behavior>().canTakePishool=true;
		_monster.transform.GetComponent<monster_behavior>().active=true;
		_monster.transform.GetComponent<monster_behavior>().parentPos=_transform.position;
		_monster.transform.GetComponent<monster_behavior>().power=level.monster_power;
		_monster.transform.GetComponent<monster_behavior>().takenPishool=false;
		//audio.Stop();
		//audio.PlayOneShot(attack);


	}

	void init_enemis()
	{
		enemis=new GameObject[buffer_enemy];
		for(int i=0; i<=buffer_enemy-1;i++)
		{
			enemis[i]=(GameObject)Instantiate(enemisDefault,_transform.position,Quaternion.identity);
			enemis[i].SetActive(false);

		}
	}



}
