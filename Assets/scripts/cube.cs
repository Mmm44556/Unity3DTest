using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cube : MonoBehaviour
{
  public Transform rdTransForm;
  Vector3 offset;
  void Start()
  {

    offset = transform.position - rdTransForm.position;


  }


  void Update()
  {
    transform.position = rdTransForm.position + offset;


  }

  }


