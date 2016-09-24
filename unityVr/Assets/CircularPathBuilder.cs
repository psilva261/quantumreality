using UnityEngine;

public class CircularPathBuilder : MonoBehaviour {
	public int       resolution = 10;
	public float     radius     = 1;
	public Transform prefab;
	public bool      generateOnStart = true;
	// Use this for initialization

	void Start () {
		if(generateOnStart){
			generatePath();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void generatePath(){
		
		deleteAllElements();

		for(int i = 0; i < resolution; i++){
			Vector3 position = new Vector3(
				Mathf.Sin((i * Mathf.PI * 2) / (float)resolution),
				Mathf.Cos((i * Mathf.PI * 2) / (float)resolution),
				0
			);

			position           *= radius;
			Transform child     = Instantiate(prefab);
			child.parent        = transform;
			child.localPosition = position;
		}
	}
	
	public void deleteAllElements(){
		//Delete all old Elements
		while(transform.childCount > 0){
			foreach(Transform child in transform){
				DestroyImmediate(child.gameObject);
			}
		}
	}
}

