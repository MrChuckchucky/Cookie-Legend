using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    GameObject cookie;
    public Vector3[] positions;
	// Use this for initialization
	void Start ()
    {
        cookie = GameObject.FindGameObjectWithTag("Cookie");
        positions = new Vector3[10];
        for(int i = 0; i < positions.Length; i++)
        {
            positions[i] = cookie.transform.position;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(cookie.GetComponent<CookieManager>().playMode)
        {
            for (int i = positions.Length - 1; i > 0; i--)
            {
                positions[i] = positions[i - 1];
            }
            positions[0] = cookie.transform.position;
            transform.Translate(new Vector3((positions[positions.Length - 1].x - transform.position.x), (positions[positions.Length - 1].y - transform.position.y), positions[positions.Length - 1].z));
        }
        else
        {
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = cookie.transform.position;
            }
        }
	}
}
