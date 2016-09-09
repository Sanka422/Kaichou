using UnityEngine;
using System.Collections;

public class I11202 : ISkill {
	public void skillCreate (SkillS skill){
		skill.maxLevel = 5;
		skill.name = "贯穿";
		skill.domain = SkillS.Domain.Elemental;
		skill.treeName = "Incantation";
		skill.shortDescribe = "符咒在击中一定数量的敌人后消失";
		skill.FullDescribe = "符咒在击中一定数量的敌人后消失";
		skill.active = true;
		skill.moveCast = false;
		skill.setCastTime(2f);
		skill.cooldown = 0f;
		skill.rumExpand = 3;
		skill.RequiredStr = 15;
		skill.RequiredInt = 15;
		skill.rumValInt = 1;// rum penetration number
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
		creature.incantation.penetration += skill.rumValInt;
	}

	public bool newLevelValid(SkillS skill, Creature creature){
		if (skill.currentLevel == 0) {
			if (creature.getAttribute ().getIntelligence () >= 15 && 
				creature.getAttribute ().getStrength () >= 15) {
				return true;
			}
		} else {
			if (creature.getAttribute ().getIntelligence () >= 15 + skill.currentLevel * 5 &&
				creature.getAttribute ().getStrength () >= 15 + skill.currentLevel * 2) {
				return true;
			}
		}
		return false;
	}
	public void levelUpSkill(SkillS skill){
		skill.currentLevel++;
		skill.rumValInt+=2;
	}

}
