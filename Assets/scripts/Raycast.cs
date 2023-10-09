using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
  Ray ray; //射線
  float raylength = 1.5f; //射線最大長度
  RaycastHit hit; //被射線打到的物件

  void Start()
    {
        
    }


    void Update()
    {
    ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
    
    }
}
