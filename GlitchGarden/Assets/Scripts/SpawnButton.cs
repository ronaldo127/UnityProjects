using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnButton : MonoBehaviour {

	public GameObject prefab;

	private SpawnButton[] buttonsInScene;
	private static GameObject currentSelected;
	private Text costText;

	// Use this for initialization
	void Start () {
		buttonsInScene = GameObject.FindObjectsOfType<SpawnButton>();
		FindCostText ();
	}

	void FindCostText ()
	{
		costText = GetComponentInChildren<Text> ();
		if (!costText) 
			Debug.LogWarning(name+" has no cost text.");
		else
			costText.text = prefab.GetComponent<Defender> ().cost.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown ()
	{
		foreach (SpawnButton btn in buttonsInScene) {
			changeColor (btn.GetComponentsInChildren<SpriteRenderer> (), Color.black);
		}

		if (this.prefab.Equals (currentSelected)) {
			currentSelected = null;
		} else {
			SpriteRenderer[] pressedSprites = this.GetComponentsInChildren<SpriteRenderer>();
			changeColor(pressedSprites, Color.white);
			currentSelected = this.prefab;
		}
	}

	private void changeColor(SpriteRenderer[] spriteRenderes, Color color){
		foreach (SpriteRenderer sr in spriteRenderes) {
			sr.color=color;
		}
	}

	public static GameObject GetCurrentSelected ()
	{
		return currentSelected;
	}
}
