using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	private int lives;
	private int points;
	private GameObject[] slots;

	// Use this for initialization
	void Start () {
		lives = 3;
		points = 0;
		slots = GameObject.FindGameObjectsWithTag("TapSlot");
		InvokeRepeating ("setToPeeled", 1, 1);
	}

	void setToPeeled () {
		int attempts = 0;
		int index = Random.Range (0, slots.Length);
		while (!slots[index].GetComponent<SlotScript>().ChangeStateToPeeled() && attempts < 10) {
			index = Random.Range (0, slots.Length);
			attempts += 1;
		}
	}
		

	public void LoseLife() {
		lives -= 1;
		//update lives text
		print(lives);
		if (lives == 0) {
			EndGame ();
		}
	}

	private void EndGame() {
		//end the game and show Game Over text
	}

	public void AddPoints() {
		points += 100;
		print (points);
		//update points text;
	}
}
