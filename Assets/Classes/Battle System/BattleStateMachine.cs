using UnityEngine;
using System.Collections.Generic;

public class BattleStateMachine{

	EncounterManager manager;



	public enum BattleState{
		START,
		STARTANIMATION,
		PLAYERCHOICE,
		ENEMYCHOICE,
		END
	}

	BattleState currentState;

	public BattleStateMachine(EncounterManager em){
		manager = em;
		currentState = BattleState.START;
	}


	public void ProcessBattleState(){
		Debug.Log (currentState);
		switch (currentState) {
		case BattleState.START:
			SetupBattle ();
			break;
		case BattleState.STARTANIMATION:
			SetupAnimation ();
			break;
		case BattleState.PLAYERCHOICE:
			PlayerChoice ();
			break;
		case BattleState.ENEMYCHOICE:
			break;
		case BattleState.END:
			break;



		default:
			throw new UnityException ("Battle State Undefined");
		}
	}


	void SetupBattle(){
		//DONT THINK THIS NEEDS TO DO ANYTHING TBH
		currentState = BattleState.STARTANIMATION;
	}

	void SetupAnimation(){
		//Move player objects in and animate an intro to the battle
		currentState = BattleState.PLAYERCHOICE;
	}

	bool PlayerSelectedMove = false;
	void PlayerChoice(){
		/* Open the player GUI and wait until the end turn key is pressed 
		 * On player selecting a button, the correct code will be run with the animation
		 */
		if (PlayerSelectedMove) {
			if (manager.encounterData.enemies.Count != 0) {
				currentState = BattleState.ENEMYCHOICE;
			}
			else {
				manager.encounterData.PlayerWon = true;
				currentState = BattleState.END;
			}
		}
	}
		

	void EnemyChoice(){
		// run through all enemies and do some sick tier AI logic and execute correct code and animations

		if(manager.encounterData.player.Health <=0){
			manager.encounterData.PlayerWon = false;
			currentState = BattleState.END;
		}
		else{
			currentState = BattleState.PLAYERCHOICE;
		}

	}


}
