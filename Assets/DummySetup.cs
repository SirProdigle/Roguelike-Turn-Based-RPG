using UnityEngine;
using System.Collections.Generic;

public class DummySetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Player me = new Player ();
		me.Spells = new List<Spell> ();
		me.Bag = new Inventory ();
		me.Bag.Items = new List<Item> ();
		me.Equipment = new Equipment ();
		me.Equipment.Owner = me;
		me.Equipment.EquipmentList = new Dictionary<EquipItem.EquipSlot, EquipItem> ();
		Enemy enemy = new Enemy ();


		Spell Fireball1 = new Spell ("Fireball", 10);
		Fireball1.OnCast += (t, p, e) => {
			foreach(Enemy en in e)
				en.TakeDamage(t.MaxPotency);
		};

		me.Spells.Add (Fireball1);
		Item junk = new Item ("Junk", "...", null);
		me.Bag.AddItem (junk);
		ConsumableItem pot = new ConsumableItem ("Pot", "...", null);
		me.Bag.AddItem (pot);
		EquipItem Helmet = new EquipItem ("Helm", "...", null, EquipItem.EquipSlot.Head);
		Helmet.OnEquip += (c, i) => {c.BuffStat(Character.AttributeType.Constitution,5);};
		Helmet.OnUnequip += (c, i) => {c.BuffStat(Character.AttributeType.Constitution,-5);};
		//me.Bag.AddItem (Helmet);
		me.Equipment.AddItem (Helmet);
		Weapon sword = new Weapon ("Sword", "...", null, 10, 15);
		sword.OnAttackEffect += (w, e) => {Debug.Log("OnAttackEffect By Weapon");};
		sword.TimedWeaponEffect = new TimedEffect ();
		sword.TimedWeaponEffect.OnTick += (c) => {
			Debug.Log ("Tick effect by weapon");
		};
		me.Bag.AddItem (sword);
		me.Equipment.AddItem (sword);
		me.target = enemy;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
