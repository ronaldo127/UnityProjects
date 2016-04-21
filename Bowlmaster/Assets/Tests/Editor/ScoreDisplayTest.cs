using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Linq;

public class ScoreDisplayTest {

    [Test]
    public void T01Bowl1()
    {
        int[] rolls = {1};
        string rollString = "1";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

    [Test]
    public void T02Bowl123()
    {
        int[] rolls = {1, 2, 3 };
        string rollString = "123";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

    [Test]
    public void T02Bowl1234Strike12()
    {
        int[] rolls = {1, 2,  3, 4, 10, 1, 2 };
		string rollString = "1234X 12";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

    [Test]
    public void T03Bowl123455Strike12()
    {
        int[] rolls = {1,2,  3,4, 5,5 , 10, 1, 2 };
		string rollString = "12345/X 12";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

    [Test]
    public void T04Bowl9Spares1Strike12()
    {
		int[] rolls = {5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5 , 10, 1, 2 };
		string rollString = "5/5/5/5/5/5/5/5/5/X12";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

    [Test]
    public void T05Bowl128Spares1Strike12()
    {
		int[] rolls = {1,2, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5 , 10, 1, 2 };
		string rollString = "125/5/5/5/5/5/5/5/X12";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

    [Test]
    public void T05Bowl128Spares3Strikes()
    {
		int[] rolls = {1,2, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5 , 10, 10, 10 };
		string rollString = "125/5/5/5/5/5/5/5/XXX";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

    [Test]
    public void T06Bowl129Spares1Strike()
    {
		int[] rolls = {1,2, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5 , 1, 9, 10 };
		string rollString = "125/5/5/5/5/5/5/5/1/X";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

    [Test]
    public void T07Bowl129Spares1()
    {
		int[] rolls = {1,2, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5 , 1, 9, 1 };
		string rollString = "125/5/5/5/5/5/5/5/1/1";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

    [Test]
    public void T08Bowl1Strike9Spares1()
    {
		int[] rolls = {10, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5, 5,5 , 1, 9, 1 };
		string rollString = "X 5/5/5/5/5/5/5/5/1/1";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

    [Test]
    public void T09Bowl0()
    {
        int[] rolls = {0};
        string rollString = "-";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

    [Test]
    public void T10Bowl129SparesWith0And3Strikes()
    {
		int[] rolls = {0,10, 0,10, 0,10, 0,10, 0,10, 0,10, 0,10, 0,10, 0,10 , 10, 10, 10 };
		string rollString = "-/-/-/-/-/-/-/-/-/XXX";
        Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}


	[Test]
	public void T02BowlX () {
		int[] rolls = {10};
		string rollsString = "X "; // Remember the space
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T03Bowl19 () {
		int[] rolls = {1,9};
		string rollsString = "1/"; // Remember the space
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T04BowlStrikeInLastFrame () {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1,1};
		string rollsString = "111111111111111111X11"; // Remember the space
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T05Bowl0 () {
		int[] rolls = {0};
		string rollsString = "-"; // Remember the space
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	

	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
	[Category ("Verification")]
	[Test]
	public void TG01GoldenCopyB1of3 () {
		int[] rolls = { 10, 9,1, 9,1, 9,1, 9,1, 7,0, 9,0, 10, 8,2, 8,2,10};
		string rollsString = "X 9/9/9/9/7-9-X 8/8/X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	
	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
	[Category ("Verification")]
	[Test]
	public void TG02GoldenCopyB2of3 () {
		int[] rolls = { 8,2, 8,1, 9,1, 7,1, 8,2, 9,1, 9,1, 10, 10, 7,1};
		string rollsString = "8/819/718/9/9/X X 71";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	
	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
	[Category ("Verification")]
	[Test]
	public void TG03GoldenCopyB3of3 () {
		int[] rolls = { 10, 10, 9,0, 10, 7,3, 10, 8,1, 6,3, 6,2, 9,1,10};
		string rollsString = "X X 9-X 7/X 8163629/X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	
	// http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
	[Category ("Verification")]
	[Test]
	public void TG04GoldenCopyC1of3 () {
		int[] rolls = { 7,2, 10, 10, 10, 10, 7,3, 10, 10, 9,1, 10,10,9};
		string rollsString = "72X X X X 7/X X 9/XX9";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
	
	// http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
	[Category ("Verification")]
	[Test]
	public void TG05GoldenCopyC2of3 () {
		int[] rolls = { 10, 10, 10, 10, 9,0, 10, 10, 10, 10, 10,9,1};
		string rollsString = "X X X X 9-X X X X X91";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
}
