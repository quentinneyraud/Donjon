using UnityEngine;
using System.Collections;

public class Hero : Character
{

	private Rigidbody rigidBody;

	protected bool isJumping = false;

	public float Sensibility = 2f;
	public float JumpForce = 2f;

	protected void FixedUpdate(){
		if (Input.GetKey (KeyCode.Z)) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				this.Run ();
			} else {
				this.EndRunningAction ();
				this.Move ();
			}
		} else {
			this.EndWalkingAction ();
			this.EndRunningAction ();
		}
		if (Input.GetKey (KeyCode.S)) {
			this.animator.SetBool ("is_Walking", true);
			transform.position -= transform.forward * this.speed * Time.deltaTime;
		}
			
		if (Input.GetKeyDown (KeyCode.Mouse0))
			this.Attack ();
		if(Input.GetKey(KeyCode.Q))
			transform.Rotate (new Vector3 (0, -1, 0));
		if(Input.GetKey(KeyCode.D))
			transform.Rotate (new Vector3 (0, 1, 0));

		transform.Rotate (new Vector3 (0, Input.GetAxis ("Mouse X") * this.Sensibility, 0));


		if (Input.GetKey (KeyCode.Space))
			this.Jump ();

	}



	protected void Run(){
		this.animator.SetBool ("is_Running", true);
		transform.position += transform.forward * this.speed * 2 * Time.deltaTime;
	}

	virtual protected void EndRunningAction(){
		this.animator.SetBool ("is_Running", false);
	}

	void onTriggerEnter(Collider coll){
		Debug.Log ("enter");
	}

	virtual protected void Jump (){
		if (!this.isJumping) {
			this.EndWalkingAction ();
			this.EndRunningAction ();
			this.animator.SetBool ("is_Jumping", true);
			this.isJumping = true;
		}
	}

	protected void EndJumpingAction(){
		this.animator.SetBool ("is_Jumping", false);
		this.isJumping = false;
	}




	override protected void Attack(){
		this.animator.SetInteger ("AttackType", Random.Range (1, 4));
	}


	protected void EndAttackingAction(){
		this.animator.SetInteger ("AttackType", 0);
	}

}

