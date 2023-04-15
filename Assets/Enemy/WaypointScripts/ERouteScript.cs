using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERouteScript : MonoBehaviour
{
    void OnDestroy()
    {
        EnemySpawner.eRouteSpawned--;
    }
}
