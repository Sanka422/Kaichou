//base class of attribute


using UnityEngine;
using System.Collections;

public class Attribute {
	//prime attribute
	private int strenght; //strenght
	private int dexterity; //dexterity
	private int intelligence; //intelligence
	private int volition; //volition

	//addition attribute
	private float speed;
	private int hp;

	//defence
	private int Defence;
	private int Resitence;

	//attack
	private int phyAttack;
	private int attackSpeed;
	private int mentalAttack;
	private int elementalAttack;

	public Attribute(){
		strenght = 10;
		dexterity = 10;
		intelligence = 10;
		volition = 10;
	}
	public float getSpeed(){
		return speed;
	}

	public void setSpeed(float speed){
		this.speed = speed;
	}

	public int getStrength(){
		return strenght;
	}

	public int getIntelligence(){
		return intelligence;
	}

	public int getDexterity(){
		return dexterity;
	}

	public int getColition(){
		return volition;
	}
}
