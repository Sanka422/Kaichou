using UnityEngine;
using System.Collections;

public class I11201 :ISkill {
	public void skillCreate (SkillS skill){
		skill.maxLevel = 10;
		skill.name = "充能";
		skill.domain = SkillS.Domain.Elemental;
		skill.treeName = "Incantation";
		skill.shortDescribe = "向符咒内灌输元素，提高元素伤害";
		skill.FullDescribe = "向符咒内灌输元素，提高元素伤害";
		skill.active = true;
		skill.moveCast = false;
		skill.setCastTime(1f);
		skill.cooldown = 0f;
		skill.rumExpand = 3;
		skill.RequiredInt = 12;
		skill.rumValInt = 40;	//rum base damage
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
		creature.incantation.elementDamage += skill.rumValInt;
		creature.incantation.maxIncan -= skill.rumExpand;
	}

	public bool newLevelValid(SkillS skill, Creature creature){
		if (skill.currentLevel == 0) {
			if (creature.getAttribute ().getIntelligence () >= 12) {
				return true;
			}
		} else {
			if (creature.getAttribute ().getIntelligence () >= 12 + skill.currentLevel * 7) {
				return true;
			}
		}
		return false;
	}
	public void levelUpSkill(SkillS skill){
		skill.currentLevel++;
		skill.rumValInt+=30;
	}

}
