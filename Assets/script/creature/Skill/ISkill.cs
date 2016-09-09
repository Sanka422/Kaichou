using UnityEngine;
using System.Collections;

public interface ISkill{
	void skillCreate (SkillS skill);
	void castSkill (SkillS skill, Creature creature);
	void activeSkill (SkillS skill, Creature creature);
	void levelUpSkill (SkillS skill);
}

