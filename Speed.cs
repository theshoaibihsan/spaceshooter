using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour {
    public float speed = 2f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
	}
     void OnTriggerEnter2D(Collider2D col)
    {
        Player_Movement player = col.GetComponent<Player_Movement>();
        if (col.gameObject.tag=="Player")
        {
            player.speedupBoost();
        }
        Destroy(gameObject);

    }

}
