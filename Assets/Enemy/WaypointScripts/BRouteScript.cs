using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BRouteScript : MonoBehaviour
{

    void OnDestroy()
    {
        EnemySpawner.bRouteSpawned--;
    }
}
