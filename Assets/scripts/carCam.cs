using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class carCam : MonoBehaviour
{
  [SerializeField] CinemachineVirtualCamera firstPersonCam;
  [SerializeField] CinemachineVirtualCamera thirdPersonCam;
  [SerializeField] GameObject carText;
  private CharacterController PlayerController;
  Text carTextContent;
  bool textFlag = false;
  bool isCarRangeFlag = false;

  void Start()
  {
   
    thirdPersonCam.gameObject.SetActive(textFlag);
    carTextContent = carText.GetComponent<Text>();
    PlayerController = gameObject.GetComponent<CharacterController>();

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown("e") && isCarRangeFlag)
    {
      cam();

      //   PlayerCollider.isTrigger = true;
      //   gameObject.transform.position = thirdPersonCam.transform.position;

      //   Vector3 x = thirdPersonCam.transform.position;
      //   Debug.Log(x);
      //   Debug.Log(gameObject.transform.position);
    }
  }
  void cam()
  {
    textFlag = !textFlag;
    firstPersonCam.gameObject.SetActive(textFlag);
    thirdPersonCam.gameObject.SetActive(!textFlag);
  }

  void OnTriggerStay(Collider other)
  {
    if (other.gameObject.tag == "car")
    {
      isCarRangeFlag = true;
      carText.SetActive(true);
      if (thirdPersonCam.gameObject.activeSelf)
      {
        carTextContent.text = "按E下車";
      }
      else
      {
        carTextContent.text = "按E上車";
      }



    }
  }
  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "car")
    {
      isCarRangeFlag = false;
      carText.SetActive(false);
    }
  }


}
