using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	public float healthPoints;

	private float maxHP;
	private Slider hpSlider;

	// Use this for initialization
	void Start () {
		maxHP = healthPoints;
		hpSlider = GetComponentInChildren<Slider>();
		if (!hpSlider) Debug.LogWarning ("Object "+name+ "doesn't have a Slider UI.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool LoseHP(float damage){
		healthPoints -= damage;
		if (hpSlider) hpSlider.value = healthPoints/maxHP;
		if(healthPoints<=0){
			//in case of dead animation
			DestroyActor();
			return true;
		}
		return false;
	}

	public void DestroyActor(){
		Destroy (this.gameObject);		
	}
}
