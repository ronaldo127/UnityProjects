using UnityEngine;
using System.Collections;

public class SpawnButtonManager : MonoBehaviour {

	public SpawnButton[] buttonPrefabs;

	// Use this for initialization
	void Start () {
		foreach (SpawnButton prefab in buttonPrefabs){
			GameObject button = Instantiate(prefab.gameObject) as GameObject;
			button.GetComponent<RectTransform>().SetParent(this.transform);
		}
	}
}
