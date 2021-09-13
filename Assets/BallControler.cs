using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControler : MonoBehaviour
{
    Text ScoreUIP1, ScoreUIP2;
    int ScoreP1,ScoreP2;

    public int force;
    Rigidbody2D rigid;
    void Start()
    {
        ScoreP1 = 0;
        ScoreP2 = 0;
        ScoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        ScoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);
    }
    void TampilkanScore()
    { ScoreUIP1.text = ScoreP1 + "";
      ScoreUIP2.text = ScoreP2 + "";
    }
    void ResetBall()
    { transform.localPosition = new Vector2(0, 0); 
      rigid.velocity =new Vector2(0, 0);}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "tepiKiri")
        {
            ScoreP2 += 1;
            TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);}
        if (coll.gameObject.name == "tepiKanan")
        {
            ScoreP1 += 1;
            TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);}
        if (coll.gameObject.name == "Player1" || coll.gameObject.name == "Player2")
        { float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 2);
        }
    }

}
