using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class Character : MonoBehaviour {

	// Common
	protected Animator animator;
	private bool canBeAttacked = true;
	protected ParticleSystem blood;
	private AudioSource soundDeath;

	// Properties
	public int life;
	public float speed;
	public Slider healthBar;


	/*
	 * 
	 * 			Actions
	 * 
	 * */

	// On start
	virtual protected void Start () {
		// Get animator
		this.animator = GetComponent<Animator> ();
		// Get Sound of death
		this.soundDeath = this.GetComponent<AudioSource> ();
		// Get blood particle animation
		foreach (Object obj in  GetComponentsInChildren<ParticleSystem> ()) {
			if (obj.name == "Blood") {
				this.blood = (ParticleSystem) obj;
			}
		}

		if (this.healthBar) {
			// Set healthBar value
			this.healthBar.maxValue = this.life;
			this.healthBar.value = this.life;
		}
	}
		
	// Move character
	virtual protected void Move (){
		// Run animation & translate
		this.animator.SetBool ("is_Walking", true);
		transform.Translate(Vector3.forward * this.speed * Time.deltaTime);
	}

	// Attack action
	abstract protected void Attack ();

	// Launch blood particle animation, death animation & sound of death
	virtual protected void Dead (){
		this.blood.Play ();
		this.blood.enableEmission = true;
		this.soundDeath.Play ();
		this.animator.SetBool ("is_Dead", true);
	}
		
	// When attacked
	virtual public void isAttacked (){
		// only if damage animation is end
		if (this.canBeAttacked) {
			// Remove 1 life
			this.life--;
			if (this.healthBar) {
				this.healthBar.value--;
			}
			if (this.life <= 0) {
				this.Dead ();
			} else {
				// Can't get damage when damage animation is running
				this.getDamage ();
				this.canBeAttacked = false;
			}
		}
	}

	// Launch damage animation
	virtual protected void getDamage(){
		this.animator.SetBool ("is_Attacked", true);
	}

	// Stop walk animation
	virtual protected void StopMove(){
		this.animator.SetBool ("is_Walking", false);
	}

	/*
	 * 
	 * 			Events end
	 * 
	 * */

	// Trigger when damage animation end
	virtual protected void EndIsAttackedAction(){
		this.animator.SetBool ("is_Attacked", false);
		this.canBeAttacked = true;
	}
		
}
