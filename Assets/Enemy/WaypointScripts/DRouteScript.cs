using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRouteScript : MonoBehaviour
{
    void OnDestroy()
    {
        EnemySpawner.dRouteSpawned--;
    }
}
