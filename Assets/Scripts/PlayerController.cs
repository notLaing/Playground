using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CURRENTLY ATTACHED TO: Player

public class PlayerController : MonoBehaviour
{
    //player/camera movement variables
    CharacterController player;
    public Transform cam;
    private Vector3 camOffset = new Vector3(0f, 7f, -6f);
    private float speed = 10f;
    private float gravity = -20f;
    private float jumpImpulse = 20f;
    private Vector3 velocity = Vector3.zero;
    private float speedY = 0;
    private float v, h;

    //rotation in mouse direction
    private Vector3 intersection;
    private Vector3 diff;

    //public HUDController healthBar;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement input
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        //Rotation
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        float distance = 0;

        if (plane.Raycast(ray, out distance))
        {
            intersection = ray.GetPoint(distance);
            diff = intersection - transform.position;

            float angle = Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 90 - angle, 0);
        }

        //Time slow rotation. Use lerp

        //Move
        velocity = new Vector3(h * speed, speedY, v * speed);

        //if player is on ground, they can jump and spawn particles while moving
        if (player.isGrounded)
        {
            if (Input.GetButton("Jump")) speedY = jumpImpulse;
            else speedY = 0;
        }

        speedY += (gravity * Time.deltaTime);
        player.Move(velocity * Time.deltaTime);
        cam.position = transform.position + camOffset;
    }

    void Pause()
    {
        Time.timeScale = 0;
    }
}
