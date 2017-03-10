using UnityEngine;
using System.Collections.Generic;
using System;


/*TODO implement a timer system. a class called TimedEffect(event, turnsleft), 
 * list in player of TimedEffect
 *every turn, run through each effect, turnsleft --. on 0 do EndEffect event.
 */
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
	//+ x% of weapon damage per point to attack
	public int Strength{ get; protected set;}
	// + x health per point
	public int Constitution{ get; protected set;}
	// + x* to crit rate per point (base 10%)
	public int Agility{ get; protected set;}
	// + x to mana, +x% to spell amplification per point
	public int Intelligence{ get; protected set;}


	//Constants

	//% increase damage for spell per intelligence point
	const float amplifier_Spell = 10;
	//% chance for crit per agility point
	const float amplifier_Crit = 10;
	//Added damage% of weapon damage per strength point
	const float amplifier_Damage = 30;


	//ChangeSTAT should be used only internally as part of the public function BuffStat

	void ChangeConstitution(int previousConstitution, int newConstituion){
		Constitution = newConstituion;
		int dif = newConstituion - previousConstitution;
		Health += dif * 1;// * SOME MODIFIER
		maxHealth += dif * 1;
		//throw new NotImplementedException ("NEEDS REAL TESTING");

	}

	void ChangeIntelligence(int previousIntelligence, int newIntelligence){
		Intelligence = newIntelligence;
		int dif = newIntelligence - previousIntelligence;
		Mana += dif * 1;// * SOME MODIFIER
		MaxMana += dif * 1;
		//throw new NotImplementedException ("NEEDS REAL TESTING");
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


	public abstract void Attack (ITargetable e);

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
				ChangeConstitution (Constitution, Constitution + amount);
				break;
			}
		case AttributeType.Agility: {
				Agility += amount;
				break;
			}
		case AttributeType.Intelligence: {
				//Re-Calculate Mana
				ChangeIntelligence (Intelligence, Intelligence + amount);
				break;
			}
		}
	}


	public delegate void DeathEventHandler();
	public event DeathEventHandler OnDie;
}
