using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float Speed = 0.3f;
    public GameObject Balls;

    void Update()
    {
        if (Balls.transform.childCount > 0)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Balls.transform.GetChild(0).transform.position.x, transform.position.y, transform.position.z), Speed * Time.deltaTime);
    }
}
