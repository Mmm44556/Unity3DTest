using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class walk : MonoBehaviour
{
    
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
    // Start is called before the first frame update
    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, checkRadi,ground);
        if (isGround && velocity.y<0)
        {
            velocity.y = -2f;
        }
        horizon = Input.GetAxis("Horizontal") * moveSpeed;
        vertical = Input.GetAxis("Vertical") * moveSpeed;
        dir = transform.forward * vertical + transform.right * horizon;
        controller.Move(dir * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGround )
        {
            velocity.y = jumpSpeed;
        }
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sceneBall")
        {
            //LoadScene方法切換場景，GetActiveScene從build settings取得索引(unity都是從裡面加載)
            //如要新增場景就必須把新場景加進build settings裡面
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}
