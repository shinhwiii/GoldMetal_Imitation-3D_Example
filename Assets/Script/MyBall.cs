using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyBall : MonoBehaviour
{
    Rigidbody rigid;
    AudioSource audiosource;
    public GameManagerLogic manager;

    public float jumpPower;
    public int itemCount;
    bool isJump;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(Vector3.up*jumpPower, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            itemCount++;
            audiosource.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if (other.gameObject.tag == "Finish")
        {
            if(manager.totalItemCount == itemCount)
            {
                if(manager.stage == 3)
                    SceneManager.LoadScene("Finish");
                else
                    SceneManager.LoadScene(manager.stage+1);
            }
            else
            {
                SceneManager.LoadScene(manager.stage);
            }
        }
    } 

}
