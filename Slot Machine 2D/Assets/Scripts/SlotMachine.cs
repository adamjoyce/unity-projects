using UnityEngine;
using System.Collections;

public class SlotMachine : MonoBehaviour {

  public float animationSpeed = 1.0f;

  private readonly string[] levels = { "fire", "water", "plat" };
  private readonly string[] weapons = { "knife", "handgun", "launcher" };
  private readonly string[] enemies = { "golem", "duck", "bird" };

  private const int numberOfSlots = 3;

  private float time = 0.0f;

  GameObject knife;
  GameObject gun;
  GameObject rocket;

  // Update is called once per frame.
  public string[] SpinSlots() {
    string[] slotsResults = new string[3];

    int rand;
    for (int i = 0; i < numberOfSlots; i++) {
      rand = Random.Range(0, numberOfSlots - 1);

      if (i == 0)
        slotsResults[i] = levels[rand];
      else if (i == 1)
        slotsResults[i] = weapons[rand];
      else
        slotsResults[i] = enemies[rand];
    }

    //for (int i = 0; i < numberOfSlots; i++) {
    //Debug.Log(slotOutput[i] + " ");
    //}
    //Debug.Log("\n");

    return slotsResults;
  }

  private void Start() {
    knife = GameObject.Find("knife");
    gun = GameObject.Find("gun");
    rocket = GameObject.Find("rocket");
    knife.GetComponent<SpriteRenderer>().enabled = true;
    gun.GetComponent<SpriteRenderer>().enabled = false;
    rocket.GetComponent<SpriteRenderer>().enabled = false;
  }

  // Update.
  private void Update() {
    if (Input.GetMouseButtonDown(0)) {
      RaycastHit hit;
      if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
        if (hit.collider.tag == "Lever") {
          // Lever animation...
          Debug.Log("Lever Animation");

          // Spin Slots.
          string[] results = SpinSlots();

          // Slots animation...
        }
      }
    }

    if (knife.GetComponent<SpriteRenderer>().enabled == true) {
      knife.GetComponent<SpriteRenderer>().enabled = false;
      gun.GetComponent<SpriteRenderer>().enabled = true;
    }

    if (gun.GetComponent<SpriteRenderer>().enabled == true) {
      gun.GetComponent<SpriteRenderer>().enabled = false;
      rocket.GetComponent<SpriteRenderer>().enabled = true;
    }

    if (rocket.GetComponent<SpriteRenderer>().enabled == true) {
      rocket.GetComponent<SpriteRenderer>().enabled = false;
      knife.GetComponent<SpriteRenderer>().enabled = true;
    }
  }

  IEnumerator Wait() {
    yield return 0;
  }
}
