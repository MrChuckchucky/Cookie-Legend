using UnityEngine;
using System.Collections;

public class SolidBlockScript : MonoBehaviour
{
    public bool cookieOn;
    public bool cookieSide;

    private GameObject cookie;
	// Use this for initialization
	void Start ()
    {
        cookie = GameObject.FindGameObjectWithTag("Cookie");
	}
	
	// Update is called once per frame
	void Update ()
    {
        cookieOn = false;
        cookieSide = false;
        if (Mathf.Abs((cookie.transform.position.x + cookie.transform.lossyScale.x) - (transform.position.x + transform.lossyScale.x)) <= cookie.transform.lossyScale.x)
        {
            if (Mathf.Abs((cookie.transform.position.y) - (transform.position.y + transform.lossyScale.y)) <= 0.5f)
            {
                cookieOn = true;
                cookie.transform.position = new Vector3(cookie.transform.position.x, (transform.position.y + transform.lossyScale.y) + 0.01f, cookie.transform.position.z);
            }
        }
        if (Mathf.Abs((cookie.transform.position.y + cookie.transform.lossyScale.y) - (transform.position.y + transform.lossyScale.y)) <= cookie.transform.lossyScale.y)
        {
            if (Mathf.Abs((cookie.transform.position.x + cookie.transform.lossyScale.x) - (transform.position.x + transform.lossyScale.x)) <= 1)
            {
                cookieSide = true;
            }
        }
    }
}