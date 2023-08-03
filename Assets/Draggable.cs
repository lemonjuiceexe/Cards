using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private float snapTime = 0.1f;
    
    
    private float snapTimer = 0f;

    private void OnMouseDown() {
        snapTimer = 0f;
    }
    
    private void OnMouseDrag() {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        snapTimer += Time.deltaTime;
        if (snapTimer > snapTime) {
            gameObject.transform.position = mousePosition;
        }
        else {
            gameObject.transform.position = Vector3.Lerp(transform.position, mousePosition, snapTimer / snapTime);
        }
    }
}
