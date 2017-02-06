using UnityEngine;
using System.Collections;
using System;

public class TimedEffect {
	public int TurnsLeft{get;  protected set;}
	public delegate void TimedEffectEventHandler (ITargetable c);
	public event TimedEffectEventHandler OnTick;
	public event TimedEffectEventHandler OnEnd;

	//Also takes 1 away from turns left
	public void Tick(ITargetable c){
		OnTick (c);
		TurnsLeft--;
	}

	public void EndEffect(ITargetable c){
		//If we need to force end it, maybe via an item
		TurnsLeft = 0;
		OnEnd (c);
	}
}
