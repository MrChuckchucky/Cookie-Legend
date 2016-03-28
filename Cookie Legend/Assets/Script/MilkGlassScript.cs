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
    }
}