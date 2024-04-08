using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class walk : MonoBehaviour
{
  private CharacterController controller;
  private Vector3 dir;
  private Vector3 velocity;
  public float moveSpeed;
  public float jumpSpeed;
  private float horizon, vertical;
  private float gravity = 9.8f;
  public float checkRadi;
  public Transform groundCheck;
  public bool isGround;
  public int score = 0;
  public LayerMask ground;
  public LayerMask layer;

  [SerializeField] Text scoreText;


  public GameObject prefabToSpawn;
  public UnityEngine.Color rayColor = UnityEngine.Color.red;
  void Start()
  {
    controller = transform.GetComponent<CharacterController>();
    scoreText.text = "分數:" + score.ToString();
  }

  void Update()
  {
    
    isGround = Physics.CheckSphere(groundCheck.position, checkRadi, ground);
    if (isGround && velocity.y < 0)
    {
      velocity.y = -2f;
    }
    horizon = Input.GetAxis("Horizontal") * moveSpeed;
    vertical = Input.GetAxis("Vertical") * moveSpeed;
    dir = transform.forward * vertical + transform.right * horizon;
    controller.Move(dir * Time.deltaTime);

    if (Input.GetButtonDown("Jump") && isGround)
    {
      velocity.y = jumpSpeed;
    }
    velocity.y -= gravity * Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);
  }
  private void OnTriggerEnter(Collider other)
  {
   
    if (other.gameObject.tag == "score")
    {
      Destroy(other.gameObject);
      score++;
      scoreText.text = "分數:" + score.ToString();
      Vector3 spawnPosition = new Vector3(Random.Range(-20f, 20f), 1, Random.Range(-20f, 20f));
      // 使用 Instantiate 方法生成物体
      Instantiate(prefabToSpawn, spawnPosition, prefabToSpawn.transform.rotation);

    }
    if (other.tag == "sceneBall")
    {
      //LoadScene方法切換場景，GetActiveScene從build settings取得索引(unity都是從裡面加載)
      //如要新增場景就必須把新場景加進build settings裡面
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  }
  

}
