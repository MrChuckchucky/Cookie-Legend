using UnityEngine;
using System.Collections;

public class CookieManager : MonoBehaviour
{
    public float gravity;
    public float vitesseMax;
    public float acceleration;
    public float jump;
    public float height;

    private bool isLanded;
    private bool isWalled;
    private bool isTurning;
    private bool isJumping;
    private float vitesse;
    private int direction;
    private GameObject[] SolidBlocks;
	// Use this for initialization
	void Start ()
    {
        isJumping = true;
        direction = 1;
        vitesse = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        isLanded = false;
        isWalled = false;
        SolidBlocks = GameObject.FindGameObjectsWithTag("SolidBlock");
        foreach(GameObject solid in SolidBlocks)
        {
            if(solid.GetComponent<SolidBlockScript>().cookieOn)
            {
                isLanded = true;
            }
            if (solid.GetComponent<SolidBlockScript>().cookieSide)
            {
                isWalled = true;
            }
        }
        if(!isWalled)
        {
            isTurning = false;
        }
        else
        {
            if (!isTurning)
            {
                isTurning = true;
                vitesse = 0;
                direction *= -1;
                height = 0;
            }
        }
        if (isLanded)
        {
            if(vitesse < vitesseMax && vitesse > -vitesseMax)
            {
                vitesse += acceleration * direction;
            }
            if(vitesse > vitesseMax)
            {
                vitesse = vitesseMax;
            }
            if(vitesse < -vitesseMax)
            {
                vitesse = -vitesseMax;
            }
            isJumping = false;
        }
        else
        {
            if(!isJumping)
            {
                height = jump;
                isJumping = true;
            }
            height -= gravity;
            gameObject.transform.position += new Vector3(0, height * Time.deltaTime, 0);
        }
        gameObject.transform.position += new Vector3(vitesse * Time.deltaTime, 0, 0);
    }
}
