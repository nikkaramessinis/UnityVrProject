using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarController : MonoBehaviour {

	public Text countText;
	public Text winText;
	public Transform vrCamera;
	public float toggleAngle = 30.0f;
	public float speed = 3.0f;
	public bool moveForward;

	private CharacterController cc;
	private int count;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f) {
			moveForward = true;
		} else {
			moveForward = false;
			cc.SimpleMove (Vector3.zero);
		}
		if (moveForward) {
			Vector3 forward = vrCamera.TransformDirection (Vector3.forward);
			cc.SimpleMove (forward * speed);
		}
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 7) {
			winText.text = "You win!";
		}
	}
}
