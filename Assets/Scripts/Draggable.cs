using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    // Animations
    [SerializeField]
    private float snapTime = 1f;
    [SerializeField]
    private float popSize = 1.2f;
    [SerializeField]
    private float popTime = 0.3f;
    
    
    private float animationTimer = 0f;

    private void OnMouseDown() {
        animationTimer = 0f;
    }
    
    private void OnMouseDrag() {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        animationTimer += Time.deltaTime;
        if (animationTimer > snapTime) {
            transform.position = mousePosition;
        }
        else {
            transform.position = Vector2.Lerp(transform.position, mousePosition, animationTimer / snapTime);
        }
        if (animationTimer < popTime) {
            transform.localScale = Vector2.Lerp(Vector2.one, Vector2.one * popSize, animationTimer / popTime);
        }
    }
    private void OnMouseUp()
    {
        transform.localScale = Vector2.one;
    }
}
