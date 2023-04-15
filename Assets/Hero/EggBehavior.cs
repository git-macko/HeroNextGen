using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //bullets gets destroyed offscreen
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            Destroy(this.gameObject);
            HeroGUIScript.EggOnScreen--;
        }
        
    }

    //Hits enemies
    private void OnTriggerEnter2D(Collider2D col)
    {
        //hitting vanilla planes
        VPlaneEnemyScript vPlaneEnemy = col.GetComponent<VPlaneEnemyScript>();
        if(col.gameObject.CompareTag("VanillaPlaneEnemy"))
        {
            //damage 25 per hit (Vanilla Plane Health = 100)
            vPlaneEnemy.TakeDamage(25);
            Destroy(this.gameObject);
            //update GUI
            HeroGUIScript.EggOnScreen--;
        }
            
        


        //hitting routes
        WaypointScript wp = col.GetComponent<WaypointScript>();
        if(col.gameObject.CompareTag("Route"))
        {
            Destroy(this.gameObject);
            wp.TakeDamage(25);
            //update GUI
            HeroGUIScript.EggOnScreen--;
        }
        
        
    }
}
