using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPlaneEnemyScript : MonoBehaviour
{
    
    public GameObject[] waypoints;
    int current=0;
    public float speed;
    private float WPradius = 15f;
    public static bool wpToggle;

    public Rigidbody2D rigBod;
    public float alphaLevel = 1f;
    private int enemyHP = 100;

    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();
        
    }
    
    void FixedUpdate()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Route");


        ToggleWaypoints(waypoints);
        
        

        //point at waypoint
        PointAtPosition(waypoints[current].transform.position, 1 * Time.smoothDeltaTime);
    }

    private void ToggleWaypoints(GameObject[] waypoints)
    {
        if(wpToggle == false)
        {
            HeroGUIScript.Waypoints = "Random";
            RandomWaypoints(waypoints);
        }
        else
        {
            HeroGUIScript.Waypoints = "Sequence";
            SequenceWaypoints(waypoints);
        }
    }
    private void SequenceWaypoints(GameObject[] waypoints)
    {
       if (Vector2.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

    }
    private void RandomWaypoints(GameObject[] waypoints) 
    {
        
        if (Vector2.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current = Random.Range(0, waypoints.Length);
            if (current >= waypoints.Length)
            {
                current = 0;
            }

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }
    }
    private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.position;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
    }

    //TakeDamage
    public void TakeDamage(int damage)
    {

        //Damage Color Effect
        alphaLevel -= 0.25f;
        GetComponent<SpriteRenderer>().color = new Color (1,1,1, alphaLevel);

        //Damage HP effect
        enemyHP -= damage;
        if(enemyHP <= 0)
        {
            Destroy(gameObject);
            
            //update spawner
            HeroGUIScript.VanillaPlaneCount--;
            EnemySpawner.enemySpawned--;
        }
    }

    
}
