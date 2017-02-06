using UnityEngine;
using System.Collections.Generic;

public class Player : Character{
	public Inventory Bag{ get; set;}
	public Equipment Equipment{ get; set;}
	public ITargetable target;

	public Player(){
		
	}
	// Use this for initialization
	 void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	public override void TakeTurn ()
	{
		
	}

	public void Attack(ITargetable e){
		Weapon mywep = Equipment.EquippedWeapon;
		// Do damage
		//Apply our weapons effect
		mywep.ApplyAttackEffect (e as Enemy);

	}


}
