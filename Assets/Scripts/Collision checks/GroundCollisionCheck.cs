using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The player has a small collider marked as trigger in front of him (child GameObject).
// Trigger function will be called when this collider enter in contact with a wall.
public class GroundCollisionCheck : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        // TODO: Add a tag called "Wall" to the walls and check if other.tag is equal to "Wall". (if requiered)
        var playerController = gameObject.GetComponentInParent<PlayerController>();
        playerController.onGroundCollisionEnter();
    }

    void OnTriggerExit(Collider other) {
        // TODO: Add a tag called "Wall" to the walls and check if other.tag is equal to "Wall". (if requiered)
        var playerController = gameObject.GetComponentInParent<PlayerController>();
        playerController.onGroundCollisionExit();
    }

}
