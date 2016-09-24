using UnityEngine;
using UnityEditor;

public class CircularPathBuilder : MonoBehaviour {
	public int   numberOfNodes = 10;
	public float radius = 1;
	public Transform prefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

[CustomEditor(typeof(CircularPathBuilder))]
public class CircularPathBuilderEditor : Editor{
	public CircularPathBuilder Target {
		get{ return (target as CircularPathBuilder); }
	}

	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		if(GUILayout.Button("Update Path")){
			float     radius = Target.radius;
			int       nodes  = Target.numberOfNodes;
			Transform prefab = Target.prefab;

			foreach(Transform child in Target.transform){
				
			}
		}
	}

}
