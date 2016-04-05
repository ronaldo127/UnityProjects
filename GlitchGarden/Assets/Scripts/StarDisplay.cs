using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {


	public int stars = 100;
	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		UpdateText ();
	}

	public void UpdateText ()
	{
		text.text = stars.ToString();
	}

	public void AddStars (int amount)
	{
		stars+=amount;
		UpdateText ();
	}

	public bool UseStars (int amount)
	{
		if (stars < amount) {
			return false;
		}
		stars-=amount;
		UpdateText ();
		return true;
	}
}
