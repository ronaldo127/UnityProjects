using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ScoreMaster{

	
	public static List<int> ScoreCumulative (List<int> rolls)
	{
		List<int> cumulativeScores = new List<int>();

		int runningTotal = 0;

		foreach(int frameScore in ScoreFrames(rolls)){
			runningTotal+=frameScore;
			cumulativeScores.Add(runningTotal);
		}

		return cumulativeScores;
	}

	public static List<int> ScoreFrames (List<int> rolls)
	{

		List<int> frameList = new List<int> ();

		for (int i = 1; i < rolls.Count; i += 2) {
			if (frameList.Count==10) break;				//last frame is filled then break

			if (rolls [i] + rolls [i - 1] < 10) {		//"open" frame
				frameList.Add (rolls [i] + rolls [i - 1]);
			}

			if (i >= rolls.Count - 1) break;			// ensure there is one look-ahead available

			if (rolls [i - 1] == 10) {					//is strike then add strike bonus
				frameList.Add(rolls [i] + rolls [i - 1] + rolls[i+1]);
				i--;
			} else if (rolls [i] + rolls [i - 1] == 10) {//is a spare then add a spare bonus
				frameList.Add(rolls [i] + rolls [i - 1] + rolls[i+1]);
			}

		}
		return frameList;
	}

}
