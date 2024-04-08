using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamFollow : MonoBehaviour
{
    private float mouseX, mouseY;
    public float mouseSense;
    public Transform Player;
    public float xR;
    
  
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;
        xR -= mouseY;
        xR = Mathf.Clamp(xR, -70f, 70f);
        Player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xR, 0, 0);

      
    }
}
