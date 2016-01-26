using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

  [HideInInspector] public bool facingRight = true;
  [HideInInspector] public bool jump = true;

  public float moveForce = 365f;
  public float maxSpeed = 5f;
  public float jumpFroce = 1000f;
  public Transform groundCheck;

  private bool grounded = false;
  private Animator anim;
  private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
    anim = GetComponent<Animator>();
    rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
    grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

    if (Input.GetButtonDown("Jumps") && grounded) {
      jump = true;
    }
	}

  void FixedUpdate() {
    float h = Input.GetAxis("Horizontal");
    anim.SetFloat("Speed", Mathf.Abs(h));

    if (h * rb2d.velocity.x < maxSpeed) {
      rb2d.AddForce(Vector2.right * h * moveForce);


    }
  }

  void Flip() {
    facingRight = !facingRight;
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
  }
}
