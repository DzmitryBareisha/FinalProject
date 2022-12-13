using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public GameObject swipePrefab;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
   
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            if (endTouchPosition.x < startTouchPosition.x)
            {
                Left();
            }
            if (endTouchPosition.x > startTouchPosition.x)
            {
                Right();
            }
        }
    }
    public void Right()
    {
        swipePrefab.transform.position = new Vector3(swipePrefab.transform.position.x + 4, swipePrefab.transform.position.y, swipePrefab.transform.position.z);
    }
    public void Left()
    {
        swipePrefab.transform.position = new Vector3(swipePrefab.transform.position.x - 4, swipePrefab.transform.position.y, swipePrefab.transform.position.z);
    }
}
