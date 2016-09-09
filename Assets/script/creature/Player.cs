//extend Creature
//player behaviour
//move action with right botton
//player unique in each scene


using UnityEngine;
using System.Collections;

//import script.Skill.Skill.cs;

public class Player : Creature {

	// Use this for initialization
	void Start () {
		//init player states etc
		init ();
		hostile = Hostile.Friendly;
		attribute.setSpeed (6f);
		skillList.getSkillList ();
		//skillList.castSkill ("I11101",this);
	}
	
	// Update is called once per frame
	void Update () {
		mouseAction ();
		move ();
		CAction ();
	}

	private void mouseAction(){	
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (state.Action == State.Actions.TargetEnemy) {
			if (Input.GetMouseButtonDown (0)) {
				Physics.Raycast (ray, out hit);
				if (hit.collider.tag.Equals ("Enemy")) {
					targetEnemy = (Creature)hit.collider.GetComponent<Mobs> ();
				}
			} else if (Input.GetMouseButtonDown (1)) {
				state.Action = State.Actions.Null;
				StopCoroutine (skillCoroutine);
				Debug.Log ("stop");
			}
		} else {
			if (Input.GetMouseButtonDown (1)) {
				Physics.Raycast (ray, out hit);
				if (hit.collider.tag.Equals ("Field")) {
					TargetLocation = hit.point;
					TargetLocation.y = 0f;
					state.setMovement (State.Movement.Moveing);
				}
			}
		}
	}

	private void CAction(){
		
		if (Input.GetKeyDown ("1")) {
			skillList.castSkill ("I11101", this);
		}else if(Input.GetKeyDown("2")) {
			skillList.castSkill ("I11102", this);
		}else if(Input.GetKeyDown("3")) {
			skillList.castSkill ("I11201", this);
		}else if(Input.GetKeyDown("4")) {
			skillList.castSkill ("I11202", this);
		}else if(Input.GetKeyDown("5")) {
			skillList.castSkill ("I11203", this);
		}else if(Input.GetKeyDown("6")) {
			skillList.castSkill ("I11301", this);
		}else if(Input.GetKeyDown("7")) {
			skillList.castSkill ("I11302", this);
		}else if(Input.GetKeyDown("8")) {
			//skillList.castSkill ("I11303", this);
		}
	}
		
}
