using UnityEngine;
using System.Collections;
using System;


public class Item{
	public string Name {get;set;}
	public string Description{get;set;}
	public Sprite Icon{get;set;}

	public Item(string n, string d, Sprite i){
		Name = n;
		Description = d;
		Icon = i;
	}
}

public class EquipItem : Item{


	public EquipItem(string n, string d, Sprite i,EquipSlot eq) : base(n,d,i){
		Slot = eq;
	}

	public enum EquipSlot{
		Head,
		Chest,
		Hands,
		Legs,
		Feet,
		Ring,
		Weapon
	}
	public EquipSlot Slot{ get; set;}


	public delegate void EquipEventHandler(Character c, EquipItem i);
	public  EquipEventHandler OnEquip;
	public  EquipEventHandler OnUnequip;

	public void EquipEffect(Player c){
		OnEquip(c, this);
		throw new NotImplementedException();
	}
	public void UnEquipEffect(Player c){
		OnUnequip(c, this);
		throw new NotImplementedException();
	}
}

public class Weapon: EquipItem{
	public TimedEffect TimedWeaponEffect { get; set;}
	public Weapon(string n, string d, Sprite i, int mindamage, int maxdamage) : base(n,d,i,EquipSlot.Weapon){
		MinDamage = mindamage;
		MaxDamage = maxdamage;
	}

	public int MinDamage{ get; set;}
	public int MaxDamage{ get; set;}

	public delegate void AttackEffectEventHandler(Weapon w, Enemy e);
	public event AttackEffectEventHandler OnAttackEffect;

	public void ApplyAttackEffect(Enemy e){
		OnAttackEffect (this,e);
		if (TimedWeaponEffect != null) {
			e.TimedEffects.Add (TimedWeaponEffect);
		}
		
	}
}

public class ConsumableItem : Item{
	public TimedEffect TimedConsumableEffect { get; set;}
	public delegate void ConsumeEventHandler(Character c, ConsumableItem i);
	public  ConsumeEventHandler OnConsume;

	public ConsumableItem(string n, string d, Sprite i) : base(n,d,i){}

	public void Consume(Player c){
		if(TimedConsumableEffect != null){
			c.TimedEffects.Add (TimedConsumableEffect);		
		}
		//remove from players inventory
		OnConsume (c, this);
		throw new NotImplementedException("Remove from players inventory");
	}
}