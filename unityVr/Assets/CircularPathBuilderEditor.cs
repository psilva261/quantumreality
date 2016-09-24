#if Editor
using UnityEditor;
using UnityEngine;  

[CustomEditor(typeof(CircularPathBuilder))]
public class CircularPathBuilderEditor : Editor{
	public CircularPathBuilder Target {
		get{ return (target as CircularPathBuilder); }
	}

	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		if(GUILayout.Button("Update Path")){
			Target.generatePath();
		}
        if(GUILayout.Button("Delete Path")){
			Target.deleteAllElements();
		}
	}
}
#endif