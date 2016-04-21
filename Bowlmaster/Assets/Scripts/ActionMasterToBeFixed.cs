using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMasterToBeFixed {

	private ActionMasterToBeFixed(){}

	public enum Action
	{
		TIDY, RESET, END_TURN, END_GAME
	}

	private int[] bowls = new int[23];
	private int bowl = 1;

	private Action Bowl (int pins)
	{
		if (pins < 0 || pins > 10)
			throw new UnityException ("Invalid pins count");

		bowls [bowl] = pins;
		if (bowl == 21)//on bowl 21
			return Action.END_GAME;

		//special cases
		if (bowl == 20) { //on bowl 20
			if (Has21Frame ()) {
				if (pins == 10 || IsSpare ()) {//if is a strike or a spare
					bowl++;	
					return Action.RESET;
				}
				//on strike not followed by a strike or spare
				bowl++;
				return Action.TIDY;
			}
			return Action.END_GAME;
		}

		if (pins == 10) {//if is a trike
			if (bowl > 18) {
				bowl++;
				return Action.RESET;
			}
			if (IsSpare ()) {
				bowl++;
			} else {
				bowl += 2;
			}
			return Action.END_TURN;
		} 
		else
		{
			if (bowl % 2 == 1) {//if is first launch and not strike
				bowl++;
				return Action.TIDY;
			} else {//if is second launch and not strike
				bowl++;
				return Action.END_TURN;
			}
		}
	}

	private bool Has21Frame(){
		return IsSpare()||bowls[bowl-1]==10;
	}

	private bool IsSpare ()
	{
		return (bowl%2==0&&bowl<19)||(bowls[bowl]+bowls[bowl-1] == 10&&bowls[bowl]!=10&&bowls[bowl-1]!=10);
	}

	public static Action NextAction (IList<int> pinFalls)
	{
		ActionMasterToBeFixed actionMaster = new ActionMasterToBeFixed();
		Action currentAction = new Action();
		foreach(int pins in pinFalls)
			currentAction = actionMaster.Bowl(pins);
		return currentAction;
	}
}
