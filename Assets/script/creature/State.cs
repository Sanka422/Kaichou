using UnityEngine;
using System.Collections;

public class State{
	//state types
	public enum Movement {Moveing, Stationary}
	public enum Actions {Attacking,Skilling, Casting, EndCasting,Null,Recover, MoveCast,TargetEnemy,TargetFriend,TargetGround}
	public enum HP {Green,Yellow,Red,Dead}

	//state items
	private Movement movement;
	private Actions action;
	private HP hp;


	//constructor
	public State(){
		movement = Movement.Stationary;
		action = Actions.Null;	
		hp = HP.Green;
	}

	/*public void setAction(Action action){
		this.action = action;
	}*/

	public Actions Action {
		get {return action;}
		set {this.action = value;}
	}

	public void setMovement(Movement movement){
		this.movement = movement;
	}

	public Movement getMovement(){
		return movement;
	}
}
