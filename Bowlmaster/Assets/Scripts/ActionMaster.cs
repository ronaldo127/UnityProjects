using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ActionMaster {

	public enum Action
	{
		TIDY, RESET, END_TURN, END_GAME, UNDEFINED
	}

	
	public static Action NextAction (IList<int> rolls) {
		Action nextAction = Action.UNDEFINED;
		
		for (int i = 0; i < rolls.Count; i++) { // Step through rolls
			
			if (i == 20) {
				nextAction = Action.END_GAME;
			} else if ( i >= 18 && rolls[i] == 10 ){ // Handle last-frame special cases
				nextAction = Action.RESET;
			} else if ( i == 19 ) {
				if (rolls[18]==10 && rolls[19]==0) {
					nextAction = Action.TIDY;
				} else if (rolls[18] + rolls[19] == 10) {
					nextAction = Action.RESET;
				} else if (rolls [18] + rolls[19] >= 10) {  // Roll 21 awarded
					nextAction = Action.TIDY;
				} else {
					nextAction = Action.END_GAME;
				}
			} else if (i % 2 == 0) { // First bowl of frame
				if (rolls[i] == 10) {
					rolls.Insert (i, 0); // Insert virtual 0 after strike
					nextAction = Action.END_TURN;
				} else {
					nextAction = Action.TIDY;
				}
			} else { // Second bowl of frame
				nextAction = Action.END_TURN;
			}
		}
		
		return nextAction;
	}
}