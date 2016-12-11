using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The player has a small collider marked as trigger in his feet (child GameObject).
// Triggers functions will be called when this collider interacts with the floor.
public class WallCollisionCheck : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        // TODO: Add a tag called "Floor" to the floor and check if other.tag is equal to "Floor". (if requiered)
        var playerController = gameObject.GetComponentInParent<PlayerController>();
        playerController.onWallCollisionEnter();
    }

    void OnTriggerExit(Collider other) {
        // TODO: Add a tag called "Floor" to the floor and check if other.tag is equal to "Floor". (if requiered)
        var playerController = gameObject.GetComponentInParent<PlayerController>();
        playerController.onWallCollisionExit();
    }

}
