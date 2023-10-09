using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class walk : MonoBehaviour
{
  sphere sphereControl;
  private CharacterController controller;
  public float moveSpeed;
  public float jumpSpeed;
  private float horizon, vertical;
  private Vector3 dir;
  private float gravity = 9.8f;
  private Vector3 velocity;

  public Transform groundCheck;
  public float checkRadi;
  public LayerMask ground;
  public bool isGround;
  public LayerMask layer;
  Ray ray; //射線
  float raylength = 10; //射線最大長度
  RaycastHit hit; //被射線打到的物件

  public int score =0;
  [SerializeField] Text scoreText;
  
 public GameObject prefabToSpawn;
  public UnityEngine.Color rayColor=UnityEngine.Color.red;
  void Start()
  {
    sphereControl = FindObjectOfType<sphere>();

    controller = transform.GetComponent<CharacterController>();
    scoreText.text="分數:"+score.ToString();
  }

  void Update()
  {


    
    ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
    //由攝影機射到是畫面正中央的射線

    if (Physics.Raycast(ray, out hit, raylength))
    // (射線,out 被射線打到的物件,射線長度)，out hit 意思是：把"被射線打到的物件"帶給hit
    {
      hit.transform.SendMessage("HitByRaycast", gameObject, SendMessageOptions.DontRequireReceiver);
      //向被射線打到的物件呼叫名為"HitByRaycast"的方法，不需要傳回覆


      //當射線打到物件時會在Scene視窗畫出黃線，方便查閱
      Transform a = hit.transform;


      // if (hit.collider.gameObject.CompareTag("cube"))
      // {
      //   Debug.Log(hit.collider.gameObject.name);
      // }
      // if (hit.collider == null)
      // {
      //   raylength = 10;
      // }else{
      //   raylength =Vector3.Distance(transform.position,hit.collider.transform.position);
      // }
      // Debug.DrawLine(ray.origin, transform.forward,rayColor);

  
    }


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
      scoreText.text ="分數:"+score.ToString();
        Vector3 spawnPosition = new Vector3(Random.Range(-20f,20f), 1,Random.Range(-20f,20f));
            // 使用 Instantiate 方法生成物体
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, prefabToSpawn.transform.rotation);
          
    }
    if (other.tag == "sceneBall")
    {
      //LoadScene方法切換場景，GetActiveScene從build settings取得索引(unity都是從裡面加載)
      //如要新增場景就必須把新場景加進build settings裡面
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  }


}
