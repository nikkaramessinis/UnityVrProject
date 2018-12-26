using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text countText;
	public Text winText;

	public float toggleAngle = 20.0f;
	public Transform vrCamera;
	public float thrust;
	public Rigidbody rb;

	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate()
	{

		Vector3 movement;
		if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
		{
			movement = new Vector3(0.0f, 0.0f, 1.0f);
			rb.AddForce(movement * thrust);
		}


		/*if (vrCamera.eulerAngles.y >= 30.0f && vrCamera.eulerAngles.x < 90.0f)
        { 
            movement = new Vector3(1.0f, 0.0f, 0.0f);
            rb.AddForce(movement * thrust);
        }*/
		//Debug.Log(vrCamera.transform.rotation.y);
		Debug.Log(vrCamera.eulerAngles.y);
		if (vrCamera.eulerAngles.y <= 340 & vrCamera.eulerAngles.y > 220)
		{
			Debug.Log("mpika");
			movement = new Vector3(-1.0f, 0.0f, 0.0f);
			rb.AddForce(movement * thrust);
		}


		if (vrCamera.eulerAngles.y >20 & vrCamera.eulerAngles.y < 170)
		{
			Debug.Log("mpika");
			movement = new Vector3(1.0f, 0.0f, 0.0f);
			rb.AddForce(movement * thrust);
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
		if (count >= 12) {
			winText.text = "You win!";
		}
	}
}
