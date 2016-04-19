using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.END_TURN;
	private ActionMaster.Action tidy = ActionMaster.Action.TIDY;
	private ActionMaster.Action reset = ActionMaster.Action.RESET;
	private ActionMaster.Action endGame = ActionMaster.Action.END_GAME;
	private IList<int> input;

	[SetUp]
	public void Setup () {
		input = new List<int>();
	}


	[Test]
	public void T001OneStrikeReturnsEndTurn ()
	{
		IList<int> input = new List<int>();
		input.Add(10);
		Assert.AreEqual(ActionMaster.Action.END_TURN, ActionMaster.NextAction(input));
	}

	[Test]
	public void T002AddLessThan10ReturnTidy ()
	{
		for (int i = 0; i < 10; i++) {
			IList<int> input = new List<int>();
			input.Add(i);
			Assert.AreEqual (ActionMaster.Action.TIDY, ActionMaster.NextAction(input));
		}
	}
	[Test]
	public void T003AddTwiceReturnEndTurn ()
	{
		IList<int> input = new List<int>();
		for (int i = 0; i < 10; i++) {
			input.Add(i);
			input.Add(i);
		}
		Assert.AreEqual (ActionMaster.Action.END_GAME, ActionMaster.NextAction(input));
	}

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn () {
		input.Add(10);
		Assert.AreEqual (endTurn, ActionMaster.NextAction(input));
	}

	[Test]
	public void T02Add8ReturnsTidy () {
		input.Add(8);
		Assert.AreEqual (tidy, ActionMaster.NextAction(input));
	}

	[Test]
	public void T04Add28SpareReturnsEndTurn () {
		input.Add (8);
		input.Add(2);
		Assert.AreEqual (endTurn, ActionMaster.NextAction(input));
	}

	[Test]
	public void T05CheckResetAtStrikeInLastFrame () {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls) {
			input.Add (roll);
		}
		input.Add (10);
		Assert.AreEqual (reset, ActionMaster.NextAction(input));
	}

	[Test]
	public void T06CheckResetAtSpareInLastFrame () {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls) {
			input.Add (roll);
		}
		input.Add (1);
		input.Add (9);
		Assert.AreEqual (reset, ActionMaster.NextAction(input));
	}

	[Test]
	public void T07YouTubeRollsEndInEndGame () {
		int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2};
		foreach (int roll in rolls) {
			input.Add (roll);
		}
		input.Add(9);
		Assert.AreEqual (endGame, ActionMaster.NextAction(input));
	}

	[Test]
	public void T08GameEndsAtAdd20 () {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1};
		foreach (int roll in rolls) {
			input.Add (roll);
		}
		input.Add (1);
		Assert.AreEqual (endGame, ActionMaster.NextAction(input));
	}

	[Test]
	public void T09GameEndsAtAdd21 () {
		for(int i = 0;i<18;i++){
			input.Add (1);
		}
		input.Add (10);
		input.Add (1);
		input.Add (1);
		Assert.AreEqual (endGame, ActionMaster.NextAction(input));
	}

	[Test]
	public void T09NineStrikesGameEndsAtAdd21 () {
		for(int i = 0;i<9;i++){
			input.Add (10);
		}
		input.Add (10);
		input.Add (1);
		input.Add (1);
		Assert.AreEqual (endGame, ActionMaster.NextAction(input));
	}

	[Test]
	public void T10NStrikeOn19FollowedBy0 () {
		for(int i = 0;i<18;i++){
			input.Add (1);
		}
		input.Add (10);
		input.Add (0);
		input.Add (1);
		Assert.AreEqual (endGame, ActionMaster.NextAction(input));
	}

	[Test]
	public void T11Case0and10isEndTurnNoStrikeOrSpareAfterwards () {
		input.Add (0);
		input.Add (10);
		input.Add (0);
		Assert.AreEqual (tidy, ActionMaster.NextAction(input));
	}

	[Test]
	public void T12T11until19Frames ()
	{
		for (int i = 0; i<8; i++) {
			input.Add (0);
			Assert.AreEqual (tidy, ActionMaster.NextAction(input));
			input.Add (10);
			Assert.AreEqual (endTurn, ActionMaster.NextAction(input));			
		}
	}

	[Test]
	public void Dondi10thFrameTurkey () {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls) {
			input.Add (roll);
		}
		input.Add (10);
		Assert.AreEqual (reset, ActionMaster.NextAction(input));
		input.Add (10);
		Assert.AreEqual (reset, ActionMaster.NextAction(input));
		input.Add (10);
		Assert.AreEqual (endGame, ActionMaster.NextAction(input));
	}
}