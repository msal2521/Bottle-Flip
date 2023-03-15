using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMotion : MonoBehaviour
{
    public Vector3 pos;
    public float height, speed;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        VerticalMotion();
    }

    public void VerticalMotion()
    {
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y / 2f;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "WaterBottle")
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "WaterBottle")
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
