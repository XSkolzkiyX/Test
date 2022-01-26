using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ballPrefab, balls, arrow;
    public bool isPlaying = false;
    GameObject curBall;
    bool canShoot = true;
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        Spawn();
    }

    void Update()
    {
        if (Input.touchCount > 0 && canShoot && isPlaying)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                arrow.SetActive(true);
                arrow.GetComponent<RectTransform>().position = new Vector3(arrow.GetComponent<RectTransform>().position.x, 0.01f, (transform.position.z+curBall.transform.position.z) / 2);
                arrow.GetComponent<RectTransform>().localScale = new Vector3((curBall.transform.position.x - transform.position.x + curBall.transform.position.z - transform.position.z) / 2, arrow.GetComponent<RectTransform>().localScale.y, arrow.GetComponent<RectTransform>().localScale.z);
                //arrow.GetComponent<RectTransform>().localScale = new Vector3(Mathf.Sqrt(Mathf.Pow(transform.position.x - curBall.transform.position.x, 2) + Mathf.Pow(transform.position.x - curBall.transform.position.x, 2))*3,0.3f, 1);
                transform.LookAt(curBall.transform);
                var groundPlane = new Plane(Vector3.up, Vector3.zero);
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (groundPlane.Raycast(ray, out float position))
                {
                    Vector3 worldPosition = ray.GetPoint(position);
                    transform.position = new Vector3(worldPosition.x, transform.position.y, worldPosition.z);
                }
            }
            if (touch.phase == TouchPhase.Ended) Shoot();
        }
        if (balls.transform.childCount <= 0)
            Spawn();
    }

    public void Spawn()
    {
        curBall = Instantiate(ballPrefab, new Vector3(transform.position.x, ballPrefab.transform.localScale.y / 2, transform.position.z - 1f), Quaternion.identity);
        curBall.GetComponent<Ball>().Player = gameObject.GetComponent<PlayerController>();
        curBall.transform.parent = balls.transform;
        canShoot = true;
    }

    void Shoot()
    {
        arrow.SetActive(false);
        Destroy(curBall, 5f);
        curBall.GetComponent<Rigidbody>().velocity = new Vector3(transform.position.x-curBall.transform.position.x, 0, transform.position.z - curBall.transform.position.z);
        transform.position = startPos;
        canShoot = false;
    }
}
