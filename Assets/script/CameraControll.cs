//camera controll
//follow player

using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {
	//public GameObject player;
	public float speed = 10f;
	private Vector3 offset;

	void Start () {
		//offset = transform.position - player.transform.position;
	}

	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (new Vector3 (0, -speed * Time.deltaTime, 0));
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (new Vector3 (0, speed * Time.deltaTime, 0));
		}
	}

	void LateUpdate () {
		//transform.position = player.transform.position + offset;
	}
}
