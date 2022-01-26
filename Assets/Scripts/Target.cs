using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public PlayerController Player;
    public GameObject Tartgets, LevelText;
    public Animator Panel;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ball")
        {
            if(Tartgets.transform.childCount <= 1)
            {
                LevelText.GetComponent<Text>().text = "Level " + UIElements.Level;
                Player.isPlaying = false;
                Panel.SetTrigger("Play");
            }
            Player.Spawn();
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
