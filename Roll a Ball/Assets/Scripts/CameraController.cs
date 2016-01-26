using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

  // The player object who has this script attached.
  public GameObject player;

  // Camera offset in comparision to the player object.
  private Vector3 offset;

	// Use this for initialization.
	void Start() {
    offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame after Update has run.
	void LateUpdate() {
    transform.position = player.transform.position + offset;
	}
}
