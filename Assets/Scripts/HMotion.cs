using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMotion : MonoBehaviour
{
    public Vector3 pos;
    public float height, speed;
    //public bool BottleOnPlatform;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMotion();
    }

    public void HorizontalMotion()
    {
        float newX = Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Bottle" )
    //    {
    //        BottleOnPlatform = true;
    //        collision.collider.transform.SetParent(transform);
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.name == "Bottle" )
    //    {
    //        BottleOnPlatform = false;
    //        collision.collider.transform.SetParent(null);
    //    }
    //}
}
