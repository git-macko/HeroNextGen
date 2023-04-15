using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRouteScript : MonoBehaviour
{
    void OnDestroy()
    {
        EnemySpawner.cRouteSpawned--;
    }
}
