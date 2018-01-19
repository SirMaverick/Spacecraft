using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour {

    RaycastHit hit;
    Vector3 frontPos, midPos, backPos, leftPos, rightPos;
    public float frontHeight, midHeight;
    [SerializeField] float minDistance;

    string heightDifference;

    public float yRotation = 0.0F;
    public float xRotation = 0.0f;

    public float xPosition;
    public float zPosition;

    // Use this for initialization
    void Start () {
	}

    // Update is called once per frame
    void Update() {
        //xPosition = Input.GetAxis("Horizontal") * 3.0f * Time.deltaTime;
        //zPosition = Input.GetAxis("Vertical") * 3.0f * Time.deltaTime;  
        //transform.localPosition += transform.forward * xPosition;
        //transform.eulerAngles = new Vector3(xRotation, yRotation, 0);

        midPos = transform.position;
        frontPos = midPos + transform.forward;
        backPos = midPos - transform.forward;

        if (Physics.Raycast(midPos, -transform.up, out hit)) {
            midHeight = hit.distance;
        }
        if (Physics.Raycast(frontPos, -transform.up, out hit)) {
            frontHeight = hit.distance;
        }

        if (midHeight - frontHeight > 0.02) {
            RotateSpaceShip(1.0f);
        } else if (midHeight - frontHeight < -0.02) {
            RotateSpaceShip(-1.0f);
        }

        if(midHeight < minDistance - 0.02f) {
            MoveSpaceShip(1);
        } else if (midHeight > minDistance + 0.02f) {
            MoveSpaceShip(-1);
        }

    }    
        /*Physics.Raycast(transform.position, Vector3.down, out hit);
        if(hit.collider) {
            height = hit.distance;
            if(height < minDistance) {
                MoveStarshipVertical();
            }
        }

        Physics.Raycast(transform.position, transform.forward, out hit);
        if(hit.collider) {
            horizontalDistance = hit.distance;
            degrees = Mathf.Atan(horizontalDistance / height) * Mathf.Rad2Deg;
            print(degrees);
            if (horizontalDistance < minDistance ) {
                
            }
            if(degrees > 10.0f) {
                RotateSpaceShip();
            }
        }*/


    void RotateSpaceShip(float a) {
        xRotation -= 90.0f * a * Time.deltaTime;
        transform.eulerAngles = new Vector3(xRotation, yRotation, 0);
    }

    void MoveSpaceShip(float a) {
        Vector3 position = transform.position;
        position.y += 5.0f * a * Time.deltaTime;
        transform.position = position;
    }
}
