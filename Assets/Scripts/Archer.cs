using UnityEngine;
using System.Collections;

public class Archer : Character {

	public Transform Player;
	public Rigidbody Arrow;
	public float ArrowSpeed;
	public int DetectionDistance = 10;
	public int MinimumDistance = 7;

	void Update () 
	{
		transform.LookAt (Player);

		// if Player is in detection area
		if (Vector3.Distance (transform.position, Player.position) <= DetectionDistance) {

			if (Vector3.Distance (transform.position, Player.position) <= MinimumDistance) {
				this.EndWalkingAction ();
				//this.Attack ();
			} else {
				this.EndAttackingAction();
				this.Move ();
			}

		} else {
			this.animator.SetBool ("is_Walking", false);
		}

	}

	protected override void Attack(){
		this.animator.SetBool ("is_Attacking", true);
	}

	protected void FireArrow(){
		Rigidbody newArrow = Instantiate (Arrow, transform.position, transform.rotation) as Rigidbody;
		newArrow.transform.LookAt (Player);
		newArrow.AddForce (transform.forward * this.ArrowSpeed);
	}

	protected void EndAttackingAction(){
		this.animator.SetBool ("is_Attacking", false);
	}





}


