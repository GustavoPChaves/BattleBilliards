using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardsController : MonoBehaviour
{
    [SerializeField]
    private float defaultForce = 100;
    private Rigidbody rb;

    private Vector2 initialPos, finalPos;
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
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TouchBegan(mousePos);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TouchEnded(mousePos);
        }
    }

    void TouchBegan(Vector2 position)
    {
        rb.velocity = Vector3.zero;
        initialPos = position;
    }

    void TouchEnded(Vector2 position)
    {
        finalPos = position;

        var direction = - (finalPos - initialPos).normalized;
        var force = Vector3.Distance(finalPos, initialPos);
        rb.AddForce(direction * defaultForce * force);
    }
        
}
