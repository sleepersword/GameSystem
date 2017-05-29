using UnityEngine;
using System.Runtime.InteropServices;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class CameraCharScript : MonoBehaviour
{
    public CharacterScript AttachedChar;

    public Vector3 LookAtOffset = new Vector3(0,10,0);

    // The distance in the x-z plane to the target
    public float Distance = 30f;
    // the height we want the camera to be above the target
    public float Height = 15f;
    // How much we damp
    public float HeightDamping = 5.0f;
    public float RotationDamping = 5.0f;

    public float SensX = 100.0f;
    public float SensY = 100.0f;

    public GameObject ActiveObj;
    public float MaxDistanceToObj = 5f;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        handleKeyboard();
        handleMouse();

        adjustCamera();

        raycastActiveObj();
    }

    private void handleKeyboard()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            Debug.Break();
        }
    }

    private void handleMouse()
    {
        float heightDif = Input.GetAxis("Mouse Y") * Time.deltaTime * SensY;
        if ( !((Height - heightDif) >= 40 || (Height - heightDif) <= -10))
        { Height -= heightDif; }

        #region Scroll
        float distanceDif = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 300;
        if (!((Distance - distanceDif) >= 50 || (Distance - distanceDif) <= 1))
        { Distance -= distanceDif; }

        //Camera.main.fieldOfView = Mathf.Clamp(-10 * scroll + Camera.main.fieldOfView, 1, 179);
        #endregion
    }

    private void adjustCamera()
    {
        // Calculate the current rotation angles
        float wantedRotationAngle = AttachedChar.transform.eulerAngles.y;
        float wantedHeight = AttachedChar.transform.position.y + Height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, RotationDamping * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, HeightDamping * Time.deltaTime);

        // Convert the angle into a rotation
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = AttachedChar.transform.position;
        transform.position -= currentRotation * Vector3.forward * Distance;

        // Set the height of the camera
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // Always look at the target
        transform.LookAt(AttachedChar.transform.position + LookAtOffset);
    }

    void raycastActiveObj()
    {
        //var ray = Camera.current.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        //RaycastHit hit;

        //Physics.Raycast(ray, out hit);

        //if (hit.distance <= MaxDistanceToObj)
        //{
        //    ActiveObj = hit.collider.gameObject;
        //}
        //else { ActiveObj = null; }
    }
}
