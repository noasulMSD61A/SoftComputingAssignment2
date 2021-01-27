using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMove : MonoBehaviour
{
    
    Transform target; // a transform variable to store location of our target
    Path pathToFollow; // path variable to store the path created
    Seeker seeker;
    GameObject enemytrail;
    List<positionRecord> pastposEnemy;
    int posenemyOr = 0;
    int enemylength = GameManager.enemysnakeLenghtdraw;
    bool first = true;


    void Start()
    {

        StartCoroutine(updateGraph());
        StartCoroutine(path());
        enemytrail = Resources.Load<GameObject>("enemyTrail");
        pastposEnemy = new List<positionRecord>();
       


    }

    void Update()
    {
        //enemydrawTail(GameManager.enemysnakeLenghtdraw);
        print("length" + GameManager.enemysnakeLenghtdraw);
    }

    IEnumerator path()
    {
        AstarPath.active.Scan();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        seeker = GetComponent<Seeker>();
        pathToFollow = seeker.StartPath(this.transform.position, target.position);
        yield return seeker.IsDone();
        StartCoroutine(moveTowards(this.transform));
    }

    IEnumerator moveTowards(Transform pos)
    {
        while (true) //creation of infinte loop
        {
            List<Vector3> positns = pathToFollow.vectorPath;//creating a list of positions that converts our path to avector form
            for (int count = 0; count < positns.Count; count++)//this loop is traversing for every posision with counter
            {
                while (Vector3.Distance(pos.position, positns[count]) >= 1f)//while the distance of the enemy from the position of the ai is more than 0.5f
                {
                    
                    pos.position = Vector3.MoveTowards(pos.position, positns[count], 1f);//move the position of the ai to the position of the enemy
                    savePosition();
                    enemydrawTail(GameManager.enemysnakeLenghtdraw);
                    pathToFollow = seeker.StartPath(pos.position, target.position);//making sure that the ai will not follow the path back when its done by removing the path
                    yield return seeker.IsDone();//making sure that the attempt to find it is done when it is on the enemy pos
                    yield return new WaitForSeconds(0.2f);//wait 

                }
            }
            yield return null;
        }
        
    }


    
    IEnumerator updateGraph()
    {
        while (true)
        {
            AstarPath.active.Scan();
            yield return null;
        }
    }

    void clearLastBox() // This will clear the the box at the end of the tail
    {

        foreach (positionRecord p in pastposEnemy)
        {

            Destroy(p.EnemyBreadBox); // Destroying the breadcrunbBox
        }
    }


    void enemydrawTail(int length)
    {
        clearLastBox();




        if (pastposEnemy.Count >= length) // if the pastposition list count (the amount of elements in the list) is larger than the length of the snake
        {


            int tailStartIndex = pastposEnemy.Count - 1;  // setting the tail start box index (last breadbox box)
            int tailEndIndex = tailStartIndex - length; // Setting the last box index (breadbox box behind head)



            for (int snakeblocks = tailStartIndex; snakeblocks > tailEndIndex; snakeblocks--) // Starting at the startindex and going on until the startindex is larger than the tailEndIndex
            {

                pastposEnemy[snakeblocks].EnemyBreadBox = Instantiate(enemytrail, pastposEnemy[snakeblocks].Position, Quaternion.identity); // Instatiating the breadcrumb box at index tailstartIndex in the pastpositions list which is of type position record 


                 // Setting the colour for the insta box to yellow 
            }
        }



        if (first) // Since the first time round the pastpositioncount will be zero we will run this method to populate pastposition
        {

            for (int count = length; count > 0; count--)
            {



                positionRecord efakeBoxPos = new positionRecord();
                float ycoord = count; // Setting up the coordinate  to spawn the fakeboxpos
                efakeBoxPos.Position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y); //placing the facebokx pos 
                pastposEnemy.Add(efakeBoxPos);// adding the fakebox pos to the list
                print("inside first run");

            }

            first= false; // then swithch it off so that we don't we enter the other if statment
            enemydrawTail(GameManager.enemysnakeLenghtdraw); // And draw the tail



        }

    }
    ///--->
    ///-->
    bool boxExists(Vector3 positionToCheck) // comparing postion to check with our pastPosition list
    {


        foreach (positionRecord p in pastposEnemy) // traversing the pastPositions list 
        {

            if (p.Position == positionToCheck) // if the p.postions matches the postionToCeck
            {

                if (p.EnemyBreadBox != null) // and if there is a Breadcrumbox 
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

        currentBoxPos.Position = this.gameObject.transform.position; // currentBoxPos Postions(postion in class position record) is set equal to the playerbox position
        posenemyOr++;  // incriment position order 
        currentBoxPos.PositionOrder = posenemyOr; // Position order for the current boxpos is set to position order

        if (!boxExists(this.gameObject.transform.position)) // boxExists our method returns True/False and is checking the playerbox.transform position and if it matches 
                                                            //This is run if it is false so the box doesnt exists 
        {
            print("inside save");
            currentBoxPos.EnemyBreadBox= Instantiate(enemytrail, this.transform.position, Quaternion.identity);  // if box doesnt exists instintiate a bread box  at playerbox position
            
            currentBoxPos.EnemyBreadBox.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }

        pastposEnemy.Add(currentBoxPos); // adding to the past positions
        Debug.Log("Have made this many moves: " + pastposEnemy.Count);

    }
    


}
