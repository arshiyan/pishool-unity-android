using UnityEngine;
using System.Collections;

public class destroyGameObject : MonoBehaviour {

	public float destroyTime=0.1f;

	void Start () 
	{
		GameObject.Destroy(this.gameObject,destroyTime);
	}
}
