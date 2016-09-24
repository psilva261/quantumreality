using UnityEditor;

[CustomEditor(typeof(CircularPathBuilder))]
public class CircularPathBuilderEditor : Editor{
	public CircularPathBuilder Target {
		get{ return (target as CircularPathBuilder); }
	}

	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		if(GUILayout.Button("Update Path")){
			this.generatePath();
		}
	}

	public void generatePath(){
		float     radius    = Target.radius;
		int       nodes     = Target.numberOfNodes;
		Transform prefab    = Target.prefab;
		Transform transform = Target.transform;
		deleteAllElements();

		for(int i = 0; i < nodes; i++){
			Vector3 position = new Vector3(
				Mathf.Sin((i * Mathf.PI * 2) / (float)nodes),
				Mathf.Cos((i * Mathf.PI * 2) / (float)nodes),
				0
			);

			position           *= radius;
			Transform child     = Instantiate(prefab);
			child.parent        = transform;
			child.localPosition = position;
		}
	}
	
	public void deleteAllElements(){
		Transform transform = Target.transform;
		//Delete all old Elements
		while(transform.childCount > 0){
			foreach(Transform child in transform){
				DestroyImmediate(child.gameObject);
			}
		}
	}

}