using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    Rigidbody2D rigidBody;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    // Start is called before the first frame update
    void Start() {
       rigidBody = GetComponent<Rigidbody2D>();
       surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update() {
        if (canMove == true) {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls() {
        canMove = false;
    }

    private void RotatePlayer() {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.AddTorque(-torqueAmount);
        }
    }

    private void RespondToBoost() {
        if(Input.GetKey(KeyCode.UpArrow)) {
            surfaceEffector2D.speed = boostSpeed;
        } else {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

}
