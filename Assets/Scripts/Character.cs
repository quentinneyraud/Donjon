using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {


	// Common
	protected Animator animator;


	// States

	// Properties
	public int life;
	public float speed;


	virtual protected void Start () {
		this.animator = GetComponent<Animator> ();
	}


	virtual protected void Move (){
		this.animator.SetBool ("is_Walking", true);
		transform.position += transform.forward * this.speed * Time.deltaTime;
	}

	abstract protected void Attack ();

	virtual protected void Dead (){
		this.animator.SetBool ("is_Dead", true);
	}

	virtual protected void getDamage (){
		this.life--;
		if (this.life == 0) {
			this.Dead ();
		}
	}

	virtual protected void EndWalkingAction(){
		this.animator.SetBool ("is_Walking", false);
	}
		
}
