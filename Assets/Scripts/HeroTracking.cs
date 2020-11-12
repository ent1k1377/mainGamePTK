using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTracking : MonoBehaviour
{
    public GameObject pers;
    Transform pers_trans;
    Vector2 pers_pos;
    Vector2 cam_pos;
    public float speed_lerp = 2f;
    // Start is called before the first frame update
    void Start()
    {
        pers_trans = pers.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = Vector2.Lerp(transform.position, pers_trans.position, speed_lerp * Time.deltaTime);
        cam_pos = transform.position;
        if (-8 >= transform.position.x)
        {
            cam_pos.x = -8;
            
        }
    }
}
