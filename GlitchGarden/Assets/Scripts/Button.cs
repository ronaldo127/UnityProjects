using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject prefab;

	private Button[] buttonsInScene;
	private static GameObject currentSelected;

	// Use this for initialization
	void Start () {
		buttonsInScene = GameObject.FindObjectsOfType<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown ()
	{
		foreach (Button btn in buttonsInScene) {
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

	public GameObject GetCurrentSelected ()
	{
		return currentSelected;
	}
}
