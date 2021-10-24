using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private Vector3 target;

    public GameObject Mouse;
    public bool M = false;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;

        Mouse.SetActive(M);
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Mouse.transform.position = new Vector2(target.x + 0.15f, target.y - 0.25f);
    }
}