using UnityEngine;
using System.Collections;

public class SlotMachine : MonoBehaviour {

  private readonly string[] levels = { "fire", "water", "plat" };
  private readonly string[] weapons = { "knife", "handgun", "launcher" };
  private readonly string[] enemies = { "golem", "duck", "bird" };

  private const int numberOfSlots = 3;

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
  }
}
