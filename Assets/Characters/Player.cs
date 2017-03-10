using UnityEngine;
using System.Collections.Generic;

public class Player : Character{
	public Inventory Bag{ get; set;}
	public Equipment Equipment{ get; set;}
	public ITargetable target;

	public Player(){
		Spells = new List<Spell> ();
		Bag = new Inventory ();
		Equipment = new Equipment (this);
		TimedEffects = new List<TimedEffect> ();
		OnDie += () => {Application.Quit();}; //Remember to fucking change this you scrub
	}
	// Use this for initialization
	 void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
		
		
	override public void Attack(ITargetable e){
		Weapon mywep = Equipment.EquippedWeapon;
		// Do damage
		e.TakeDamage (mywep.GetAttackDamage ());
		//Apply our weapons effect
		mywep.ApplyAttackEffect (e);

	}


}
