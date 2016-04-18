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
    public bool canJump;
    public int direction;
    public bool isLanded;

    private bool isWalled;
    private bool isTurning;
    private GameObject[] SolidBlocks;
	// Use this for initialization
	void Start ()
    {
        isRunning = false;
        isJumping = true;
        direction = 1;
        vitesse = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isRunning)
        {
            runStart += Time.deltaTime;
            if (runStart >= runDelay)
            {
                vitesseMax /= 2;
                isRunning = false;
            }
        }
        isLanded = false;
        isWalled = false;
        SolidBlocks = GameObject.FindGameObjectsWithTag("SolidBlock");
        foreach (GameObject solid in SolidBlocks)
        {
            if (solid.GetComponent<SolidBlockScript>().cookieOn)
            {
                isLanded = true;
            }
            if (solid.GetComponent<SolidBlockScript>().cookieSide)
            {
                isWalled = true;
            }
        }
        if (!isWalled)
        {
            isTurning = false;
        }
        else
        {
            if (isLanded && !isTurning)
            {
                Debug.Log("yo");
                isTurning = true;
                vitesse = 0;
                direction *= -1;
                height = 0;
            }
        }
        if (isLanded)
        {
            if (vitesse < vitesseMax && vitesse > -vitesseMax)
            {
                vitesse += acceleration * direction;
            }
            if (vitesse > vitesseMax)
            {
                if (vitesse - vitesseMax <= 0.5f)
                {
                    vitesse = vitesseMax;
                }
                else
                {
                    vitesse -= acceleration * direction;
                }
            }
            if (vitesse < -vitesseMax)
            {
                vitesse = -vitesseMax;
            }
            isJumping = false;
        }
        else
        {
            if (canJump && !isJumping)
            {
                height = jump;
                isJumping = true;
            }
            height -= gravity;
            gameObject.transform.position += new Vector3(0, height * Time.deltaTime, 0);
        }
        gameObject.transform.position += new Vector3(vitesse * Time.deltaTime, 0, 0);
    }

    public void Death()
    {
        Debug.Log("dead");
    }
}
