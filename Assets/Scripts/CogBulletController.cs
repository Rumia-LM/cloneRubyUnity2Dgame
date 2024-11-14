using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogBulletController : MonoBehaviour
{
    Rigidbody2D rb;

    //Instantiateされた直後にGetComponentする必要があるので
    //Startでの記述は不可
    void Awake() {
        rb=GetComponent<Rigidbody2D>();
    }
    private void OnBecameInvisible() {
        Destroy(gameObject);
        
    }

    public void Launch(Vector2 direction,float force){
        rb.AddForce(direction * force,ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //Debug.Log("CogBullet collision with "+other.gameObject);
        EnemyController enemyCon = other.collider.GetComponent<EnemyController>();
        if(enemyCon != null){
            enemyCon.Fix();
        }
        Destroy(gameObject);
    }

}
