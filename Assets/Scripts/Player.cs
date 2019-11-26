using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid; //GameObjects rigidbody
    public float speed = 5f; //Speed of player movement
    private void Start()
    {
        //Get rigidbody from gameobject and set it into the variable rigid
        rigid = gameObject.AddComponent<Rigidbody>();
        //Change the constraints of the rigidbody to freeze the Y position and the rotation
        rigid.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
    void Update()
    {
        //Get the floats of the inputs Horizontal and vertical
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        //Get the Vector3 based on the input horizontal and vertical
        Vector3 direction = new Vector3(inputH, 0, inputV);
        //Add force based on the Vector3 muliplyed by the speed
        rigid.AddForce(direction * speed);
        //If the key e is true
        if(Input.GetKeyDown("e"))
        {
            //Remove all Rigidbody constraints
            rigid.constraints = RigidbodyConstraints.None;
        }
    }
}
