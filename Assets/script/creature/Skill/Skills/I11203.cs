using UnityEngine;
using System.Collections;

public class I11203 : ISkill {
	public void skillCreate (SkillS skill){
		skill.maxLevel = 5;
		skill.name = "扇域";
		skill.domain = SkillS.Domain.Elemental;
		skill.treeName = "Incantation";
		skill.shortDescribe = "符咒命中目标后会对以目标身后90度距离3内的敌人造成伤害\n";
		skill.FullDescribe = "符咒命中目标后会对以目标身后90度距离3内的敌人造成伤害\n";
		skill.active = true;
		skill.moveCast = false;
		skill.setCastTime(1f);
		skill.cooldown = 0f;
		skill.rumExpand = 3;
		skill.RequiredDex = 12;
		skill.RequiredInt = 14;
		skill.rumValInt = 3; //fan arc radius
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
		creature.incantation.fanRadius += skill.rumValInt;
	}

	public bool newLevelValid(SkillS skill, Creature creature){
		if (skill.currentLevel == 0) {
			if (creature.getAttribute ().getIntelligence () >= 14 &&
				creature.getAttribute ().getDexterity () >= 12) {
				return true;
			}
		} else {
			if (creature.getAttribute ().getIntelligence () >= 14 + skill.currentLevel * 4 &&
				creature.getAttribute ().getDexterity () >= 12 + skill.currentLevel * 5) {
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
