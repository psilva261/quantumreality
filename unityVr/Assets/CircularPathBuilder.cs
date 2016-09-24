using UnityEngine;

public class CircularPathBuilder : MonoBehaviour {
	public enum orbitalTypes {
		orbital_1s = 1,
		orbital_2p,
		orbital_3d
	};
	public orbitalTypes       orbitalType = orbitalTypes.orbital_1s;
	public int       resolution  = 10;
	public float     radius      = 1;
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
			float x;
			float y = Mathf.PI / 2;;
			Vector3 position = new Vector3(0,0,0);

			switch (orbitalType) {
			case orbitalTypes.orbital_1s:
				x = (i * Mathf.PI * 2) / (float)resolution;

				position = new Vector3 (
					Mathf.Sin (x),
					Mathf.Cos (x),
					0
				);
				position *= radius;
				break;
			case orbitalTypes.orbital_2p:
				x = (i * Mathf.PI * 2) / (float)resolution;

				// Ellipsoid
				position = new Vector3 (
					Mathf.Sin (x) * Mathf.Cos (y) * Mathf.Pow (Mathf.Sqrt (3 / (4 * Mathf.PI)) * Mathf.Sin (x) * Mathf.Cos (y), 2),
					Mathf.Sin (x) * Mathf.Sin (y) * Mathf.Pow (Mathf.Sqrt (3 / (4 * Mathf.PI)) * Mathf.Sin (x) * Mathf.Cos (y), 2),
					Mathf.Cos (x) * Mathf.Pow (Mathf.Sqrt (3 / (4 * Mathf.PI)) * Mathf.Sin (x) * Mathf.Cos (y), 2)
				);
				position *= radius;
				break;
			case orbitalTypes.orbital_3d:
				x = 2 * (i * Mathf.PI * 2) / (float)resolution;

				if (i < resolution / 2) {
					// Torus
					float a = 0.5f;
					float c = 1f;

					position = new Vector3 (
						Mathf.Cos(x) * (a * Mathf.Cos(y) + c),
						Mathf.Sin(x) * (a * Mathf.Cos(y) + c),
						a * Mathf.Sin(x)
					);
				} else {
					// Ellipsoid
					position = new Vector3 (
						10 * Mathf.Sin (x) * Mathf.Cos (y) * Mathf.Pow (Mathf.Sqrt (3 / (4 * Mathf.PI)) * Mathf.Sin (x) * Mathf.Cos (y), 2),
						10 * Mathf.Sin (x) * Mathf.Sin (y) * Mathf.Pow (Mathf.Sqrt (3 / (4 * Mathf.PI)) * Mathf.Sin (x) * Mathf.Cos (y), 2),
						10 * Mathf.Cos (x) * Mathf.Pow (Mathf.Sqrt (3 / (4 * Mathf.PI)) * Mathf.Sin (x) * Mathf.Cos (y), 2)
					);
				}
				position *= radius;
				break;
			}

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

