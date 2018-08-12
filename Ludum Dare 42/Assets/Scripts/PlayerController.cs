using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 20f;
    public float turnSpeed = 200f;
    public float xMin = -25, xMax = 25;
    public float zMin = -25, zMax = 25;
    public Rigidbody rb;
    float playerWidth = 1.5f;
    public Light blinky;	
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	
	void Update () {
		
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
            rb.MovePosition(this.transform.position + ((this.transform.rotation * Vector3.up) * speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            rb.MovePosition(this.transform.position + ((this.transform.rotation * Vector3.down) * speed * Time.deltaTime));
        }
        float tempx = Mathf.Clamp(transform.position.x, xMin + playerWidth, xMax - playerWidth);
        float tempz = Mathf.Clamp(transform.position.z, zMin + playerWidth, zMax - playerWidth);


        if (tempx != transform.position.x || tempz != transform.position.z) {
            transform.position = new Vector3(tempx, 2f, tempz);    
        }

        blinky.intensity = Mathf.Sin(Time.time);


        }

        
           
        



	}
