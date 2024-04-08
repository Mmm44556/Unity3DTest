using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
  [SerializeField] private Camera PlayerCam;
  [SerializeField] private float PickupRange;
  [SerializeField] private LayerMask PickupLayer;
  [SerializeField] private Transform Hand;
  [SerializeField] private float ThrowForce;

  private Rigidbody CurObjRigibody;
  private Collider CurObjCollider;

  void Update()
  {
    if (Input.GetKeyDown("e"))
    {
      Ray PickUpray = new Ray(PlayerCam.transform.position, PlayerCam.transform.forward);

      if (Physics.Raycast(PickUpray, out RaycastHit hitInfo, PickupRange, PickupLayer))
      {
        if (CurObjRigibody)
        //判斷手上是否有物件，有的話代表要撿新的物件
        {
          CurObjRigibody.isKinematic = false;
          CurObjCollider.enabled = true;
          //新物件賦值
          CurObjRigibody = hitInfo.rigidbody;
          CurObjCollider = hitInfo.collider;
          CurObjRigibody.isKinematic = true;
          CurObjCollider.enabled = false;
        }
        else
        {
          //沒有的話將雷射到的物件賦值作為引用，然後取消該物件的物理特性
          CurObjRigibody = hitInfo.rigidbody;
          CurObjCollider = hitInfo.collider;
          CurObjRigibody.isKinematic = true;
          CurObjCollider.enabled = false;
        }
        return;
      }
      if (CurObjRigibody)
      //手上有物件時再按E開啟物理特性丟掉物件
      {
        CurObjRigibody.isKinematic = false;
        CurObjCollider.enabled = true;
        CurObjRigibody = null;
        CurObjCollider = null;
      }
    }
    if (CurObjRigibody)
    //將當前雷射物件的位置放到手的位置
    {
      CurObjRigibody.position = Hand.position;
      CurObjRigibody.rotation = Hand.rotation;
    }
    
    if (Input.GetKeyDown("q"))
    //丟掉物品且施加丟出去的力
    {
      if (CurObjRigibody)
      {
        CurObjRigibody.isKinematic = false;
        CurObjCollider.enabled = true;
        CurObjRigibody.AddForce(PlayerCam.transform.forward * ThrowForce,
        ForceMode.Impulse);
        CurObjRigibody = null;
        CurObjCollider = null;
      }
    }

  }
}
