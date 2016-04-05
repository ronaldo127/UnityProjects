using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[RequireComponent(typeof(Animator))]
public class SpawnButton : MonoBehaviour {

	public GameObject prefab;

	private static GameObject currentSelected;
	private static Animator currentSelectedAnimator;

	private SpawnButton[] buttonsInScene;
	private Text costText;
	private Animator animator;

	// Use this for initialization
	void Start () {
		buttonsInScene = GameObject.FindObjectsOfType<SpawnButton>();
		FindCostText ();
		animator = GetComponent<Animator>();
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
			currentSelectedAnimator = null;
		} else {
			SpriteRenderer[] pressedSprites = this.GetComponentsInChildren<SpriteRenderer>();
			changeColor(pressedSprites, Color.white);
			currentSelected = this.prefab;
			currentSelectedAnimator = this.animator;
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

	public static void CantSpawnMessage ()
	{
		if (currentSelectedAnimator)
			currentSelectedAnimator.SetTrigger("Blink");
	}
}
