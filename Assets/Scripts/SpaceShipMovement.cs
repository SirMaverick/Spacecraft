using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{

    // Scoping too broad: lots of class variables for no reason
    // Constrain scope of your variables. 
    // Don't leak out data where it doesn't need to be. 
    // Don't keep data around longer than it needs to be.
    RaycastHit hit;
    Vector3 frontPos, midPos, backPos;
    public float frontHeight, midHeight;

    [SerializeField] float minDistance;
    public float yRotation = 0.0F;
    public float xRotation = 0.0f;


    void Update()
    {
        midPos = transform.position; 
        // use more expressive naming, e.g. shipPos. 
        // Good: storing in local variable limits engine calls

        frontPos = midPos + transform.forward;
        // this only takes the position and adds 1,0,0 to it?
        // if anything, it should be relative to ship's length

        backPos = midPos - transform.forward;
        // this takes the position and subtracts 1,0,0 from it?
        // if anything, it should be relative to ship's length

        // use distance for raycast (we now compare it later). also limit by layermask
        if (Physics.Raycast(midPos, -transform.up, out hit))
        {
            midHeight = hit.distance;
        }

        // use distance for raycast (we now compare it later). also limit by layermask
        if (Physics.Raycast(frontPos, -transform.up, out hit))
        { // another expensive raycast?
            frontHeight = hit.distance;
        }

        // Notes(gb): why hardcoded 0.02? this should be relative
        if (midHeight - frontHeight > 0.02)
        {
            RotateSpaceShip(1.0f); // rotate how? this should not be a seperate function
        }
        else if (midHeight - frontHeight < -0.02)
        {
            RotateSpaceShip(-1.0f); // rotate how? this should not be a seperate function
        }

        if (midHeight < minDistance - 0.02f)
        {
            MoveSpaceShip(1); // move ship how? this should not be a seperate function
        }
        else if (midHeight > minDistance + 0.02f)
        {
            MoveSpaceShip(-1); // move ship how? this should not be a seperate function
        }
    }

// are we calling these functions somewhere else?
// dont make functions for naming sake...
// Prefer commenting sections over extracting them. 
// Whenever you have a function, it implicitly says it can be called from anywhere inside the class.
// Never have a function do something that happens in only one place.
void RotateSpaceShip(float a) { // better naming for 'a'
        xRotation -= 90.0f * a * Time.deltaTime;
        transform.eulerAngles = new Vector3(xRotation, yRotation, 0);
    }

void MoveSpaceShip(float a) { // better naming for 'a'
        Vector3 position = transform.position; // we already grabbed this as midPos.
        position.y += 5.0f * a * Time.deltaTime; // hardcoded 5.0f
        transform.position = position;
    }
}
