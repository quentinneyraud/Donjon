using UnityEngine;
using System.Collections;

public class CollisionEpee : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider coll){
		Debug.Log ("enter");
		if (coll.gameObject.tag == "Ennemies") {
			coll.transform.Rotate (Vector3.back);
		}
	}

}
