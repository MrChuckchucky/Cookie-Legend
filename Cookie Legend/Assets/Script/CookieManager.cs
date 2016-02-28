using UnityEngine;
using System.Collections;

public class CookieManager : MonoBehaviour
{
    public float gravity;
    public float vitesseMax;
    public float acceleration;
    public float jump;

    private bool isLanded;
    private float vitesse;
    private float height;
	// Use this for initialization
	void Start ()
    {
        isLanded = false;
        vitesse = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(isLanded)
        {
            if(vitesse < vitesseMax)
            {
                vitesse += acceleration;
            }
            if(vitesse > vitesseMax)
            {
                vitesse = vitesseMax;
            }
        }
        else
        {
            height -= gravity;
            gameObject.transform.position += new Vector3(0, height * Time.deltaTime, 0);
        }
        gameObject.transform.position += new Vector3(vitesse * Time.deltaTime, 0, 0);
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Plateforme")
        {
            isLanded = true;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, collision.gameObject.transform.position.y + 1, gameObject.transform.position.z);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Plateforme")
        {
            isLanded = true;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, collision.gameObject.transform.position.y + 1, gameObject.transform.position.z);
        }
        if (collision.gameObject.name == "Jump")
        {
            if(isLanded)
            {
                isLanded = false;
                height = jump;
            }
        }
    }
}
