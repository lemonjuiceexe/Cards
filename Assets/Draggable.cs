using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    private void OnMouseDrag()
    {
        gameObject.transform.position = (Vector2) mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
