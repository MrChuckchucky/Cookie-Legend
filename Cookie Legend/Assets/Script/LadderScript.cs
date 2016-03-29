using UnityEngine;
using System.Collections;

public class LadderScript : MonoBehaviour
{
    GameObject cookie;
    bool isClimbing;
	// Use this for initialization
	void Start ()
    {
        cookie = GameObject.FindGameObjectWithTag("Cookie");
        isClimbing = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        cookie.GetComponent<CookieManager>().isClimbing = false;
        if (Mathf.Abs((cookie.transform.position.y + cookie.transform.lossyScale.y) - (transform.position.y + transform.lossyScale.y)) <= cookie.transform.lossyScale.y)
        {
            if (Mathf.Abs((cookie.transform.position.x + cookie.transform.lossyScale.x) - (transform.position.x + transform.lossyScale.x)) <= 1)
            {
                if(!isClimbing)
                {
                    isClimbing = true;
                    cookie.GetComponent<CookieManager>().transform.position += new Vector3(0.5f * cookie.GetComponent<CookieManager>().direction, 0, 0);
                }
                cookie.GetComponent<CookieManager>().isClimbing = true;
                cookie.GetComponent<CookieManager>().vitesse = 0;
                cookie.GetComponent<CookieManager>().transform.position += new Vector3(0, 6 * Time.deltaTime, 0);
            }
        }
        
        if (Mathf.Abs((cookie.transform.position.x + cookie.transform.lossyScale.x) - (transform.position.x + transform.lossyScale.x)) <= cookie.transform.lossyScale.x)
        {
            if (Mathf.Abs((cookie.transform.position.y) - (transform.position.y + transform.lossyScale.y)) <= 0.1f)
            {
                isClimbing = false;
                cookie.GetComponent<CookieManager>().isClimbing = false;
                cookie.transform.position = new Vector3(cookie.transform.position.x, transform.position.y + 1, cookie.transform.position.z);
                cookie.GetComponent<CookieManager>().vitesse = 5 * cookie.GetComponent<CookieManager>().direction;
            }
        }
    }
}
