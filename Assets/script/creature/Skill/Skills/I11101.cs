using UnityEngine;
using System.Collections;

public class I11101:ISkill{
	public void skillCreate (SkillS skill){
		skill.maxLevel = 3;
		skill.name = "生成";
		skill.domain = SkillS.Domain.Elemental;
		skill.treeName = "Incantation";
		skill.shortDescribe = "制造符咒";
		skill.FullDescribe = "制造符咒";
		skill.active = true;
		skill.moveCast = false;
		skill.setCastTime(1f);
		skill.cooldown = 0f;
		skill.RequiredInt = 10;
		skill.rumValInt = 30;	//rum base damage
		skill.rumValFloat = 8;	//cast Range
		//Debug.Log ("I11101 create success");
	}

	public void castSkill(SkillS skill, Creature creature){
		//Debug.Log ("casting"+skill.name+" "+ skill.getCastTime());
		if (skill.getCastTime() != 0) {
			if (skill.moveCast == false) { 
				creature.setState (State.Actions.Casting);
			} else {
				creature.setState (State.Actions.MoveCast);
			}
			Debug.Log ("setC");
			creature.setCastStill (skill);
		}
	}

	public void activeSkill(SkillS skill, Creature creature){
		creature.initIncantation ();
		creature.incantation.elementDamage += skill.rumValInt;
		creature.incantation.castRange += skill.rumValFloat;
	}

	public bool newLevelValid(SkillS skill, Creature creature){
		if (skill.currentLevel == 0) {
			if (creature.getAttribute ().getIntelligence () >= 10) {
				return true;
			}
		} else {
			if (creature.getAttribute ().getIntelligence () >= 10 + skill.currentLevel * 4) {
				return true;
			}
		}
		return false;
	}
	public void levelUpSkill(SkillS skill){
		skill.currentLevel++;
		skill.increaseDecreasedCastTimePercent (0.5f);
	}


}