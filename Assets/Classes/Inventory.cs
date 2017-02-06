using UnityEngine;
using System.Collections.Generic;
using System;

public class Inventory {

	public List<Item> Items { get; set; }

	public void AddItem(Item i){
		Items.Add (i);
		//throw new NotImplementedException ();
	}
	public void RemoveItem(Item i){
		throw new NotImplementedException();
	}
}
