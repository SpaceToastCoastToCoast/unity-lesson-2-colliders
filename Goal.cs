using UnityEngine;
using System.Collections;

public class Goal : MonoBehavior {

  private int timer = 0;
  private int timeLimit = 60;

  //All colliders have three trigger methods: OnTriggerEnter, OnTriggerStay and OnTriggerExit.
  //OnTriggerEnter fires only once, and happens when another object enters the trigger.
  //You can use this, for example, to mark when a character is in range of another character to attack.
  void OnTriggerEnter(Collider other) {
    //We will check the tag of the other collider to make sure it is the player.
    //Otherwise, this would fire whenever any collider intersected with it, even if it's something like a wall.

    //We use .gameObject to check the tag of the object the collider is attached to,
    //because the collider is just a component and can't have its own tag.
    //CompareTag checks if the object's tag is equal to this string.
    if(other.gameObject.CompareTag("Player")) {
      //Debug.Log will print things to the console.
      Debug.Log("You reached the goal!")
    }
  }

  //OnTriggerStay fires every frame when an object stays inside the trigger.
  //You could use this, for example, to deal constant damage while a character stands in a pit of lava.
  void OnTriggerStay(Collider other) {
    //This will fire constantly if we don't set a timer on it.
    timer++;
    if(timer >= timeLimit) {
      //If the timer is greater or equal to the time limit, we reset the timer and display the message.
      //The timer check above will print the text below once every second.
      timer = 0;
      Debug.Log("You're chilling out in the goal zone.")
    }
  }

  //OnTriggerExit fires once per entry when the collider leaves the trigger.
  //You could use this to make an enemy behave differently when the player is no longer visible to it.
  void OnTriggerExit(Collider other) {
    Debug.Log("You left the goal zone.")
  }

}