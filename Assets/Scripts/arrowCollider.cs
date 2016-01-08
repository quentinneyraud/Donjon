using UnityEngine;
using System.Collections;

public class arrowCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTriggerEnter(Collision coll){
		Debug.Log ("collision");
	}
}
