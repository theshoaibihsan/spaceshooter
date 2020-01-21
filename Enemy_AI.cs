using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy_AI : MonoBehaviour {
    // variable for speed
    public GameObject explosion;
    public float speed = 3f;
    UIManager manager;
	void Start () {
        manager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
	
	
	void Update () {
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y< -6.6f)
        {
            float RandomX = Random.Range(-7, 7);
            transform.position = new Vector3(RandomX,6.6f,0);
        }
        
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
       


        if (col.gameObject.tag == "laser" )
        {

            
            Destroy(col.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            manager.UpdateScore();
            Destroy(this.gameObject);
            


        }
       
        else if (col.gameObject.tag =="Player")
        {
            Player_Movement player = col.GetComponent<Player_Movement>();
            if(player != null)
            {
                manager.UpdateScore();
                player.Damage();
                
            }
           
            Instantiate(explosion, transform.position, Quaternion.identity);
            
            Destroy(this.gameObject);
            
        }
       

    }
}
