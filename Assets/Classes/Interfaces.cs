using UnityEngine;
using System.Collections.Generic;
using System;



public interface ITargetable{
	int Health{ get;}
	int maxHealth{ get;}
	int Mana{ get;}
	void TakeDamage (int damage);
	void RestoreHealth (int healAmount);
	void BuffStat (Character.AttributeType attribute,int amount);
	List<TimedEffect> TimedEffects {get;}
}

public interface ITurnActable{
	void TakeTurn();
}
	
