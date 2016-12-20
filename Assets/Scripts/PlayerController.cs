using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 0.04f;
    public float jumpSpeed = 15f;
    public float timeToJumpAgain = 0.2f;
    public float slidingOnWallDrag = 5f;
    public bool logEnabled = false;
    public LevelController level;

    // If direction is grater or equal than 0 the player will move to right
    // otherwise the player moves left.
    private int direction = 1;
    private float timePassed = 0f;
    private bool grounded = true;
    private bool wallCollision = false;

    private Rigidbody rb;
    private Animator animator;

    void Start () {
		rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); ;
    }

    private void Update() {
        timePassed += Time.deltaTime;
        changeDragIfNeeded();

        if (Input.GetButton("Jump")) {
            jump();
        }
    }

	void FixedUpdate () {
        animator.SetBool("Run", grounded && !wallCollision);
        move();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            level.win();
        }
        if (other.CompareTag("Trap"))
        {
            level.lose();
        }
    }

    // ----------------
    // Public Functions
    // ---------------- 

    // This function is called by GroundCollisionCheck when the player touches the floor.
    public void onGroundCollisionEnter() {
        Log("Player on ground collision enter");
        grounded = true;
    }

    // This function is called by GroundCollisionCheck when the player is not touching the floor.
    public void onGroundCollisionExit() {
        Log("Player on ground collision exit");
        grounded = false;
    }

    // This functions is called by WallCollisionCheck when the player touches a wall.
    public void onWallCollisionEnter() {
        Log("Player on wall collision enter");
        wallCollision = true;
    }

    // This function is called by WallCollisionCheck when the player move off from a wall.
    public void onWallCollisionExit() {
        Log("Player on wall collision exit");
        wallCollision = false;
    }

    // ----------------
    // Private Functions
    // ----------------

    private void changeDirection() {
        Log("Changing movement direction");
        if (direction == 0) {
            direction = 1;
        }
        direction *= -1;
    }
       
    private void move() {
        if (direction < 0) {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        } else {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    private void jump() {
        // Jump on wall
        if (!grounded && wallCollision && timePassed >= timeToJumpAgain) {
            Log("Jump on wall");
            timePassed = 0;
            changeDirection();
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            animator.SetTrigger("Jump");
        }

        // Normal jump
        if (grounded) {
            Log("Normal jump");
            timePassed = 0;
            grounded = false;
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            animator.SetTrigger("Jump");
        }
    }

    private void Log(string message) {
        if (logEnabled) {
            Debug.Log(message);
        }
    }

    private void changeDragIfNeeded() {
        // This code simulates sliding down a wall
        // when the player falls touching a wall
        if (wallCollision && rb.velocity.y < 0) {
            Log("Sliding down a wall");
            rb.drag = slidingOnWallDrag;
            animator.SetBool("Grab", true);
        } else {
            rb.drag = 0;
            animator.SetBool("Grab", false);
        }
    }

}
