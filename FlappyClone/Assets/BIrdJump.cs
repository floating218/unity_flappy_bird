using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BIrdJump : MonoBehaviour
{

    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//0:마우스왼쪽버튼
        {
            rb.velocity=Vector2.up*3; //Vector2=2차원벡터//Vector2.up=(0,1)
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(Score.score>Score.bestscore){
            Score.bestscore=Score.score;
        }
        SceneManager.LoadScene("GameOverScene");
    }


}
