using UnityEngine;
using System.Collections;

public class Hero : Character
{
	// Class properties
	private bool isJumping = false;
	private AudioSource attackSound;

	// Public properties

	// Get attack sound on start
	protected void Start(){
		base.Start ();
		this.attackSound = GetComponents<AudioSource> ()[1];
	}

	// Perform methods & animations on key press
	protected void FixedUpdate(){
		if (Input.GetKey (KeyCode.Z)) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				this.Run ();
			} else {
				this.StopRun ();
				this.Move ();
			}
		} else {
			this.StopMove ();
			this.StopRun ();
		}
		if (Input.GetKey (KeyCode.S)) {
			this.animator.SetBool ("is_Walking", true);
			transform.position -= transform.forward * this.speed * Time.deltaTime;
		}
			
		if (Input.GetKeyDown (KeyCode.Mouse0))
			this.Attack ();
		if(Input.GetKey(KeyCode.Q))
			transform.Rotate (new Vector3 (0, -1.5f, 0));
		if(Input.GetKey(KeyCode.D))
			transform.Rotate (new Vector3 (0, 1.5f, 0));

		if (Input.GetKey (KeyCode.Space))
			this.Jump ();

	}

	/*
	 * 
	 * 			Actions
	 * 
	 * */

	protected void Run(){
		this.animator.SetBool ("is_Running", true);
		transform.position += transform.forward * this.speed * 2 * Time.deltaTime;
	}
		
	protected void StopRun(){
		this.animator.SetBool ("is_Running", false);
	}

	// Jump if hero is not jumping
	protected void Jump (){
		if (!this.isJumping) {
			this.StopMove ();
			this.StopRun ();
			this.animator.SetBool ("is_Jumping", true);
			this.isJumping = true;
		}
	}

	// Play sword sound on attack & animation
	override protected void Attack(){
		this.animator.SetInteger ("AttackType", Random.Range (1, 4));
	}

	protected void playStormSound(){
		this.attackSound.Play ();	
	}

	/*
	 * 
	 * 			Events end
	 * 
	 * */

	// When attack animation end
	protected void EndAttackingAction(){
		this.animator.SetInteger ("AttackType", 0);
	}

	// When dead animation end
	public void EndDeadAction(){
		Application.LoadLevel (0);
	}

	// When jump aimation end
	protected void EndJumpingAction(){
		this.animator.SetBool ("is_Jumping", false);
		this.isJumping = false;
	}

	/*
	 * 
	 * 			Triggers
	 * 
	 * */

	// Get attacked if trigger ennemy projectile
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Bullet") {
			this.isAttacked ();
		}
	}

}

