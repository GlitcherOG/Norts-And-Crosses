using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject naught; //Naught Prefab
    public GameObject cross; //Cross Prefab
    public GameObject panel; //Winner panel
    public GameObject spawn; //Spawn location

    [Header("Text")]
    public Text turns; //Display whose turn it is
    public Text winnerText; //

    [Header("Other Varibles")]
    public int playerTurn; //How many turns 
    public int[] grid = new int[10]; //
    bool gameOver; //If the game is over

    int player = 1; //Whose players turn it is

    void Start()
    {
        //At start spawn prefab
        SpawnPrefab();
    }
    //When a piece is placed into a square 
    public void Square(GameObject square)
    {
        //Adds one to the ammount of turns
        playerTurn += 1;
        //Gets the square number off the script
        int squareNumber = square.GetComponent<ClickButton>().squareNumber;
        //In the array it changes the squares state
        grid[squareNumber] = player;
        //Checks for the winner
        CheckForWinner();
    }

    //Respawns the current players prefab
    public void Respawn()
    {
        SpawnPrefab();
    }

    //Checks for the winner
    void CheckForWinner()
    {
        //Checks if both players have won
        for (int i = 1; i < 3; i++)
        {
            //Goes through and using maths will check the rows and collums to see if one of the players have gotten three in a row
            for (int a = 0; a < 3; a++)
            {
                if (grid[1 + 3 * a] == i && grid[2 + 3 * a] == i && grid[3 + 3 * a] == i)
                {
                    Winner(i);
                }
                if (grid[1 + a] == i && grid[4 + a] == i && grid[7 + a] == i)
                {
                    Winner(i);
                }
            }
            //Check diagonal to see if there is three in a roll
            if (grid[1] == i && grid[5] == i && grid[9] == i)
            {
                Winner(i);
            }
            else
            if (grid[3] == i && grid[5] == i && grid[7] == i)
            {
                Winner(i);
            }
            else
            //Checks to see if they have reached the max ammount of possible turns
            if (playerTurn == 9)
            {
                Winner(3);
            }
        }
        //Goes to next turn
        NextTurn();
    }


    //Displays the winner
    void Winner(int winner)
    {
        //Sets gameover to true
        gameOver = true;
        //If the winner is three
        if (winner == 3)
        {
            winnerText.text = "Draw";
        }
        else
        {
            //If the winner is one change the text to say O is the winner
            if (winner == 1)
            {
                winnerText.text = "O Wins";
            }
            else //Else the winner is X
            {
                winnerText.text = "X Wins";
            }
        }
        //Set the winner panel to true
        panel.SetActive(true);
    }

    //Spawn the player prefab
    void SpawnPrefab()
    {
        //If player is one spawn the naught 
        if (player == 1)
        {
            Instantiate(naught, spawn.transform.position, spawn.transform.rotation);
        }
        //If player is two spawn the cross
        else if (player == 2)
        {
            Instantiate(cross, spawn.transform.position, spawn.transform.rotation);
        }
    }


    // Changes whos turn it is
    void NextTurn()
    {
        //If player is 1 change it to player 2 turn
        if (player == 1)
        {
            turns.text = "X Turn";
            player = 2;
        }
        else //If the player is 2 change it to player 1 turn
        {
            turns.text = "O Turn";
            player = 1;
        }
        if(!gameOver) // if it isnt game over spawn the prefab
        {
            SpawnPrefab();
        }
    }
}
