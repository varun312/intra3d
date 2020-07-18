using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform cameraTransfrom;
    
    public float NormalSpeed;
    public float FastSpeed;

    public Vector3 fastZoom;
    public Vector3 slowZoom;

    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    public Vector3 zoomAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;
    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;

    private bool keepZooming;
    private bool keepMoving;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransfrom.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
        HandleMouseInput();    
    }

    void HandleMovementInput() 
    {
        if (newZoom.y < -9) { keepZooming = false; }
        else { keepZooming = true; }
       
        
   
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = FastSpeed;
            zoomAmount = fastZoom;
        }
        else 
        {
            movementSpeed = NormalSpeed;
            zoomAmount = slowZoom;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        {   if (newPosition.z < 87)
            {
                newPosition += (transform.forward * movementSpeed);
            }           
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (newPosition.z > -26) //8
            {
                newPosition += (transform.forward * -movementSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (newPosition.x < 115)
            {
                newPosition += (transform.right * movementSpeed);
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (newPosition.x > 15)
            {
                newPosition += (transform.right * -movementSpeed);
            }        
        }

        if (Input.GetKey(KeyCode.Q)) 
        {
            newRotation *= Quaternion.Euler(new Vector3(1, 0, 0) * rotationAmount);
        }

        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(new Vector3 (1, 0, 0) * -rotationAmount);
        }

        if (Input.GetKey(KeyCode.R) && keepZooming ) 
        {
            newZoom += zoomAmount;

        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomAmount;
        }

        cameraTransfrom.localPosition = Vector3.Lerp(cameraTransfrom.localPosition, newZoom, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
    }

    void HandleMouseInput() 
    {
        
            if (Input.mouseScrollDelta.y != 0)
            {
                newZoom += Input.mouseScrollDelta.y * zoomAmount;
            }


            if (Input.GetMouseButtonDown(0))
            {
                Plane plane = new Plane(Vector3.up, Vector3.zero);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                float entry;

                if (plane.Raycast(ray, out entry))
                {
                    dragStartPosition = ray.GetPoint(entry);
                }
            }
            if (Input.GetMouseButton(0))
            {
                Plane plane = new Plane(Vector3.up, Vector3.zero);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                float entry;

                if (plane.Raycast(ray, out entry))
                {
                    dragCurrentPosition = ray.GetPoint(entry);

                if (newPosition.z < 87 && newPosition.z > 8 && newPosition.x < 115 && newPosition.x > 15)
                { newPosition = transform.position + dragStartPosition - dragCurrentPosition; }
                }
            }
        
    }
  

}
