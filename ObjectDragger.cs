using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectDragger : MonoBehaviour
{
    public float offset = 0.7f;
    bool isPlacing = true;
    public GameObject cube;

    private void Start()
    {

    }

    private void Update()
    {;
        if (isPlacing) { keyboardMover(); }
        if (Input.GetKeyDown(KeyCode.Space)) { isPlacing = false; cube.SetActive(false); GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; }
    }
    
    void keyboardMover() 
    {
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            transform.position = new Vector3 (transform.position.x + offset,transform.position.y,transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            transform.position = new Vector3(transform.position.x - offset, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + offset);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - offset);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            transform.Rotate(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            transform.Rotate(0, -90, 0);
        }
    }






















    /*
    public float distance = 10;
    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = objPos;
    }
    */
}