using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f;

    public Rigidbody rb;
    
    void Update()
    {
        RaycastHit rightHit;
        RaycastHit leftHit;
        if (Physics.Raycast(transform.TransformPoint(Vector3.right / 2), Vector3.down, out rightHit, Mathf.Infinity))
        {
            Debug.DrawLine(transform.TransformPoint(Vector3.right / 2), rightHit.point, Color.red);
        }
        
        if (Physics.Raycast(transform.TransformPoint(Vector3.left / 2), Vector3.down, out leftHit, Mathf.Infinity))
        {
            Debug.DrawLine(transform.TransformPoint(Vector3.left / 2), leftHit.point, Color.red);
        }
        
        if (rb.velocity.y < 0 && Input.GetKeyDown(KeyCode.W) && Physics.Raycast(transform.position, Vector3.down, out rightHit, Mathf.Infinity) && Physics.Raycast(transform.TransformPoint(Vector3.left / 2), Vector3.down, out leftHit, Mathf.Infinity))
        {
            rb.AddForce(Vector2.up * (jumpSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * (moveSpeed *  Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * (moveSpeed *  Time.deltaTime));
        }
    }
}
