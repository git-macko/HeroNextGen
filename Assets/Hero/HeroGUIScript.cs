using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeroGUIScript : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public static string heroMode;
    public static string Waypoints;
    public static int EggOnScreen;
    public static int VanillaPlaneCount;
    public static int touchedEnemy;
    
    private bool toggleWP = true;

    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        heroMode = "";
        Waypoints = "";
        EggOnScreen = 0;
        VanillaPlaneCount = 0;
        touchedEnemy = 0;
    }
    void Update()
    {
        if(EggOnScreen < 0)
            EggOnScreen = 0;
            
        textMeshPro.text = "Waypoint: " + Waypoints + "\n" +
                        "Hero's Controller: " + heroMode + "\n" + 
                        "Egg On Screen: " + EggOnScreen + "\n" +
                        "Vanilla Plane Count: " + VanillaPlaneCount + "\n" +
                        "Touched Enemy: " + touchedEnemy + "\n";
                            
    
        if(Input.GetKeyDown(KeyCode.J))
        {
            toggleWP = !toggleWP;
        }
        ToggleWaypoints();
    }
    private void ToggleWaypoints()
    {
        if(toggleWP == false)
        {
            VPlaneEnemyScript.wpToggle = false;
        }
        else
        {
   
            VPlaneEnemyScript.wpToggle = true;
        }
    }
}