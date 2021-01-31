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
    List<GameObject> seekerMode;
    GameObject seekmode;
    List<positionRecord> pastposEnemy;
    int posenemyOr = 0;
    int enemylength = GameManager.enemysnakeLenghtdraw;
    bool first = true;
    bool pressed = true;


    void Start()
    {
        StartCoroutine(updateGraph());
        StartCoroutine(path());
        enemytrail = Resources.Load<GameObject>("enemyTrail");
        pastposEnemy = new List<positionRecord>();
        seekerMode = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(seekerPaint());  
        }   
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

    void destroySeeker()
    {
        foreach(GameObject t in seekerMode)
        {
            Destroy(t);
        }
    }
    //TASK 8
    IEnumerator seekerPaint() // drawn instantiated objects on the vector path when t is pressed.
    {
        destroySeeker();
        List<Vector3> seekpositns = pathToFollow.vectorPath;
        if (seekpositns.Count == 0)
        {
            yield return new WaitForSeconds(2f);//if the seeker has not yest been created wait 2 seconds 
        }
        
        for (int i = 0; i < seekpositns.Count; i++)
        {
            seekmode = Instantiate(Resources.Load<GameObject>("SeekerMode"), seekpositns[i], Quaternion.identity);//instantiating game object on the list seek position which has the vector path stored in it
            seekmode.GetComponent<SpriteRenderer>().sortingOrder = -1;//arrange snake to be on top of the instantiated game object 
            seekerMode.Add(seekmode);//add seekmode to list seekermode
        }

        if (seeker.IsDone())
        {
            yield return new WaitForSeconds(4f);//if the seeker is done run the method destroseeker() which removes the instantiated object
            destroySeeker();
        }

        yield return null;
    }
    
    IEnumerator updateGraph()
    {
        while (true)
        {
            AstarPath.active.Scan();
            yield return null;
        }
    }

    void clearLastBox()
    {
        foreach (positionRecord p in pastposEnemy)
        {

            Destroy(p.EnemyBreadBox);
        }
    }


    void enemydrawTail(int length)
    {
        clearLastBox();
        if (pastposEnemy.Count >= length)
        {
            int tailStartIndex = pastposEnemy.Count - 1; 
            int tailEndIndex = tailStartIndex - length; 
            for (int snakeblocks = tailStartIndex; snakeblocks > tailEndIndex; snakeblocks--) 
            {
                pastposEnemy[snakeblocks].EnemyBreadBox = Instantiate(enemytrail, pastposEnemy[snakeblocks].Position, Quaternion.identity);
            }
        }

        if (first)
        {
            for (int count = length; count > 0; count--)
            {
                positionRecord efakeBoxPos = new positionRecord();
                float ycoord = count; 
                efakeBoxPos.Position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y); //placing the facebokx pos 
                pastposEnemy.Add(efakeBoxPos);
            }
            first= false; 
            enemydrawTail(GameManager.enemysnakeLenghtdraw);
        }
    }
   
    bool boxExists(Vector3 positionToCheck) 
    {
        foreach (positionRecord p in pastposEnemy)
        {
            if (p.Position == positionToCheck)
            {
                if (p.EnemyBreadBox != null) 
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
        currentBoxPos.Position = this.gameObject.transform.position; 
        posenemyOr++;  
        currentBoxPos.PositionOrder = posenemyOr; 

        if (!boxExists(this.gameObject.transform.position))                                      
        {
            currentBoxPos.EnemyBreadBox= Instantiate(enemytrail, this.transform.position, Quaternion.identity); 
            currentBoxPos.EnemyBreadBox.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
        pastposEnemy.Add(currentBoxPos); 
    }
}
