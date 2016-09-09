using UnityEngine;
using System.Collections;

public class Mobs : Creature {


	void Start () {
		init ();
		hostile = Hostile.Hostile;
		attribute.setSpeed (6f);
		//state.setMovement(State.Movement.Moveing);
		//base.attribute.setSpeed (6f);
	}
	
	// Update is called once per frame
	void Update () {
		move ();
		//Debug.Log ("hello "+TargetLocation);
	}
}
