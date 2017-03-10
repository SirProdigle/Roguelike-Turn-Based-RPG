using UnityEngine;
using System.Collections.Generic;
using System;

public class Equipment {

	public Equipment(Player p){
		Owner = p;
		EquipmentList = new Dictionary<EquipItem.EquipSlot, EquipItem> ();
	}
	public Equipment(){
		EquipmentList = new Dictionary<EquipItem.EquipSlot, EquipItem> ();
	}



	Player Owner{ get; set;}

	public Dictionary<EquipItem.EquipSlot, EquipItem> EquipmentList{ get; set;}
	public Weapon EquippedWeapon{ get;  protected set; }

	public void AddItem(EquipItem i){
		if(EquipmentList.ContainsKey(i.Slot)){
			throw new Exception ("Item in dictionary. Possibly remove what's in their first");
		}
		else{
			EquipmentList.Add (i.Slot,i);
			i.OnEquip (Owner, i);
			throw new Exception ("Remove from player bag");
		}
	}

	public void Remove(EquipItem.EquipSlot slot){
		if(!EquipmentList.ContainsKey(slot)){
			throw new Exception ("No item in that slot");
		}
		else{
			EquipItem itemToRemove;
			EquipmentList.TryGetValue (slot, out itemToRemove);
			EquipmentList.Remove (slot);
			//OWNER.INVENTORY.ADD ITEMTOREMOVE
			throw new NotImplementedException ("Add item to players inventory");
		}
	}


	public void AddItem(Weapon w){
		if (EquippedWeapon != null){
			throw new Exception ("Already a weapon");
		}
		else{
			EquippedWeapon = w;
			if(w.OnEquip != null)
				w.OnEquip (Owner,w);
			throw new Exception ("Remove from player bag");
		}
	}
	public void RemoveWeapon(){
		if(EquippedWeapon == null){
			throw new Exception ("No equipped weapon");
		}
		else{
			EquippedWeapon.OnUnequip (Owner, EquippedWeapon);
			EquippedWeapon = null;
			throw new Exception ("Add to bag before nulling");
		}
	}


}
