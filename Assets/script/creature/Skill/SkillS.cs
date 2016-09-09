using UnityEngine;
using System.Collections;

public class SkillS{
	public string id;
	public string name;
	public int currentLevel;
	public int level;
	public int maxLevel;

	public enum Domain {Elemental, Physical, Spiritual};
	public Domain domain;
	public string treeName;
	public string skillName;
	public string shortDescribe;
	public string FullDescribe;

	public bool active;
	public bool moveCast;

	//casting 
	private float castTime;
	private float castTimeDecrease;
	private float castTimeDecreasePercent;
	public float cooldown;

	//incantation
	public int rumExpand;
	public int rumValInt;
	public float rumValFloat;

	//条件
	private int requiredStr;
	private int requiredDex;
	private int requiredInt;
	private int requiredVil;
	public int skillPointExpand;


	public SkillS(string id, int level){
		this.id = id;
		this.level = level;
		this.currentLevel = 0;
		this.castTimeDecrease = 0;
		this.castTimeDecreasePercent = 0;
	}

	public void setCastTime(float time){
		castTime = time;
	}

	public void increaseDecreasedCastTime(float time){
		castTimeDecrease += time;
	}

	public void increaseDecreasedCastTimePercent(float time){
		castTimeDecreasePercent += time;
	}

	public float getCastTime(){
		return Mathf.Max(castTime * (1-castTimeDecreasePercent) - castTimeDecrease,0f);
	}

	public int RequiredStr {
		get { return requiredStr; }
		set { requiredStr = value; }
	}

	public int RequiredDex {
		get { return requiredDex; }
		set { requiredDex = value; }
	}

	public int RequiredInt {
		get { return requiredInt; }
		set { requiredInt = value; }
	}

	public int RequiredVil {
		get { return requiredVil; }
		set { requiredVil = value; }
	}
}
