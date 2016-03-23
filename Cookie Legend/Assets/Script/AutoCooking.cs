using UnityEngine;
using System.Collections;

public class AutoCooking : MonoBehaviour
{
    private GameObject cookie;
	// Use this for initialization
	void Start ()
    {
        cookie = GameObject.FindGameObjectWithTag("Cookie");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Mathf.Abs((cookie.transform.position.x + cookie.transform.lossyScale.x) - (transform.position.x + transform.lossyScale.x)) <= cookie.transform.lossyScale.x)
        {
            if (Mathf.Abs((cookie.transform.position.y) - (transform.position.y + transform.lossyScale.y)) <= 0.1f)
            {
                cookie.GetComponent<CookieManager>().height = cookie.GetComponent<CookieManager>().jump * 2.8f;
            }
        }
    }
}
