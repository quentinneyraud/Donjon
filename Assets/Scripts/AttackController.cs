using UnityEngine;
using System.Collections;

public class AttackController : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			animator.SetInteger ("AttackType", Random.Range(1, 3));
		}
	}

	void EndAttackAnimation() {
		animator.SetInteger ("AttackType", 0);
	}
}
