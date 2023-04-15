using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //vanilla plane
    [SerializeField] private GameObject VanillaPlaneEnemy;
    [SerializeField] public GameObject ARoute;
    [SerializeField] public GameObject BRoute;
    [SerializeField] public GameObject CRoute;
    [SerializeField] public GameObject DRoute;
    [SerializeField] public GameObject ERoute;
    [SerializeField] public GameObject FRoute;

    [SerializeField] private  int spawnLimit = 3;
    public static int enemySpawned;
    public static int aRouteSpawned;
    public static int bRouteSpawned;
    public static int cRouteSpawned;
    public static int dRouteSpawned;
    public static int eRouteSpawned;
    public static int fRouteSpawned;
    
    void Start()
    {
        // aRouteSpawned = 1;
        // bRouteSpawned = 1;
        // cRouteSpawned = 1;
        // dRouteSpawned = 1;
        // eRouteSpawned = 1;
        // fRouteSpawned = 1;
    }

    void Update()
    {

        //spawning vanillaplanes
        if(enemySpawned < spawnLimit)
        {
            SpawnVanillaPlane();
            enemySpawned++;

            //update GUI
            HeroGUIScript.VanillaPlaneCount++;
        }

        if(aRouteSpawned < 1)
        {
            SpawnRoutes("a");
            aRouteSpawned++;
        }
        if(bRouteSpawned < 1)
        {
            SpawnRoutes("b");
            bRouteSpawned++;
        }
        if(cRouteSpawned < 1)
        {
            SpawnRoutes("c");
            cRouteSpawned++;
        }
         if(dRouteSpawned < 1)
        {
            SpawnRoutes("d");
            dRouteSpawned++;
        }
         if(eRouteSpawned < 1)
        {
            SpawnRoutes("e");
            eRouteSpawned++;
        }
         if(fRouteSpawned < 1)
        {
            SpawnRoutes("f");
            fRouteSpawned++;
        }
         

    }

    private void SpawnVanillaPlane()
    {
        bool planeSpawned = false;
        while(!planeSpawned)
        {
            //radius of spawn
            Vector3 planePosition = new Vector3(Random.Range(-190f, 190f), Random.Range(-90f, 90), 0);

            //ensures spawn gap between each other
            if((planePosition - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                planeSpawned = true;
                Instantiate(VanillaPlaneEnemy, planePosition, Quaternion.identity);
            }
        }
    }
    private void SpawnRoutes(string spawnRoute)
    {
            if(spawnRoute == "a")
            {
                //radius of A-Route
                Vector3 Aposition = new Vector3(Random.Range(-50f, -65f), Random.Range(55f, 70f),0);
                Instantiate(ARoute, Aposition, Quaternion.identity);
    
            }
            else if(spawnRoute == "b")
            {
                //radius of B-Route
                Vector3 Bposition = new Vector3(Random.Range(55f, 70f), Random.Range(-55f, -70f),0);
                Instantiate(BRoute, Bposition, Quaternion.identity);
            }
             else if(spawnRoute == "c")
             {
                 //radius of C-Route
                Vector3 Cposition = new Vector3(Random.Range(10f, 25f), Random.Range(0f, -15f),0);
               Instantiate(CRoute, Cposition, Quaternion.identity);
             }
             else if(spawnRoute == "d")
             {
                 //radius of C-Route
                 Vector3 Dposition = new Vector3(Random.Range(-55f, -70f), Random.Range(-55f, -70f),0);
                Instantiate(DRoute, Dposition, Quaternion.identity);
            }
             else if(spawnRoute == "e")
             {
                 //radius of C-Route
                 Vector3 Eposition = new Vector3(Random.Range(55f, 70f), Random.Range(55f, 70f),0);
                 Instantiate(ERoute, Eposition, Quaternion.identity);
            }
             else if(spawnRoute == "f")
             {
                 //radius of C-Route
                 Vector3 Fposition = new Vector3(Random.Range(-10f, -25f), Random.Range(0f, -15f),0);
                 Instantiate(FRoute, Fposition, Quaternion.identity);
           }
    }
}