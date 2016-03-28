using UnityEngine;
using System.Collections;

public class PepperScript : MonoBehaviour
{
    GameObject cookie;
	// Use this for initialization
	void Start ()
    {
        cookie = GameObject.FindGameObjectWithTag("Cookie");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Mathf.Abs((cookie.transform.position.y + cookie.transform.lossyScale.y) - (transform.position.y + transform.lossyScale.y)) <= cookie.transform.lossyScale.y)
        {
            if (Mathf.Abs((cookie.transform.position.x + cookie.transform.lossyScale.x) - (transform.position.x + transform.lossyScale.x)) <= 1)
            {
                cookie.GetComponent<CookieManager>().isRunning = true;
                cookie.GetComponent<CookieManager>().runStart = 0;
                cookie.GetComponent<CookieManager>().vitesseMax *= 2;
                Destroy(this.gameObject);
            }
        }
    }
}
