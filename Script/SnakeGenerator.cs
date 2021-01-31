using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class positionRecord
{

    Vector3 position; 
    private GameObject enemyBreadBox;
    int positionOrder;   
    GameObject breadcrumbBox; 

    
    public Vector3 Position { get => position; set => position = value; }
    public int PositionOrder { get => positionOrder; set => positionOrder = value; }
    public GameObject BreadcrumbBox { get => breadcrumbBox; set => breadcrumbBox = value; }
    public GameObject EnemyBreadBox { get => enemyBreadBox; set => enemyBreadBox = value; }

    
}


public class SnakeGenerator : MonoBehaviour
{
    public int snakelength;
    GameObject playerBox, breadcrumbBox, pathParent;
    List<positionRecord> pastPositions;
    int positionorder = 0;
    bool firstrun = true;


    void Start()
    {
        playerBox = Instantiate(Resources.Load<GameObject>("Player"), new Vector3(0f, 0f), Quaternion.identity); 
        breadcrumbBox = Resources.Load<GameObject>("Player");
        playerBox.GetComponent<SpriteRenderer>().color = Color.black;
        playerBox.AddComponent<SnakeController>();
        playerBox.name = "Player"; 
        pastPositions = new List<positionRecord>();
        drawTail(GameManager.snakeLenghtdraw); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) && !((Input.GetMouseButtonDown(0)
          || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))) && !Input.GetKeyDown(KeyCode.X) && !Input.GetKeyDown(KeyCode.Z) && !Input.GetKeyDown(KeyCode.Space))
        {
            savePosition();
            drawTail(GameManager.snakeLenghtdraw);
        }
    }

    void clearLastBox()
    {
        foreach (positionRecord p in pastPositions)
        {
            Destroy(p.BreadcrumbBox);
        }
    }


    void drawTail(int length)
    {
        clearLastBox();
        if (pastPositions.Count > length)
        {
            int tailStartIndex = pastPositions.Count - 1;
            int tailEndIndex = tailStartIndex - length;

            for (int snakeblocks = tailStartIndex; snakeblocks > tailEndIndex; snakeblocks--)
            {

                pastPositions[snakeblocks].BreadcrumbBox = Instantiate(breadcrumbBox, pastPositions[snakeblocks].Position, Quaternion.identity);
                pastPositions[snakeblocks].BreadcrumbBox.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }

        if (firstrun)
        {
            for (int count = length; count > 0; count--)
            {
                positionRecord fakeBoxPos = new positionRecord();
                float ycoord = count * -1;
                fakeBoxPos.Position = new Vector3(0f, ycoord);
                pastPositions.Add(fakeBoxPos);
            }
            firstrun = false;
            drawTail(length);
        }
    }

    bool boxExists(Vector3 positionToCheck)
    {
        foreach (positionRecord p in pastPositions)
        {
            if (p.Position == positionToCheck)
            {
                if (p.BreadcrumbBox != null) 
                {
                    return true; 
                }
            }
        }
        return false;
    }

    void savePosition()
    {
        positionRecord currentBoxPos = new positionRecord();
        currentBoxPos.Position = playerBox.transform.position;
        positionorder++; 
        currentBoxPos.PositionOrder = positionorder; 
        pastPositions.Add(currentBoxPos);
    }

}
