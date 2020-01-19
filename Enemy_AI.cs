using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour {
    // variable for speed
    public GameObject explosion;
    public float speed = 3f;
    
	
	void Start () {
        
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
            
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            
        }
        else if (col.gameObject.tag =="Player")
        {
            Player_Movement player = col.GetComponent<Player_Movement>();
            if(player != null)
            {
                player.Damage();
                
            }
           
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            
        }

    }
}
