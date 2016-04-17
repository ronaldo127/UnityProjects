using UnityEngine;
using System.Collections;

public class ActionMaster {

	public enum Action
	{
		TIDY, RESET, END_TURN, END_GAME
	}

	//private int[] bowls = new int[23];
	private int bowl = 1;
	private int pontuation;

	public Action Bowl (int pins)
	{
		if (pins < 0 || pins > 10)
			throw new UnityException ("Invalid pins count");

		if (pins == 10) {
			pontuation = 0;
			bowl += (bowl % 2 == 0) ? 2 : 1;
			if (bowl > 18) {
				return Action.RESET;
			}
			return Action.END_TURN;
		}
		if (bowl % 2 == 1) {
			pontuation = pins;
			bowl++;
			return Action.TIDY;
		} else {
			pontuation += pins;
			if (bowl == 20) {
				if (pontuation == 10) {
					return Action.RESET;
				}
				return Action.END_GAME;
			}
			bowl++;
			return Action.END_TURN;
		}
	}
}
