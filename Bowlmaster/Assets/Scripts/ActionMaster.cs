using UnityEngine;
using System.Collections;

public class ActionMaster {

	public enum Action
	{
		TIDY, RESET, END_TURN, END_GAME
	}

	private int[] bowls = new int[23];
	private int bowl = 1;

	public Action Bowl (int pins)
	{
		if (pins < 0 || pins > 10)
			throw new UnityException ("Invalid pins count");

		bowls [bowl] = pins;
		if (bowl==21) return Action.END_GAME;
		if (bowl == 20) {
			if (Has21Frame()) {
				bowl++;
				return Action.RESET;
			}
			return Action.END_GAME;
		}

		if (pins == 10) {
			if (bowl > 18) {
				bowl++;
				return Action.RESET;
			} else {
				bowl += 2;
			}
			return Action.END_TURN;
		}
		if (bowl % 2 == 1) {
			bowl++;
			return Action.TIDY;
		} else {
			bowl++;
			return Action.END_TURN;
		}
	}

	private bool Has21Frame(){
		return bowls[bowl]+bowls[bowl-1] == 10||bowls[bowl-1]==10;
	}
}
