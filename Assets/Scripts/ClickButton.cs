using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public int squareNumber = 0; //Number of the square
    private bool placed; //If there is a gameobject in the squarespace
    private void OnTriggerEnter(Collider collision)
    {
        //If the collision tag of the object equals player
        if(collision.tag=="Player")
        {
            //if placed is equal to false
            if (placed == false)
            {
                //Find the game object GameManager and call the method square with this gameObject as an argument
                GameObject.Find("GameManager").SendMessage("Square", gameObject);
                //Destroy the player script on the object
                Destroy(collision.GetComponent<Player>());
                //Set placed to true
                placed = true;
            }
            else 
            {
                //Destroy the gameobject
                Destroy(collision.gameObject);
                //Find the object GameManager and tell it to respawn the player
                GameObject.Find("GameManager").SendMessage("Respawn");
            }
        }
    }
}
