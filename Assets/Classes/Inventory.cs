using UnityEngine;
using System.Collections.Generic;
using System;

public class Inventory {

	public List<Item> Items { get; set; }

	public void AddItem(Item i){
		Items.Add (i);
	}
	public void RemoveItem(Item i){
		Items.Remove (i);
	}

	public Inventory(){
		Items = new List<Item> ();
	}

}
