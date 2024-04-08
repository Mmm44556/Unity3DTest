using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class sphere : MonoBehaviour
{
  public Rigidbody rd;
  float h, v;
  public int score =0;
  [SerializeField] Text scoreText;

  void Start()
  {
    rd = GetComponent<Rigidbody>();

    scoreText.text="分數:" +score.ToString();
  }

  void Update()
  {
    
    h = Input.GetAxis("Horizontal");
    v = Input.GetAxis("Vertical");

    rd.AddForce(new Vector3(h, 0, v) * 10);

  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "score")
    {
      Destroy(other.gameObject);
      score++;
      scoreText.text = "分數:" + score.ToString();
      
    }
  }
}
