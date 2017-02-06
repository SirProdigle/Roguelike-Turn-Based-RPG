using UnityEngine;
using System.Collections.Generic;
using System;


//TODO implement a timer system. a class called TimedEffect(event, turnsleft), list in player of TimedEffect
// every turn, run through each effect, turnsleft --. on 0 do EndEffect event.

public abstract class Character : MonoBehaviour, ITargetable {

	public enum AttributeType{
		Strength,
		Constitution,
		Agility,
		Intelligence
	}


	public int Health{get;protected set;}
	public int maxHealth {get; protected set;}
	public int Mana{get;set;}
	public int MaxMana{get;protected set;}
	public List<Spell> Spells{ get; set;}
	public List<TimedEffect> TimedEffects{get;set;}

	//Attributes
	//+ x weapon damage per point
	public int Strength{ get; protected set;}
	// + x health per point
	public int Constitution{ get; protected set;}
	// + x*10 to crit rate per point (base 10%)
	public int Agility{ get; protected set;}
	// + x to mana, +x% to spell amplification per point
	public int Intelligence{ get; protected set;}


	void CalulcateHealth(int previousConstitution, int newConstituion){
		Constitution = newConstituion;
		int dif = newConstituion - previousConstitution;
		Health += dif * 1;// * SOME MODIFIER
		maxHealth += dif * 1;
		//throw new NotImplementedException ("NEEDS REAL TESTING");

	}

	void CalculateMana(int previousIntelligence, int newIntelligence){
		Intelligence = newIntelligence;
		int dif = newIntelligence - previousIntelligence;
		Mana += dif * 1;// * SOME MODIFIER
		MaxMana += dif * 1;
		//throw new NotImplementedException ("NEEDS REAL TESTING");
	}


	public virtual void TakeTurn(){
		TickTimedEffects ();
		throw new NotImplementedException ("SHOULD HAVE A SUBCLASS IMPLEMENTATION");
		//PlayerPick ();
		//DoAction ();
		//EndTurn ();
		//TODO may want to offload the turn logic into a seperate class
	}

	public void TickTimedEffects(){
		foreach(TimedEffect t in TimedEffects){
			t.Tick (this);
			if(t.TurnsLeft == 0){
				t.EndEffect (this);
				TimedEffects.Remove (t);
			}
		}
	}


	public virtual void TakeDamage(int damage){
		Health -= damage;
		if(Health <= 0){
			OnDie();
		}
	}

	public virtual void RestoreMana(int amount){
		Mana += amount;
		if(Mana > MaxMana){
			Mana = MaxMana;
		}
	}

	public virtual void RestoreHealth(int healAmount){
		Health += healAmount;
		if(Health > maxHealth){
			Health = maxHealth;
		}
	}

	public virtual void BuffStat(AttributeType Attribute, int amount){
		switch (Attribute){
		case AttributeType.Strength: {
				Strength += amount;
				break;
			}
		case AttributeType.Constitution: {
				//Re-Calculate Health
				CalulcateHealth (Constitution, Constitution + amount);
				break;
			}
		case AttributeType.Agility: {
				Agility += amount;
				break;
			}
		case AttributeType.Intelligence: {
				//Re-Calculate Mana
				CalculateMana (Intelligence, Intelligence + amount);
				break;
			}
		}
	}


	public delegate void DeathEventHandler();
	public event DeathEventHandler OnDie;
}
