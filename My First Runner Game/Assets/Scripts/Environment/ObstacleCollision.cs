using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource crushFX;
    public GameObject mainCam;
    public GameObject levelControl;
    private void OnTriggerEnter(Collider other)
    {
        crushFX.Play();
        gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        charModel.GetComponent<Animator>().Play("Backwards");
        levelControl.GetComponent<LevelDistance>().enabled = false;
        mainCam.GetComponent<Animator>().enabled = true;    
        levelControl.GetComponent<EndRunSequence>().enabled = true;
    }
}