using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public int distRun;
    public GameObject distDisplay;
    public GameObject distEndDisplay;
    public bool addingDist = false;
    public float distDelay = 0.4f;
    void Update()
    {
        if (addingDist == false)
        {
            addingDist = true;
            StartCoroutine(AddingDist());
        }
    }
    IEnumerator AddingDist()
    {
        distRun += 1;
        distDisplay.GetComponent<Text>().text = "" + distRun;
        distEndDisplay.GetComponent<Text>().text = "" + distRun;
        yield return new WaitForSeconds(distDelay);
        addingDist = false;
    }
}
