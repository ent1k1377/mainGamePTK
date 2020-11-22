using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTracking : MonoBehaviour
{
    public GameObject pers;
    Transform pers_trans;
    Vector2 cam_pos;
    public float speed_lerp = 2f;

    public float[] borders = new float[2]; // elem1 - left, elem2 - rigth

    void Start()
    {
        pers_trans = pers.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBorder();
    }

    void Move()
    {
        transform.position = Vector2.Lerp(transform.position, pers_trans.position, speed_lerp * Time.deltaTime);
        cam_pos = transform.position;
        if (-8 >= transform.position.x)
        {
            cam_pos.x = -8;

        }
    }

    void CheckBorder()
    {
        if (borders[0] >= transform.position.x)
        {
            transform.position = new Vector2(borders[0], transform.position.y);
        }
        if (borders[1] <= transform.position.x)
        {
            transform.position = new Vector2(borders[1], transform.position.y);
        }
    }
}
