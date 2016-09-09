using UnityEngine;
using System.Collections;

public class I11102 : ISkill {
	public void skillCreate (SkillS skill){
		skill.maxLevel = 1;
		skill.name = "释放";
		skill.domain = SkillS.Domain.Elemental;
		skill.treeName = "Incantation";
		skill.shortDescribe = "释放符咒";
		skill.FullDescribe = "释放符咒";
		skill.active = true;
		skill.moveCast = false;
		skill.setCastTime(0f);
		skill.cooldown = 0f;
		//Debug.Log ("I11101 create success");
	}


	public void castSkill(SkillS skill, Creature creature){
		creature.locateEnemyTarget(skill);
	}

	public void activeSkill(SkillS skill, Creature creature){
		creature.incantation.cast (creature.targetEnemy);
		creature.incantation = null;
	}

	public bool newLevelValid(SkillS skill, Creature creature){
		return false;
	}
	public void levelUpSkill(SkillS skill){}


}
