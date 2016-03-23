using UnityEngine;
using System.Collections;

public class SolidBlockScript : MonoBehaviour
{
    public bool cookieOn;
    public bool cookieSide;

    private GameObject cookie;
    private GameObject[] solids;
    public bool notCookieOn;
	// Use this for initialization
	void Start ()
    {
        cookie = GameObject.FindGameObjectWithTag("Cookie");
        solids = GameObject.FindGameObjectsWithTag("SolidBlock");
        notCookieOn = false;
        foreach (GameObject solid in solids)
        {
            if(this.gameObject != solid.gameObject && Mathf.Abs(transform.position.y - solid.transform.position.y) <= 1.1f && transform.position.x == solid.transform.position.x)
            {
                notCookieOn = true;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        cookieOn = false;
        cookieSide = false;
        if (!notCookieOn && Mathf.Abs((cookie.transform.position.x + cookie.transform.lossyScale.x) - (transform.position.x + transform.lossyScale.x)) <= cookie.transform.lossyScale.x)
        {
            if (Mathf.Abs((cookie.transform.position.y) - (transform.position.y + transform.lossyScale.y)) <= 0.1f)
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