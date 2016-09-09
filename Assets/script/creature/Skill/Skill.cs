using UnityEngine;
using System.Collections;


using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;


public class Skill {

	//总览
	public enum Domain {Elemental, Physical, Spiritual};

	protected string id;
	protected Domain domain;
	protected string treeName;
	protected string skillName;
	protected string shortDescribe;
	protected string FullDescribe;

	protected bool active;
	protected bool instance;

	//casting 
	protected float castTime;
	protected float cooldown;

	//incantation
	protected int rumExpand;

	//条件
	protected int[] preRequire;
	protected int requiredStr;
	protected int requiredDex;
	protected int requiredInt;
	protected int requiredVil;
	protected int skillPointExpand;


	//升级
	protected int maxLevel;
	protected int requiredStrIncrement;
	protected int requiredDexIncrement;
	protected int requiredIntIncrement;
	protected int requiredVilIncrement;
	protected int pointRequireIncrement;


	//init
	public Skill(string id,int level){
		//Debug.Log (id + "readed");
		XmlDocument doc = new XmlDocument();
		XmlReaderSettings set = new XmlReaderSettings();
		set.IgnoreComments = true;//这个设置是忽略xml注释文档的影响。有时候注释会影响到xml的读取
		doc.Load("xml/skills.xml");
		XmlNodeList xmlNodeList = doc.SelectSingleNode("GameObject").ChildNodes;
		XmlElement elem = doc.GetElementById (id);
		Debug.Log (elem.InnerXml);
		this.id = id;
		skillName = elem.GetElementsByTagName ("name") [0].InnerText;
		switch (elem.GetElementsByTagName ("domain") [0].InnerText) {
		case "Elemental":
			domain = Domain.Elemental;
			break;
		case "Physical":
			domain = Domain.Physical;
			break;
		case "Spiritual":
			domain = Domain.Spiritual;
			break;
		default:
			Debug.Log ("Domain reading error "+id+" "+skillName);
			break;
		}
		treeName = elem.GetElementsByTagName ("tree") [0].InnerText;
		shortDescribe = elem.GetElementsByTagName ("describe") [0].InnerText;
		FullDescribe = elem.GetElementsByTagName ("fullDescribe") [0].InnerText;
		if (elem.GetElementsByTagName ("active") [0].InnerText.Equals ("Yes")) {
			active = true;
		} else {
			active = false;	
		}
		castTime = float.Parse(elem.GetElementsByTagName ("castTime") [0].InnerText);
		cooldown = float.Parse(elem.GetElementsByTagName ("coolDown") [0].InnerText);
		rumExpand = int.Parse(elem.GetElementsByTagName ("rumExpand") [0].InnerText);
		requiredStr = int.Parse (elem.GetElementsByTagName("activeRequireStr")[0].InnerText);
		requiredDex = int.Parse (elem.GetElementsByTagName("activeRequireDex")[0].InnerText);
		requiredInt = int.Parse (elem.GetElementsByTagName("activeRequireInt")[0].InnerText);
		requiredVil = int.Parse (elem.GetElementsByTagName("activeRequireVil")[0].InnerText);
	}

/*	public Skill(string id, int level):this(id){
		Debug.Log (id + " " + level);
	}*/

	public string getid(){
		return id;
	}

	public bool getActive(){
		return active;
	}

	public bool getInstance(){
		return instance;
	}

	//return true is the skill is successfully cast
	public bool cast(Creature creature){
		return false;
		//effects
	}

	public void createIncantation(Creature creature){
		creature.initIncantation ();
	}


}
