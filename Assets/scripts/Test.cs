using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    private float mouseX, mouseY;
    public float moustSense;
    public Transform Play;
    public float xR;
    
  
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * moustSense * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * moustSense * Time.deltaTime;
        xR -= mouseY;
        xR = Mathf.Clamp(xR, -70f, 70f);
        Play.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xR, 0, 0);

      
    }
}
