using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FRouteScript : MonoBehaviour
{
    void OnDestroy()
    {
        EnemySpawner.fRouteSpawned--;
    }
}
