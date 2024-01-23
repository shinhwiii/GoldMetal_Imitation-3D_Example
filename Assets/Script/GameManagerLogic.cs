using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    AudioSource audiosource;
    public int totalItemCount;
    public int stage;
    public Text playerItemCountText;
    public Text totalItemCountText;

    void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        totalItemCountText.text = totalItemCount.ToString();
    }

    public void GetItem(int count)
    {
        playerItemCountText.text = count.ToString();
        if (playerItemCountText.text == totalItemCountText.text)
            audiosource.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            SceneManager.LoadScene(stage);
        }
    }
}
