using UnityEngine;
using System.Collections;

public class I11301 : ISkill {

	public void skillCreate (SkillS skill){
		skill.maxLevel = 10;
		skill.name = "强击";
		skill.domain = SkillS.Domain.Elemental;
		skill.treeName = "Incantation";
		skill.shortDescribe = "符咒造成的所有元素伤害提高*x倍";
		skill.FullDescribe = "符咒造成的所有元素伤害提高*x倍";
		skill.active = true;
		skill.moveCast = false;
		skill.setCastTime(1f);
		skill.cooldown = 0f;
		skill.rumExpand = 5;
		skill.RequiredInt = 20;
		skill.rumValFloat = 0.5f;	//rum base damage
		//Debug.Log ("I11201 create success");
	}

	public void castSkill(SkillS skill, Creature creature){
		if (skill.getCastTime() != 0) {
			if (skill.moveCast == false) { 
				creature.setState (State.Actions.Casting);
			} else {
				creature.setState (State.Actions.MoveCast);
			}
			creature.setCastStill (skill);
		}
	}

	public void activeSkill(SkillS skill, Creature creature){
		creature.incantation.damageMultiply += skill.rumValFloat;
	}

	public bool newLevelValid(SkillS skill, Creature creature){
		if (skill.currentLevel == 0) {
			if (creature.getAttribute ().getIntelligence () >= 20) {
				return true;
			}
		} else {
			if (creature.getAttribute ().getIntelligence () >= 20 + skill.currentLevel * 9) {
				return true;
			}
		}
		return false;
	}
	public void levelUpSkill(SkillS skill){
		skill.currentLevel++;
		skill.rumValFloat+=0.5f;
	}
}
