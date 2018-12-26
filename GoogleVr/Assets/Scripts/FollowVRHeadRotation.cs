using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVRHeadRotation : MonoBehaviour {

	public Transform VRMainObject;
	public float cameraOffsetXZ;
	public float cameraOffsetY;
	public float bodyTurnAngle = 20.0f;
	public float animSpeed = 0.5f;

	private CharacterController myCC;
	private Animator myAnim;
	private Vector3 vrRot, myRot;
	private Transform vrCamera;

	private float x, z;

	// Use this for initialization
	void Start () {
		myCC = GetComponent<CharacterController> ();
		myAnim = GetComponent<Animator> ();
		vrCamera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		vrRot = vrCamera.rotation.eulerAngles;
		myRot = transform.rotation.eulerAngles;

		float speed = myCC.velocity.magnitude * animSpeed;
		Debug.Log (speed);

		if (speed > 0.4f) {
			bodyTurnAngle = 5.0f;
		} else {
			bodyTurnAngle = 20.0f;
		}

		if (Mathf.DeltaAngle (vrRot.y, myRot.y) > bodyTurnAngle) {
			if (!gameObject.GetComponent<iTween> ()) {
				Debug.Log ("Turn Left!");

				if (speed < 0.4f) {
					myAnim.SetTrigger ("TurnLeft");
				}
				if (speed > 0.4f) {
					iTween.RotateTo (gameObject, new Vector3 (myRot.x, vrRot.y, myRot.z), 0.5f);
				} else {
					iTween.RotateTo (gameObject, new Vector3 (myRot.x, vrRot.y, myRot.z), 1f);
				}

			}
		} else if(Mathf.DeltaAngle (vrRot.y, myRot.y) < -bodyTurnAngle){
			if (!gameObject.GetComponent<iTween> ()) {
				Debug.Log ("Turn Right!");

				if (speed < 0.4f) {
					myAnim.SetTrigger ("TurnRight");
				}
				if (speed > 0.4f) {
					iTween.RotateTo (gameObject, new Vector3 (myRot.x, vrRot.y, myRot.z), 0.5f);
				} else {
					iTween.RotateTo (gameObject, new Vector3 (myRot.x, vrRot.y, myRot.z), 1f);
				}

			}
		}
		myAnim.SetFloat ("Speed", speed);
	}

	void LateUpdate(){
		x = cameraOffsetXZ * Mathf.Sin (vrCamera.rotation.eulerAngles.y * Mathf.Deg2Rad);
		z = cameraOffsetXZ * Mathf.Cos (vrCamera.rotation.eulerAngles.y * Mathf.Deg2Rad);
		VRMainObject.position = transform.position + new Vector3 (x, cameraOffsetY, z);
	}
}
