using UnityEngine;
using System.Collections.Generic;
using System;

public class Enemy : Character {
	public Inventory Loot {get;protected set;}
	int minBaseDamage;
	int maxBaseDamage;
	TimedEffect TimedDamageEffect;
	event  Action<ITargetable > OnAttack;
	// Use this for initialization
	 void Start () {
	
	}
	
	// Update is called once per frame
	 void Update () {
	
	}

	public Enemy(int hp, int mp, int str, int con, int agi, int inteli,int minBaseDam, int maxBaseDam, bool hasTimedDamageEffect = false){
		Health = hp;
		maxHealth = hp;
		Mana = mp;
		MaxMana = mp;
		Strength = str;
		Constitution = con;
		Agility = agi;
		Intelligence = inteli;
		Spells = new List<Spell> ();
		TimedEffects = new List<TimedEffect> ();
		Loot = new Inventory ();
		minBaseDamage = minBaseDam;
		maxBaseDamage = maxBaseDam;
		if(hasTimedDamageEffect){
			TimedDamageEffect = new TimedEffect ();
		}
	}

	override public void Attack(ITargetable e){
		int damageToApply = UnityEngine.Random.Range (minBaseDamage + Strength, maxBaseDamage + Strength++);
		e.TakeDamage (damageToApply);
		if(OnAttack != null){
			OnAttack (e);
		}
	}

	void ApplyDamageEffect(ITargetable e){
		if(TimedDamageEffect != null){
			e.TimedEffects.Add (TimedDamageEffect);
		}
	}


}
