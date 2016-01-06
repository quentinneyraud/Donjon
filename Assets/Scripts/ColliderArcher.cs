using UnityEngine;
using System.Collections;

public class ColliderArcher : MonoBehaviour {

	Animator anim;

	public Transform Player;
	public float MoveSpeed = 2.5f;
	public int DetectionDistance = 10;
	public int MinimumDistance = 5;
	private bool isWalking = false;

	void Start () 
	{
		anim = GetComponent<Animator> ();
	}

	void Update () 
	{
		transform.LookAt(Player);

		// if Player is in detection area
		if (Vector3.Distance (transform.position, Player.position) <= DetectionDistance) {

			if (Vector3.Distance (transform.position, Player.position) <= MinimumDistance) {
				anim.SetBool ("is_Walking", false);
			} else {
				anim.SetBool ("is_Walking", true);
				transform.position += transform.forward * MoveSpeed * Time.deltaTime;
			}

		} else {
			anim.SetBool ("is_Walking", false);
		}

	}

}


