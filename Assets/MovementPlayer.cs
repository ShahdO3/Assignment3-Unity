using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] float speed = 9;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] GameObject cam = null;
    [SerializeField] float force = 1;
    [SerializeField] float gravity = -13.5f;
    [SerializeField] float jumpHeight = 3.5f;

    //[SerializeField] float speed = 9;
    private float cameraUp = 0f;
    private Vector3 velocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

    //          =========== ROTATING WITH CAM ==============

        Vector2 rotation = new Vector2(Input.GetAxis("Mouse X") * mouseSensitivity, 
                                        Input.GetAxis("Mouse Y") * mouseSensitivity);
        cameraUp -= rotation.y;
        cameraUp = Mathf.Clamp(cameraUp, -90f, 90f);

        //cam.transform.localEulerAngles = Vector2.right * cameraUp;
        cam.transform.localEulerAngles = Vector3.right*cameraUp;

        // =========== rotating player on Y-axis by the position of mouse =============

        //transform.Rotate(Vector3.up * rotation.x * mouseSensitivity);
        transform.Rotate(Vector3.up * rotation.x);

        //              =========== MOVING ==============
        var controller = GetComponent<CharacterController>();
        Vector2 pos = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (controller.isGrounded)
            velocity.y = 0f;
        
            velocity.y += gravity * Time.deltaTime;
        
        if (transform.position.y < 0) // if they fall we should reload the scene
            SceneManager.LoadScene(0);

        if (Input.GetButtonDown("Jump"))
            velocity.y = jumpHeight;
            //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        Vector3 move = (transform.right * pos.x) + (transform.forward * pos.y) + (Vector3.up * velocity.y);
        //transform.Translate(pos * speed * Time.deltaTime);
        controller.Move(speed * Time.deltaTime * move);
        //controller.Move(Time.deltaTime * move);
        // transform.position = (transform.position.x + pos.x);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.attachedRigidbody != null) // hit object has a rigid body attached
        {
            Vector3 forceDir = hit.gameObject.transform.position - transform.position;
            forceDir.y = 0; //not to move up 
            forceDir.Normalize();

            hit.collider.attachedRigidbody.AddForceAtPosition(forceDir * force, transform.position, ForceMode.Impulse);
         
        }
    }
}
