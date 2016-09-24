using UnityEngine;
using System.Collections;

public class GenerateObjectsInRange : MonoBehaviour {
	public Transform prefab;
	public int count = 10;
	public float radius = 10;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < count; i++){
			Transform child = Instantiate(prefab);
			child.parent = transform;	
			child.localPosition = Random.insideUnitSphere;
					
			float magnitude = child.localPosition.magnitude;
			
			child.localPosition *= Random.Range(1, radius / magnitude);
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
