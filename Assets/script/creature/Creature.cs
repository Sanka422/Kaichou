//extend monobehaviour
//base class of all creature


using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour {
	public bool controlable;

	public enum Hostile {
		Friendly,
		Hostile
	}
	//if will attack player
	protected Attribute attribute;
	protected Hostile hostile;
	protected State state;
	protected Buff buff;
	protected SkillList skillList;
	protected SkillS castSkill;
	//skill is casting

	//for move creature
	protected Vector3 TargetLocation;

	public Incantation incantation;
	public Incantation incantationSa;
	// origin sample of the incantation to be clone

	protected IEnumerator skillCoroutine;

	/** targeting**/
	public Creature targetEnemy;


	protected void init () {
		attribute = new Attribute ();
		hostile = new Hostile ();
		state = new State ();
		buff = new Buff ();
		skillList = new SkillList ();
	}

	protected void move () {
		//transform.rotation.z = 0f;
		if (state.getMovement () == State.Movement.Moveing) {
			if (state.Action == State.Actions.Casting) {
				StopCoroutine (skillCoroutine);
				state.Action = State.Actions.Null;
			}
			transform.position = Vector3.MoveTowards (transform.position, TargetLocation, attribute.getSpeed () * Time.deltaTime);
		}
		if (Vector3.Distance (transform.position, TargetLocation) <= 0.00001f) {
			state.setMovement (State.Movement.Stationary);
		}
	}

	/// <summary>
	/// sub cast
	/// </summary>

	public void initIncantation () {
		if (incantation != null) {
			Incantation old = incantation;
			incantation = (Incantation)Instantiate (incantationSa, transform.position, transform.rotation);
			Destroy (old.gameObject);
		} else {
			incantation = (Incantation)Instantiate (incantationSa, transform.position, transform.rotation);
		}
		incantation.initIncantation (this);
		incantation.transform.position = this.transform.position + this.transform.forward * 0.5f;
	}

	/// <summary>
	/// start cast time
	/// </summary>
	/// <param name="skill">Skill.</param>
	public void setCastStill (SkillS skill) {
		this.castSkill = skill;
		skillCoroutine = activeCastSkill (skill);
		StartCoroutine (skillCoroutine);
		//StopCoroutine (skillCoroutine);
	}

	/// <summary>
	/// Actives the cast skill. after success cast time
	/// </summary>
	/// <returns>The cast skill.</returns>
	/// <param name="skill">Skill.</param>
	IEnumerator activeCastSkill (SkillS skill) {
		//Debug.Log ("activeCast");
		yield return new WaitForSeconds (skill.getCastTime ());	
		skillList.activeSkill (skill, this);
	}

	public void setState (State.Actions action) {
		state.Action = action;
	}

	public Attribute getAttribute () {
		return attribute;
	}

	/*public void castIncantation(Creature creature){
		//draw arrow or target
		//wait till cancel or active 
		//active
		//state change to Target
		getEnemyTarget()
		incantation.cast();

	}*/

	public void locateEnemyTarget (SkillS skill) {
		this.castSkill = skill;
		skillCoroutine = targetingEnemy (skill);
		StartCoroutine (skillCoroutine);
	}

	IEnumerator targetingEnemy (SkillS skill) {
		state.Action = State.Actions.TargetEnemy;
		targetEnemy = null;
		Debug.Log ("targetEnemy");
		yield return new WaitUntil (() => getTarget ());
		Debug.Log ("targetEnemy yield");
		state.Action = State.Actions.Null;
		skillList.activeSkill (skill, this);
	}

	private bool getTarget () {
		if (targetEnemy != null) {
			return true;
		} else {
			return false;
		}
	}
}
