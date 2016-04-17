using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster actionMaster;
	private ActionMaster.Action endTurn = ActionMaster.Action.END_TURN;
	private ActionMaster.Action tidy = ActionMaster.Action.TIDY;
	private ActionMaster.Action reset = ActionMaster.Action.RESET;
	private ActionMaster.Action endGame = ActionMaster.Action.END_GAME;

	[SetUp]
	public void Setup () {
		actionMaster = new ActionMaster ();
	}

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn () {
		Assert.AreEqual (endTurn, actionMaster.Bowl(10));
	}

	[Test]
	public void T02Bowl8ReturnsTidy () {
		Assert.AreEqual (tidy, actionMaster.Bowl(8));
	}

	[Test]
	public void T04Bowl28SpareReturnsEndTurn () {
		actionMaster.Bowl (8);
		Assert.AreEqual (endTurn, actionMaster.Bowl(2));
	}

	[Test]
	public void T05CheckResetAtStrikeInLastFrame () {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		Assert.AreEqual (reset, actionMaster.Bowl (10));
	}

	[Test]
	public void T06CheckResetAtSpareInLastFrame () {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		actionMaster.Bowl (1);
		Assert.AreEqual (reset, actionMaster.Bowl (9));
	}

	[Test]
	public void T07YouTubeRollsEndInEndGame () {
		int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2};
		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		Assert.AreEqual (endGame, actionMaster.Bowl(9));
	}

	[Test]
	public void T08GameEndsAtBowl20 () {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1};
		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		Assert.AreEqual (endGame, actionMaster.Bowl (1));
	}

	[Test]
	public void T001OneStrikeReturnsEndTurn ()
	{
		Assert.AreEqual(ActionMaster.Action.END_TURN, actionMaster.Bowl(10));
	}

	[Test]
	public void T002BowlLessThan10ReturnTidy ()
	{
		for (int i = 0; i < 10; i++) {
			actionMaster = new ActionMaster ();
			Assert.AreEqual (ActionMaster.Action.TIDY, actionMaster.Bowl (i));
		}
	}
	[Test]
	public void T003BowlTwiceReturnEndTurn ()
	{
		for (int i = 0; i < 10; i++) {
			actionMaster = new ActionMaster ();
			Assert.AreEqual (ActionMaster.Action.TIDY, actionMaster.Bowl (i));
			Assert.AreEqual (ActionMaster.Action.END_TURN, actionMaster.Bowl (i));
		}
	}
}