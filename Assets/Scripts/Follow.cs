using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform WaterBottle;
    //public HMotion hmotion;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowBottle();
        //if (!hmotion.BottleOnPlatform)
        //{
        //    FollowBottle();
        //}
    }

    private void FollowBottle()
    {
        transform.position = new Vector3(WaterBottle.position.x + 1.5f, 3f, -10f);
    }
}
