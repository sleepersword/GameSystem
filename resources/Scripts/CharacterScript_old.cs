using UnityEngine;
using System.Runtime.InteropServices;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class CharacterScript_Old : MonoBehaviour
{
    public float rotateSpeed = 10f;
    public float moveSpeed = 10f;

    public float JumpForceMultiplier = 2;

    void Start()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
    }

    void Update()
    {
        #region Sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        { moveSpeed *= 2; }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        { moveSpeed /= 2; }
        #endregion

        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 100 * JumpForceMultiplier, ForceMode.Impulse);
        }

        move();
    }

    void OnCollissionEnter(Collision col)
    {
        //GetComponent<Animator>().SetBool("IsFlying", false);
    }

    void OnCollissionExit(Collision col)
    {
        //GetComponent<Animator>().SetBool("IsFlying", true);
    }

    private void move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * -moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * -moveSpeed * Time.deltaTime;
        }

        float rotateY = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime * 10;
        transform.Rotate(0, rotateY ,0);
    }
}
