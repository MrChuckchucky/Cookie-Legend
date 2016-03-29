using UnityEngine;
using System.Collections;

public class MilkGlassScript : MonoBehaviour
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
                cookie.GetComponent<CookieManager>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }
        if (Mathf.Abs((cookie.transform.position.x + cookie.transform.lossyScale.x) - (transform.position.x + transform.lossyScale.x)) <= cookie.transform.lossyScale.x)
        {
            if (Mathf.Abs((cookie.transform.position.y) - (transform.position.y + transform.lossyScale.y)) <= 0.1f)
            {
                cookie.GetComponent<CookieManager>().isClimbing = false;
                cookie.transform.position = new Vector3(cookie.transform.position.x, transform.position.y + 1, cookie.transform.position.z);
                cookie.GetComponent<CookieManager>().vitesse = 5 * cookie.GetComponent<CookieManager>().direction;
            }
        }
    }
}