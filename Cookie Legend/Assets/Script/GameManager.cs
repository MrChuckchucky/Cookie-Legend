using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Transform[] myObjects;
    Vector3[] myPositions;
    GameObject cookie;
    Vector3 initPos;

    public GameObject pauseButton;
    // Use this for initialization
    void Start ()
    {
        cookie = GameObject.FindGameObjectWithTag("Cookie");
        initPos = cookie.transform.position;
	}
	// Update is called once per frame
	void Update ()
    {
	}

    public void Pause()
    {
        if (cookie.transform.position != initPos)
        {
            GameObject.FindGameObjectWithTag("Cookie").GetComponent<CookieManager>().playMode = false;
            pauseButton.GetComponentInChildren<Text>().text = "Play";
            for (int i = 0; i < myObjects.Length; i++)
            {
                myObjects[i].transform.position = myPositions[i];
                if (myObjects[i].tag == "Cookie")
                {
                    cookie.GetComponent<CookieManager>().gravity = 10;
                    cookie.GetComponent<CookieManager>().vitesseMax = 10;
                    cookie.GetComponent<CookieManager>().vitesse = 0;
                    cookie.GetComponent<CookieManager>().acceleration = 20;
                    cookie.GetComponent<CookieManager>().height = 0;
                    cookie.GetComponent<CookieManager>().runStart = 0;
                    cookie.GetComponent<CookieManager>().direction = 1;

                    cookie.GetComponent<CookieManager>().isLanded = false;
                    cookie.GetComponent<CookieManager>().alreadyLanded = false;
                    cookie.GetComponent<CookieManager>().isWalled = false;
                    cookie.GetComponent<CookieManager>().alreadyWalled = false;
                    cookie.GetComponent<CookieManager>().isTurning = false;
                    cookie.GetComponent<CookieManager>().inSugar = false;
                    cookie.GetComponent<CookieManager>().dead = false;
                    cookie.transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
        else
        {
            GameObject.FindGameObjectWithTag("Cookie").GetComponent<CookieManager>().playMode = true;
            pauseButton.GetComponentInChildren<Text>().text = "Stop";
            myObjects = GameObject.FindObjectsOfType<Transform>();
            myPositions = new Vector3[myObjects.Length];
            for(int i = 0; i < myObjects.Length; i++)
            {
                myPositions[i] = myObjects[i].position;
            }
        }
    }
}
