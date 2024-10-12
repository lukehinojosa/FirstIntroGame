using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f;

    public Rigidbody rb;

    public bool grounded;
    
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
            
            if (!grounded)
                transform.position = new Vector3(transform.position.x, rightHit.point.y, transform.position.z);//This fixes the height of the object when falling onto the ground

            if (grounded && Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(Vector2.up * (jumpSpeed * Time.deltaTime));
                grounded = false;
            }
        }
        else
        {
            grounded = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * (moveSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * (moveSpeed * Time.deltaTime));
        }
    }
}
