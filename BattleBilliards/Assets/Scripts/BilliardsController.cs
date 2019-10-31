using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardsController : MonoBehaviour
{
    [SerializeField]
    private float defaultForce = 100;
    private Rigidbody rb;

    private Vector3 initialPos, finalPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = MousePosition();
            TouchBegan(InvertYZ(mousePos));
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = MousePosition();
            TouchEnded(InvertYZ(mousePos));
        }
    }

    void TouchBegan(Vector3 position)
    {
        rb.velocity = Vector3.zero;
        initialPos = position;
    }

    void TouchEnded(Vector3 position)
    {
        finalPos = position;

        var direction = - (finalPos - initialPos).normalized;
        var force = Vector3.Distance(finalPos, initialPos);
        rb.AddForce(direction * defaultForce * force);
    }

    Vector3 MousePosition()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        var point = Camera.main.ScreenToWorldPoint(mousePos);
        return point;
    }

    Vector3 InvertYZ(Vector3 vector)
    {
        return new Vector3(vector.x, 0, vector.y);
    }
        
}
