﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class positionRecord
{

    Vector3 position; // The position of where the snake has been 


    int positionOrder; //  

    GameObject breadcrumbBox; // Breadcrumbox used to leave a breadcrumb trail after the snake 

    //Setting getters and setters as a security not to alter it from the inspector 
    public Vector3 Position { get => position; set => position = value; }
    public int PositionOrder { get => positionOrder; set => positionOrder = value; }
    public GameObject BreadcrumbBox { get => breadcrumbBox; set => breadcrumbBox = value; }
    public GameObject EnemyBreadBox { get => enemyBreadBox; set => enemyBreadBox = value; }

    private GameObject enemyBreadBox;
}

//---> Class


// ----> SnakeGenerator

public class SnakeGenerator : MonoBehaviour
{
    
    

    public int snakelength; // A public variable to set the size/length of the snake


    GameObject playerBox, breadcrumbBox, pathParent;

    List<positionRecord> pastPositions;

    int positionorder = 0;


    bool firstrun = true;


    void Start()
    {


        playerBox = Instantiate(Resources.Load<GameObject>("Player"), new Vector3(0f, 0f), Quaternion.identity); // Get the sprite(Square) from the resources file in the asset folderand create an instance of it to the player box 


        breadcrumbBox = Resources.Load<GameObject>("Player"); // Get the sprite(Square) from the resources file in the asset folder and attach it to the Gameobject breadcrumb box 

        playerBox.GetComponent<SpriteRenderer>().color = Color.black; // Set the playerbox to black


        playerBox.AddComponent<SnakeController>(); //  the snake head controller is added to the playerbox for the player to be able to move the head of the player

        playerBox.name = "Player"; // Setting the name to Player

        pastPositions = new List<positionRecord>();

        drawTail(GameManager.snakeLenghtdraw); //If the drawtail is removed from the start the first box behind the sneakhed won't be drawn 

    }

    void Update()
    {

        
        if (Input.anyKeyDown && !((Input.GetMouseButtonDown(0)
          || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))) && !Input.GetKeyDown(KeyCode.X) && !Input.GetKeyDown(KeyCode.Z) && !Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("a key was pressed " + Time.time);

            savePosition();

            drawTail(GameManager.snakeLenghtdraw);
        }


    }

    // ----> SnakeGenerator


    


    // ----->Cour

    void clearLastBox() // This will clear the the box at the end of the tail
    {
        foreach (positionRecord p in pastPositions)
        {

            Destroy(p.BreadcrumbBox); // Destroying the breadcrunbBox
        }
    }


    void drawTail(int length)
    {
        clearLastBox(); // If it is not run first the box will be added to snaketail so first we have to clear the last breadcrumb box 


        if (pastPositions.Count > length) // if the pastposition list count (the amount of elements in the list) is larger than the length of the snake
        {

            int tailStartIndex = pastPositions.Count - 1;  // setting the tail start box index (last breadbox box)
            int tailEndIndex = tailStartIndex - length; // Setting the last box index (breadbox box behind head)



            for (int snakeblocks = tailStartIndex; snakeblocks > tailEndIndex; snakeblocks--) // Starting at the startindex and going on until the startindex is larger than the tailEndIndex
            {

                pastPositions[snakeblocks].BreadcrumbBox = Instantiate(breadcrumbBox, pastPositions[snakeblocks].Position, Quaternion.identity); // Instatiating the breadcrumb box at index tailstartIndex in the pastpositions list which is of type position record 
                pastPositions[snakeblocks].BreadcrumbBox.GetComponent<SpriteRenderer>().color = Color.yellow; // Setting the colour for the insta box to yellow 
            }
        }

        if (firstrun) // Since the first time round the pastpositioncount will be zero we will run this method to populate pastposition
        {

            for (int count = length; count > 0; count--)
            {
                positionRecord fakeBoxPos = new positionRecord();
                float ycoord = count * -1; // Setting up the coordinate  to spawn the fakeboxpos
                fakeBoxPos.Position = new Vector3(0f, ycoord); //placing the facebokx pos 
                pastPositions.Add(fakeBoxPos);// adding the fakebox pos to the list 
            }
            firstrun = false; // then swithch it off so that we don't we enter the other if statment
            drawTail(length); // And draw the tail 

        }

    }

    bool boxExists(Vector3 positionToCheck) // comparing postion to check with our pastPosition list
    {


        foreach (positionRecord p in pastPositions) // traversing the pastPositions list 
        {

            if (p.Position == positionToCheck) // if the p.postions matches the postionToCeck
            {

                if (p.BreadcrumbBox != null) // and if there is a Breadcrumbox 
                {


                    return true; // return true 
                }
            }
        }

        return false;
    }

    void savePosition()
    {
        positionRecord currentBoxPos = new positionRecord();

        currentBoxPos.Position = playerBox.transform.position; // currentBoxPos Postions(postion in class position record) is set equal to the playerbox position
        positionorder++;  // incriment position order 
        currentBoxPos.PositionOrder = positionorder; // Position order for the current boxpos is set to position order



        pastPositions.Add(currentBoxPos); // currentbox is added to out pastpositions list 
        Debug.Log("Have made this many moves: " + pastPositions.Count);

    }

}
