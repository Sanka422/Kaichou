using UnityEngine;
using System.Collections;

public class Plane :MonoBehaviour {
	public int x;
	public int y;
	public int z;
	public Vector3 pos;
	BasePlane p;

	public void setXYZ (int x, int y, int z, BasePlane p) {
		this.x = x;
		this.y = y;
		this.z = z;
		this.p = p;
		pos = this.transform.position;
	}

	void Update () {
		pos = this.transform.position;
	}

	public void init (string name) {
		this.name = name;
		MeshRenderer render = GetComponentInChildren<MeshRenderer> ();
		render.enabled = false;
		Debug.Log (name);
		//Component halo = GetComponent ("Halo");
		//halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
	}

	public void OnMouseOver () {
		MeshRenderer render = GetComponentInChildren<MeshRenderer> ();
		render.enabled = true;
	}

	public void OnMouseExit () {
		MeshRenderer render = GetComponentInChildren<MeshRenderer> ();
		render.enabled = false;
	}
}

