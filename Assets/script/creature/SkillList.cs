using UnityEngine;
using System.Collections;

using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

//assume no skill is active and passive
public class SkillList {
	protected List<SkillS> activeSkillList= new List<SkillS> ();
	protected List<SkillS> passiveSkillList= new List<SkillS> ();
	Dictionary<string, ISkill> skillDic = new Dictionary<string, ISkill>();

	//read xml
	public void getSkillList(){	
		createSkillDic (skillDic);
		XmlDocument doc = new XmlDocument ();
		doc.Load ("player/player.xml");
		XmlNodeList skillListD = doc.GetElementsByTagName ("skill");
		foreach (XmlNode skillXml in  skillListD) {
			string id = skillXml ["id"].InnerText;
			int level = int.Parse (skillXml ["level"].InnerText);
			//Skill tempSkill = new Skill(id,int.Parse(skillXml["level"].InnerText));
			SkillS tempSkill = new SkillS(id,level);
			skillDic [id].skillCreate (tempSkill);

			if (tempSkill.active) {
				activeSkillList.Add (tempSkill);
			} else {
				//Debug.Assert (!(tempSkill.getActive()));
				passiveSkillList.Add (tempSkill);
			}
		}
	}

	//if skill exist, cast if not exist, nothing happened.
	//cast skill -> cast -> instance -> castSuccess 								-> result -> check passive -> end procedure
	//					 -> casttime -> castSuccess -> casttime -> casttime success ->

	//check is any passive effect is triggered
	public void checkPassive (string id){
		//todo
	}

	private void createSkillDic(Dictionary<string,ISkill> skillDic){
		//ISkill i11101 = new I11101();
		skillDic.Add ("I11101", new I11101());
		skillDic.Add ("I11102", new I11102());
		skillDic.Add ("I11201", new I11201());
		skillDic.Add ("I11202", new I11202());
		skillDic.Add ("I11203", new I11203());
		skillDic.Add ("I11301", new I11301());
		//skillDic.Add ("I11302", new I11302());


	}

	public void castSkill(string id, Creature creature){
		//Debug.Log ("is cast");
		foreach (SkillS i in activeSkillList) {
			if ( i.id== id) {
				if (checkValid (i, creature)) {
					skillDic [id].castSkill (i, creature);
				}
			}
		}
	}

	public void activeSkill(SkillS skill, Creature creature){
		foreach (SkillS i in activeSkillList) {
			if ( i.id== skill.id) {
				skillDic [skill.id].activeSkill (i, creature);
			}
		}
	}

	public bool checkValid(SkillS s, Creature creature){
		if ( s.treeName.Equals("Incantation")&& !s.id.Equals("I11101")){
			if (creature.incantation.active == false) {
				return false;
			}
			if(creature.incantation.maxIncan - s.rumExpand < 0){
				return false;
			}
		}
		return true;
	}
}
