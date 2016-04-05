using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float healthPoints;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool LoseHP(float damage){
		healthPoints -= damage;
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
