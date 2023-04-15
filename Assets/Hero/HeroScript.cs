using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    //Movement 
    bool controlSwitch = false;
    
    //EggBullets
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float bulletSpeed = 40f;
    public static float cooldown = .2f;
    private float nextFire = 0f;


    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed = 0.1f;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Hero's Controller Mode Switch
        if (Input.GetKeyDown(KeyCode.M))
        {
            controlSwitch = !controlSwitch;
        }
        SwitchController();
        EggBullets();
    }

    private void SwitchController()
    {
       if(controlSwitch == false)
       {
            HeroGUIScript.heroMode = "Mouse";
            HeroMouseMovement();
       }
       else
       {
            HeroGUIScript.heroMode = "Keyboard";
            HeroKeysMovement();
       }
    }
    //Hero Destroys vanilla planes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("VanillaPlaneEnemy"))
        {
            Destroy(collision.gameObject);
            HeroGUIScript.touchedEnemy++;
            HeroGUIScript.VanillaPlaneCount--;
            EnemySpawner.enemySpawned--;
        }
    }


    //Hero Movements
    private void HeroKeysMovement()
    {
        // Change Speed
        if (Input.GetKey(KeyCode.W)) {
            speed += 0.2f;
        } else if (Input.GetKey(KeyCode.S)) {
            if (speed - 2 < 0 ) {
                speed = 0f;
            } else {
                speed -= 0.2f;
            }
        }

        // Change direction
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0,0,rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0,0,-1 * rotationSpeed);
        }
        rb2d.velocity = transform.up * speed;
    }
    private void HeroMouseMovement()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);

        // Change direction
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0,0,rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0,0,-1 * rotationSpeed);
        }
        rb2d.velocity = transform.up * speed;
    }

    public void EggBullets()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            HeroGUIScript.EggOnScreen++;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rigBod = bullet.GetComponent<Rigidbody2D>();
            rigBod.velocity = firePoint.up * bulletSpeed;
            nextFire = Time.time + cooldown;
        }
    }
}
