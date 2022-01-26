using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float borderUp, borderLeft;
    public PlayerController Player;
    Rigidbody Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(transform.position.x > borderLeft || transform.position.x < -borderLeft)
        {
            Rb.velocity = new Vector3(-Rb.velocity.x, 0, Rb.velocity.z);
        }
        if (transform.position.z > borderUp || transform.position.z < -borderUp)
        {
            Rb.velocity = new Vector3(Rb.velocity.x, 0, -Rb.velocity.z);
        }
    }

    public IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10f);
        Player.Spawn();
        Destroy(gameObject);
    }
}
