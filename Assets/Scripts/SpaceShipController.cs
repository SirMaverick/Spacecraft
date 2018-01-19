using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour {

    CameraController camController;
    [SerializeField] GameObject spaceShip;

    float axisHor;
    float axisVer;

	// Use this for initialization
	void Start () {
        camController = GetComponent<CameraController>();

	}
	
	// Update is called once per frame
	void Update () {
        axisHor = Input.GetAxis("Horizontal") * 3.0f * Time.deltaTime;
        axisVer = Input.GetAxis("Vertical") * 3.0f * Time.deltaTime;

        Vector3 inputVector = axisHor * transform.right + axisVer * transform.forward;
        Vector3 worldInputVector = spaceShip.transform.InverseTransformDirection(inputVector);
        spaceShip.transform.position += worldInputVector;

        /*if (axisHor != 0 && axisVer != 0) {
            Vector3 aimPoint = camController.transform.forward * axisVer + camController.transform.right * axisHor;
            print(aimPoint);
            spaceShip.transform.LookAt(aimPoint);
        }*/
        /*
        Vector3 cameraToWorld = camController.transform.TransformDirection(camController.transform.forward);
        print(cameraToWorld);
        Vector3 normCameraToWorld = cameraToWorld.normalized;

        spaceShip.transform.position += new Vector3(spaceShip.transform.right.x * normCameraToWorld.x * axisHor, 0, spaceShip.transform.forward.z * normCameraToWorld.z * axisVer);
        */
        /*
        float angle = camController.transform.eulerAngles.y;
        Vector3 lookPoint = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
        print(lookPoint);
        //spaceShip.transform.position += new Vector3(spaceShip.transform.InverseTransformDirection(lookPoint).x * 3.0f * Time.deltaTime, 0, spaceShip.transform.InverseTransformDirection(lookPoint).z * 3.0f * Time.deltaTime);
        //print(spaceShip.transform.InverseTransformDirection(lookPoint));
        spaceShip.transform.position += spaceShip.transform.InverseTransformDirection(axisHor * lookPoint * transform.right.x + axisVer * (lookPoint + transform.forward));
        //print(lookPoint);
        //print((axisHor * lookPoint));
        */
        //spaceShip.transform.position += new Vector3(lookPoint.x * axisHor, 0, lookPoint.z * axisVer);



        /*
         * gebruikteVector ( input x , 0 , input z ) naar World
         * object dat verplaatst wordt + gebruikteVectorWorld
          
         


    */
    }
}
