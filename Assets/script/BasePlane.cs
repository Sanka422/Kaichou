using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class BasePlane : MonoBehaviour {
	int rowNumber;
	int colNumber;
	Plane[,] plane;
	public Plane p;
	Ray ray;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		createPlane ("Scene/Scene1");
	}
	
	// Update is called once per frame
	void Update () {
		/*ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			print (hit.collider.name);
			MeshRenderer render = hit.collider.GetComponentInChildren<MeshRenderer> ();
			render.enabled = true;
		}*/
	}

	void createPlane () {

	}



	private void createPlane (string fileName) {
		//read text 
		FileInfo theSourceFile = new FileInfo (fileName);
		StreamReader reader = theSourceFile.OpenText ();
		string text;
		text = reader.ReadLine ();
		string[] temp = text.Split (' ');
		//init plane in to arraylist of x*y plane
		rowNumber = int.Parse (temp [1]);
		colNumber = int.Parse (temp [0]);
		transform.localScale = new Vector3 (rowNumber, 1, colNumber);
		plane = new Plane[rowNumber, colNumber];
		for (int i = 0; i < rowNumber; i++) {
			text = reader.ReadLine ();
			string[] temp1 = text.Split (' ');
			int j = 0;
			foreach (string r in temp1) {
				Plane t = (Plane)Instantiate (p);
				t.transform.parent = this.transform;
				//scale factor of minor plane
				Vector3 pScale = new Vector3 (1f / rowNumber, 1, 1f / colNumber);
				t.transform.localScale = pScale;
				//location of minor plane
				t.transform.position = new Vector3 (
					(rowNumber - 1 - i * 2) * 5, 
					int.Parse (r) + 0.001f, 
					(colNumber - 1 - j * 2) * 5);
				t.setXYZ (i, int.Parse (r), j, this);
				plane [i, j] = t;
				t.init ("plane " + i + " " + j);
				j++;
			}
		}
	}

}
	