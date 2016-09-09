using UnityEngine;
using System.Collections;

public class Incantation: MonoBehaviour	 {
	public Creature creatrue;
	public float elementDamage;
	public float damageMultiply;
	public float castRange;
	public int penetration;	//贯穿
	public int imageNumber;	//镜像
	public int fanRadius;
	public int circuleRadius;
	public int maxIncan;	//符咒上限
	public int multiCast;
	public float resistanceIgnore;
	public float immovable;
	public float prone;
	public float igniteDamage;
	public float ignaiteLength;
	public float movementDecrease;
	public bool active;//if true, with creature, false cast.

	public Creature targetCreatre;
	public Vector3 forwardDirection;
	public float speed;

	void Start () {
		//init Incantation states etc
		//active = false;
	}
	public void initIncantation(Creature creature){
		//Debug.Log ("init");
		this.creatrue = creature;
		elementDamage = 0;
		damageMultiply = 1;
		castRange = 0;
		penetration = 0;
		imageNumber = 0;
		fanRadius = 0;
		circuleRadius = 0;
		maxIncan = 20;
		multiCast = 0;
		resistanceIgnore = 0;
		immovable = 0;
		prone = 0;
		igniteDamage = 0;
		ignaiteLength = 0;
		movementDecrease = 0;
		active = true;
		speed = 12f;
	}

	void Update(){
		if (active == true) {
			transform.position = creatrue.transform.position + creatrue.transform.forward * 0.5f;
		} else {
			if (targetCreatre != null) {
				transform.position = Vector3.MoveTowards (transform.position, targetCreatre.transform.position, 
					speed * Time.deltaTime);
			}
		}
	}

	public void cast(Creature creature){
		active = false;
		targetCreatre = creature;
	}

	public void discard(){
		if (active == true) {
			//Debug.Log ("A"+this.name);
			DestroyImmediate (this);
		}
	}
}
