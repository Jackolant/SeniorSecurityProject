using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinding_prototype : MonoBehaviour {

    public GameObject objective;
    private float objectiveX = 0;
    private float objectiveZ = 0;


    public float pathfind_Time_Interval = 1;
    public bool pathfind_bool = true;
    public enum directions
    {
        North, //-x
        South, //+x
        East, //+z
        West  //-z
    };
    public directions Current_Direction;
    public directions Direction_From;
    public float speed = 1;
    


	// Use this for initialization
	void Start () {
        //find initial distance from objective
        objectiveX = objective.transform.position.x - transform.position.x;
        objectiveZ = objective.transform.position.z - transform.position.z;
        //find and set the current direction
        Current_Direction = FindFirstDirection();
        Direction_From = Current_Direction;
        //start the pathfind co-routine
        StartCoroutine(Pathfind());
	}
	

    /// <summary>
    /// Pathfinding co-routine to move the AI
    /// </summary>
    /// <returns></returns>
    IEnumerator Pathfind()
    {
        while(pathfind_bool)
        {
            moveAI();
            yield return new WaitForSeconds(pathfind_Time_Interval);
        }
    }
    
    /// <summary>
    /// Move logic for the AI
    /// </summary>
    void moveAI()
    {
        if (Current_Direction == directions.North)
        {
            transform.Translate(speed * -1, 0, 0);
        }
        else if (Current_Direction == directions.South)
        {
            transform.Translate(speed, 0, 0);
        }
        else if (Current_Direction == directions.East)
        {
            transform.Translate(0, 0, speed);
        }
        else if (Current_Direction == directions.West)
        {
            transform.Translate(0, 0, speed * -1);
        }
        else
        {
            print("Error at pathfinding_prototype.cs: moveAI: Current Direction is Invalid");
        }
    }

    /// <summary>
    /// check if in collission with the walls
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)
    {
        

        if (collision.gameObject.tag == "Wall")
        {
            //directions temp = newDirection();
            Direction_From = Current_Direction;
            //Current_Direction = temp;
        }
    }

    /*directions newDirection() 
    {
        if (Current_Direction == directions.North)
        {
            if ((Direction_From == directions.North) || (Direction_From == directions.South))
            {
                if (objectiveZ < 0)
                {
                    return directions.West;
                }
                else
                {
                    return directions.East;
                }
            }
            else if (Direction_From == directions.East)
            {
                return directions.South;
            }
            else if (Direction_From == directions.West)
            {
                return directions.South;
            }
        }
        else if (Current_Direction == directions.South)
        {
            if (Current_Direction == directions.North)
            {
                if ((Direction_From == directions.South) || (Direction_From == directions.North))
                {
                    if (objectiveZ < 0)
                    {
                        return directions.West;
                    }
                    else
                    {
                        return directions.East;
                    }
                }
                else if (Direction_From == directions.East)
                {
                    return directions.North;
                }
                else if (Direction_From == directions.West)
                {
                    return directions.North;
                }
            }
            else if (Current_Direction == directions.East)
            {
                if (Current_Direction == directions.North)
                {
                    if ((Direction_From == directions.South) || (Direction_From == directions.North))
                    {
                        if (objectiveZ < 0)
                        {
                            return directions.West;
                        }
                        else
                        {
                            return directions.East;
                        }
                    }
                    else if (Direction_From == directions.East)
                    {
                        return directions.North;
                    }
                    else if (Direction_From == directions.West)
                    {
                        return directions.North;
                    }
                }
            }
            else if (Current_Direction == directions.West)
            {

            }
        }
    }*/

    /// <summary>
    /// Finds the first direction the AI should initially head.
    /// </summary>
    /// <returns></returns>
    directions FindFirstDirection()
    {
    //find which one is bigger to find out what direction to try first
        float tempx = objectiveX;
        float tempz = objectiveZ;
        if (objectiveX < 0)
        {
            tempx = objectiveX * -1;
        }
        if (objectiveZ < 0)
        {
            tempz = objectiveZ * -1;
        }
     //find the first direction to try
        if (tempz == tempx)
        {
            if (objectiveX < 0)
            {
                return directions.North;
            }
            else
            {
                return directions.South;
            }
        }
        else if (tempx > tempz)
        {
            if (objectiveX < 0)
            {
                return directions.North;
            }
            else
            {
                return directions.South;
            }
        }
        else
        {
            if (objectiveZ < 0)
            {
                return directions.West;
            }
            else
            {
                return directions.East;
            }
        }
    }
}
