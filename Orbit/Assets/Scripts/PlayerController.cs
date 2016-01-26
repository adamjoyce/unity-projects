using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

  public GameObject obj;

  private Rigidbody rb;
  private bool orbiting;

	// Use this for initialization
	void Start () {
    rb = GetComponent<Rigidbody>();
    orbiting = true;
	}
	
	// Update is called once per frame
	void Update () {
    checkInput();

    if (orbiting == true) {
      transform.RotateAround(obj.transform.position, Vector3.back, 100 * Time.deltaTime);
    } else {
      rb.AddForce(rb.velocity * 10);
    }
	}

  void checkInput() {
    if (Input.GetKeyDown("space")) {
      orbiting = false;
      rb.isKinematic = false;
    }
  }
}
