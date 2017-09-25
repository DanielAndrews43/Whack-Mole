using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour {

	private int state;
	private SpriteRenderer sr;
	public GameObject gm;
	private GameScript gs;
	public Sprite peeled;
	public Sprite unpeeled;

	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = -1;
		gm = GameObject.Find ("GameManager");
		gs = gm.GetComponent<GameScript> ();
		state = 0;
		sr = GetComponentInChildren<SpriteRenderer> ();
	}
	
	public bool ChangeStateToPeeled() {
		if (state == 1) {
			return false;
		}

		startTime = 1.5f;
		state = 1;
		sr.sprite = peeled;

		return true;
	}

	void ChangeStateToUnpeeled() {
		sr.sprite = unpeeled;
		state = 0;
		startTime = -1;
	}

	void Update() {
		if (startTime > -1) {
			startTime -= Time.deltaTime;
			if (startTime < 0) {
				gs.LoseLife ();
				ChangeStateToUnpeeled ();
			}
		}
	}

	void OnMouseDown() {
		if (state == 0) {
			gs.LoseLife ();
		} else if (state == 1) {
			gs.AddPoints ();
			ChangeStateToUnpeeled ();
		}
	}
}
