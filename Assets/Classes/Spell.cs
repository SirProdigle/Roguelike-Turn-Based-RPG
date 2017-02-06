using System.Collections.Generic;
using UnityEngine;

public class Spell
{

	public string Name { get; set; }
	public int MinPotency{ get; set; }
	public int MaxPotency{ get; set; }
	public Sprite Icon { get; set; }
	public TimedEffect TimedSpellEffect;
	enum DamageType
	{
		Fire,
		Electric,
		Water,
		Earth,
		Pure
	}

	// Constructors
	public Spell (string name, int minpotency)
	{
		Name = name;
		MaxPotency = minpotency;
		MinPotency = minpotency;
	}

	public Spell (string name, int minpotency, int maxpotency)
	{
		Name = name;
		MaxPotency = maxpotency;
		MinPotency = minpotency;
	}


	//Delegate/Events
	public delegate void OnCastEvent (Spell thisSpell, ITargetable caster, List<ITargetable> enemies);
	public event OnCastEvent OnCast;

	//Call Event
	//Single target gets converted to list
	public void Cast (ITargetable caster, ITargetable enemy)
	{
		OnCast (this, caster, new List<ITargetable>{ enemy });
		if(TimedSpellEffect != null){
			enemy.TimedEffects.Add (TimedSpellEffect);
		}
	}

	public void Cast (ITargetable caster, List<ITargetable> enemies)
	{
		OnCast (this, caster, enemies);
		foreach(ITargetable e in enemies)
			if(TimedSpellEffect != null){
				e.TimedEffects.Add (TimedSpellEffect);
			}
			
	}


}
