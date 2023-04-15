using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public Rigidbody2D rigBod;
    public float alphaLevel = 1f;
    private int routeHP = 100;
    private bool hideWP = false;
    public Renderer rend;

    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void Update()
    {
        //Waypoint toggle (Sequence/Toggle)
      
    
        if(Input.GetKeyDown(KeyCode.H))
        {
            hideWP = !hideWP;
        }
        HideWaypoints();
    }
    
    void HideWaypoints()
    {
        if(hideWP == false)
        {
            rend.enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = true;
        
        }
        else
        {
            rend.enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            VPlaneEnemyScript.wpToggle = false;
        }
    }

    //TakeDamage
    public void TakeDamage(int damage)
    {
        //Damage Color Effect
        alphaLevel -= 0.25f;
        GetComponent<SpriteRenderer>().color = new Color (1,1,1, alphaLevel);

        //Damage HP effect
        routeHP -= damage;
        if(routeHP <= 0)
        {
            Destroy(this.gameObject);
            //update spawner
        }
    }
}
