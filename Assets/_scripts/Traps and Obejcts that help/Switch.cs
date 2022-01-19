using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Switch : MonoBehaviour {

	
	public Sprite on;
	public Sprite off;
	private bool isOn;
	public SwitchController switchController;
	private bool setOn;
	private bool setOff;
	private Animator animator;
	private GameObject child;
	private SpriteRenderer spriteR;
	
	
	// Use this for initialization
	void Start () {
		child = transform.GetChild (0).gameObject;
		spriteR = child.GetComponent<SpriteRenderer> ();
		setOn = false;
		setOff = false;
		animator = child.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		isOn = SwitchController.instance.isOn;

		if (!setOn) {
			if (isOn) {
				spriteR.sprite = @on;
				setOn = true;
				setOff = false;
			}
		} if (!setOff) {
			if (!isOn) {
				spriteR.sprite = off;
				setOff = true;
				setOn = false;
			}
		}

	}

	void OnCollisionEnter2D(Collision2D col) {
		
		if (col.collider.bounds.max.y < transform.position.y
			&& col.collider.bounds.min.x < transform.position.x + 0.5f
			&& col.collider.bounds.max.x > transform.position.x -0.5f
			&& col.collider.tag == "Player") {
			switchController.FlipSwitch ();
			animator.Play ("Switch");
		}
	}
}