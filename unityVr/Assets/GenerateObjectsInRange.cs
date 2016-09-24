using UnityEngine;
using System.Collections;

public class GenerateObjectsInRange : MonoBehaviour {
	public CircularPathBuilder pathBuilder;
	public Transform[] prefab;
	public int count = 10;
	public float radius = 10;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < count; i++){
			int prefabI = Random.Range(0,prefab.Length);
			Transform child     = Instantiate(prefab[prefabI]);
			child.parent        = transform;	
			child.localPosition = Random.insideUnitSphere;
			float magnitude     = child.localPosition.magnitude;
			
			child.localPosition *= Random.Range(1, radius / magnitude);
			child.localScale = transform.localScale;
			var pathFollowers = child.GetComponents<PathFollowingController>();
			if(pathBuilder != null && pathFollowers.Length > 0){
				foreach(var follower in pathFollowers){
					follower._pathRoot = pathBuilder.transform;
				}
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
