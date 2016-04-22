using UnityEngine;
using System.Collections;

public class CookieManager : MonoBehaviour
{
    public float gravity;
    public float vitesseMax;
    public float vitesse;
    public float acceleration;
    public float jump;
    public float height;
    public float runDelay;
    public float runStart;
    public bool isRunning;
    public bool isJumping;
    public int direction;

    private bool isLanded;
    private bool alreadyLanded;
    private bool isWalled;
    private bool alreadyWalled;
    private bool isTurning;
    private bool inSugar;
	// Use this for initialization
	void Start ()
    {
        inSugar = false;
        alreadyWalled = false;
        alreadyLanded = false;
        isRunning = false;
        isJumping = false;
        direction = 1;
        vitesse = 0;
    }

    void OnTriggerEnter(Collider collider)
    {
        switch(collider.tag)
        {
            case "Wall":
                if(!isWalled)
                {
                    isWalled = true;
                    if(transform.position.x < collider.transform.position.x)
                    {
                        transform.position = new Vector3(collider.transform.position.x - (0.5f + transform.localScale.y / 2), transform.position.y, 0);
                    }
                    else
                    {
                        transform.position = new Vector3(collider.transform.position.x + (0.5f + transform.localScale.y / 2), transform.position.y, 0);
                    }
                    vitesse = 0;
                    height = 0;
                    gravity = 2;
                }
                else
                {
                    alreadyWalled = true;
                }
                break;
            case "Plateform":
                if(!isLanded)
                {
                    if (transform.position.y < collider.transform.position.y)
                    {
                        height = 0;
                        transform.position = new Vector3(transform.position.x, collider.transform.position.y - (0.5f + transform.localScale.y / 2), 0);
                    }
                    else
                    {
                        isLanded = true;
                        transform.position = new Vector3(transform.position.x, collider.transform.position.y + (0.5f + transform.localScale.y / 2), 0);
                    }
                }
                else
                {
                    alreadyLanded = true;
                }
                break;
            case "Bumper":
                Bumper(collider);
                break;
            case "Milkglass":
                transform.localScale = new Vector3(0.4f, 0.4f, 1);
                break;
            case "Furnace":
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Sugar":
                inSugar = true;
                break;
            case "Pepper":
                vitesseMax = 20;
                runStart = Time.time;
                Destroy(collider.gameObject);
                break;
            case "Finish":
                Finish();
                break;
            case "Killer":
                Death();
                break;
        }
    }

    void Bumper(Collider collider)
    {
        if (Mathf.Abs(transform.position.x - collider.transform.position.x) > Mathf.Abs(transform.position.y - collider.transform.position.y))
        {
            if (transform.position.x < collider.transform.position.x)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
            vitesse = vitesseMax * direction * 2;
        }
        else
        {
            if (transform.position.y < collider.transform.position.y)
            {
                height = jump * -2f;
            }
            else
            {
                height = jump * 2f;
            }
            if(isWalled)
            {
                height /= 2;
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        switch (collider.tag)
        {
            case "Wall":
                if(!alreadyWalled)
                {
                    isWalled = false;
                    gravity = 10;
                }
                else
                {
                    alreadyWalled = false;
                }
                break;
            case "Plateform":
                if(!alreadyLanded)
                {
                    if(transform.position.y > collider.transform.position.y)
                    {
                        isLanded = false;
                        if(!inSugar)
                        {
                            height = jump;
                        }
                    }
                }
                else
                {
                    alreadyLanded = false;
                }
                break;
            case "Sugar":
                inSugar = false;
                break;
        }
    }

    void Update()
    {
        if(runStart + runDelay <= Time.time)
        {
            vitesseMax = 10;
        }
        if(isLanded)
        {
            if(direction > 0)
            {
                if(Mathf.Abs(vitesse - vitesseMax) < 1)
                {
                    vitesse = vitesseMax;
                }
                else if(vitesse < vitesseMax)
                {
                    vitesse += acceleration * Time.deltaTime;
                }
                else if(vitesse > vitesseMax)
                {
                    vitesse -= acceleration * Time.deltaTime;
                }
            }
            else
            {
                if (Mathf.Abs(vitesse + vitesseMax) < 1)
                {
                    vitesse = -vitesseMax;
                }
                else if (vitesse > vitesseMax)
                {
                    vitesse += acceleration * Time.deltaTime;
                }
                else if (vitesse < vitesseMax)
                {
                    vitesse -= acceleration * Time.deltaTime;
                }
            }
        }
        else
        {
            height -= gravity * Time.deltaTime;
            transform.position += new Vector3(0, height * Time.deltaTime, 0);
        }
        if(isJumping)
        {
            isJumping = false;
            height = jump;
        }
        transform.position += new Vector3(vitesse * Time.deltaTime, 0, 0);
        if(isWalled)
        {
            if(!isTurning && isLanded)
            {
                isTurning = true;
                direction *= -1;
            }
        }
        else
        {
            isTurning = false;
        }
    }
    
    void Finish()
    {
        Debug.Log("Finish");
    }

    void Death()
    {
        Debug.Log("dead");
    }
}
