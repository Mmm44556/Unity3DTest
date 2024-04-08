using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//切換場景物件
using UnityEngine.SceneManagement;
//切換像機物件
using Cinemachine;
public class playerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 10f;
    public float RoateSpeed = 20f;
    public float Gravity = -9.8f;

    public float mouseX, mouseY;
    public float moustSense;
    public Transform Play;
    private Vector3 velocity = Vector3.zero;

    private float speedRate = 4f;

    [SerializeField] CinemachineVirtualCamera thirdPersonCam;
    [SerializeField] CinemachineVirtualCamera firstPersonCam;
    

    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
     
        //Move();
        //MoveLikeTopDown();
        /* if (Input.GetKeyDown(KeyCode.Space))
         {
             //切換鏡頭
             if (switchScene.IsActiveCamera(thirdPersonCam))
             {
                 switchScene.switchCamera(firstPersonCam);
                 
             }
             else if (switchScene.IsActiveCamera(firstPersonCam))
             {
                 
                 
                 switchScene.switchCamera(thirdPersonCam);
             }
         }*/
        
         
     }
        /*
     private void OnEnable()
     {
         switchScene.Register(thirdPersonCam);
         switchScene.Register(firstPersonCam);
         switchScene.switchCamera(thirdPersonCam);

     }
     private void OnDisable()
     {
         switchScene.Unregister(thirdPersonCam);
         switchScene.Unregister(firstPersonCam);
     }
     private void Move()
     {
         var horzontal = Input.GetAxis("Horizontal");
         var vertical = Input.GetAxis("Vertical");
         Vector3 speed = new Vector3(horzontal, 0, vertical) * speedRate;
         controller.SimpleMove(speed);
     } */
     

        private void MoveLikeTopDown()
    {
        //數學移動方法
        var horzontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var direction = new Vector3(horzontal, 0, vertical).normalized;
        var move = direction * speed * Time.deltaTime;
        controller.Move(move);
        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        var point =Input.mousePosition - playerScreenPoint;
        var angle = Mathf.Atan2(-point.x,-point.y) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z); 
    }

  
  
}
