using UnityEngine;
using System.Collections;

public class SlotMachine : MonoBehaviour {

  private readonly string[] levels = { "fire", "water", "plat" };
  private readonly string[] weapons = { "knife", "handgun", "launcher" };
  private readonly string[] enemies = { "golem", "duck", "bird" };

  private const int numberOfSlots = 3;

  private string[] slotOutput;

  // Update is called once per frame.
  public void SpinSlots() {
    int rand;
    for (int i = 0; i < numberOfSlots; i++) {
      rand = Random.Range(0, numberOfSlots);

      if (i == 0)
        slotOutput[i] = levels[rand];
      else if (i == 1)
        slotOutput[i] = weapons[rand];
      else
        slotOutput[i] = enemies[rand];
    }

    //for (int i = 0; i < numberOfSlots; i++) {
      //Debug.Log(slotOutput[i] + " ");
    //}
    //Debug.Log("\n");
  }

  // Get the slot output parameters.
  public string[] GetSlotOutput() {
    return slotOutput;
  }

  // Use this for initialization.
  private void Start () {
    slotOutput = new string[numberOfSlots];
	}
}
