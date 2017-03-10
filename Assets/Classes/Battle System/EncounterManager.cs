using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/*
 * This class will sit here and do nothing until the object that has instantiated it 
 * calls it to either Generate an encounter or build one from preselected enemies.
 * It does nothing without either of these calls
 *
 */
public class EncounterManager : MonoBehaviour {
	[SerializeField]
	BattleStateMachine battleStateMachine;
	public Encounter encounterData;
	bool EncounterReady = false;


	public struct Encounter{
		public bool PlayerWon;
		public Player player;
		public List<Enemy> enemies;
		public EncounterGraphics graphics;

	}
	public struct EncounterGraphics
	{
		public Sprite Background;
	}

	// Use this for initialization
	void Start () {
		GenerateEncounter ();

	}
	
	// Update is called once per frame
	void Update () {
		if(EncounterReady){
			battleStateMachine.ProcessBattleState ();
		}

	}

	public void GenerateEncounter(){
		SetupStructsAndClasses ();
		//Get Some Random Enemies

		//Put them in a list

		StartEncounter ();
	
	}

	public void BuildEncounter(List<Enemy> enems){
		SetupStructsAndClasses ();
		encounterData.enemies = enems;
		StartEncounter ();
	}

	void SetupStructsAndClasses(){
		encounterData = new Encounter ();
		encounterData.player = GameObject.Find ("Player").GetComponent<PlayerHolder>().me;
		encounterData.graphics = new EncounterGraphics ();
		battleStateMachine = new BattleStateMachine (this);

	}

	void StartEncounter(){
		EncounterReady = true;
	}


	//TODO POSSIBLY HAVE A JSON SETUP FOR ENCOUNTERS THAT WE CAN READ THINGS SUCH AS ENVIRONMENT FROM AND FROM THAT
	// GRAB THE CORRECT SPRITE, ENEMIES ETC.
}
