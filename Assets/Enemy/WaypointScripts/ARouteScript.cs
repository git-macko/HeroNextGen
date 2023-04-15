using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARouteScript : MonoBehaviour
{
    

    void OnDestroy()
    {
        EnemySpawner.aRouteSpawned--;
    }
    
}