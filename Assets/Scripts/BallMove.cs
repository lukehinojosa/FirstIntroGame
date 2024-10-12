using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float moveAcc = 1f;
    public float jumpAcc = 1f;
    public float maxSpeed = 1f;
    
    public Rigidbody rb;

    public bool grounded;
    
    public AudioSource audioSource;
    public AudioClip jumpClip;
    private float jumpVolume = 0.5f;

    private Color startingColor;

    void Start()
    {
        startingColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }
    
    void Update()
    {
        RaycastHit rightHit;
        RaycastHit leftHit;
        if (Physics.Raycast(transform.TransformPoint(Vector3.right / 2), Vector3.down, out rightHit, transform.TransformPoint(Vector3.right / 2).y - transform.TransformPoint(Vector3.down / 2).y))
        {
            Debug.DrawLine(transform.TransformPoint(Vector3.right / 2), rightHit.point, Color.red);
        }
        
        if (Physics.Raycast(transform.TransformPoint(Vector3.left / 2), Vector3.down, out leftHit, transform.TransformPoint(Vector3.left / 2).y - transform.TransformPoint(Vector3.down / 2).y))
        {
            Debug.DrawLine(transform.TransformPoint(Vector3.left / 2), leftHit.point, Color.red);
        }
        
        if (rb.velocity.y <= 0 && Physics.Raycast(transform.position, Vector3.down, out rightHit, transform.TransformPoint(Vector3.right / 2).y - transform.TransformPoint(Vector3.down / 2).y) && Physics.Raycast(transform.TransformPoint(Vector3.left / 2), Vector3.down, out leftHit, transform.TransformPoint(Vector3.left / 2).y - transform.TransformPoint(Vector3.down / 2).y))
        {
            grounded = true;

            GetComponent<MeshRenderer>().material.color = startingColor;
            
            if (!grounded)
                transform.position = new Vector3(transform.position.x, rightHit.point.y, transform.position.z);//This fixes the height of the object when falling onto the ground

            if (grounded && Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(Vector2.up * jumpAcc / rb.mass);
                
                grounded = false;

                audioSource.PlayOneShot(jumpClip, jumpVolume);
            }
        }
        else
        {
            grounded = false;
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            if (!grounded)
                GetComponent<MeshRenderer>().material.color = Color.magenta;
            
            if (rb.velocity.x > -maxSpeed)
                rb.AddForce(Vector2.left * (moveAcc * Time.deltaTime / rb.mass));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            if (!grounded)
                GetComponent<MeshRenderer>().material.color = Color.magenta;
            
            if (rb.velocity.x < maxSpeed)
                rb.AddForce(Vector2.right * (moveAcc * Time.deltaTime / rb.mass));
        }
    }
}
