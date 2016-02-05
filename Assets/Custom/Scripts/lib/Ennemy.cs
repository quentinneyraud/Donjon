using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ennemy : Character {

	protected bool isAttacking = false;

	public Transform Player;
	public GameObject projectile;
	public float delayBetweenAttacks;
	public float projectilSpeed;
	public int DetectionDistance = 10;
	public int MinimumDistance = 7;

	void Update () 
	{
		transform.LookAt (Player);

		// if Player is in detection area
		if (Vector3.Distance (transform.position, Player.position) <= DetectionDistance) {

			if (Vector3.Distance (transform.position, Player.position) <= MinimumDistance) {
				if (!this.isAttacking) {
					this.StopMove ();
					this.Attack ();
				} 
			} else {
				this.EndAttackingAction();
				this.Move ();
			}

		} else {
			this.animator.SetBool ("is_Walking", false);
		}
	}

	protected override void Attack(){
		this.isAttacking = true;
		this.animator.SetBool ("is_Attacking", true);
	}

	virtual protected void EndAttackingAction(){
		this.isAttacking = false;
		this.animator.SetBool ("is_Attacking", false);
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Sword") {
			this.isAttacked ();
		}
	}

	protected void Fire(){
		GameObject bullet = Instantiate (projectile, new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z), this.transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody>().transform.LookAt (new Vector3(Player.transform.position.x, Player.transform.position.y + 0.5f, Player.transform.position.z));
		bullet.GetComponent<Rigidbody>().AddForce (transform.forward * this.projectilSpeed);
		//this.bullets.Add (bullet);
		Destroy (bullet, 10f);
	}

	public void EndDeadAction(){
		/*this.bullets.ForEach (delegate(GameObject bullet){
			if(bullet){
				Destroy(bullet);	
			}
		});*/
		Destroy (this.gameObject, this.blood.duration);
	}

}


