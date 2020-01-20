using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manger : MonoBehaviour
{
    public GameObject enemy_ship;
    public GameObject[] extra;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(enemy_spawn_routine());
        StartCoroutine(speed());
        StartCoroutine(shield());
        StartCoroutine(tripleshot());
    }

    // Update is called once per frame
    IEnumerator enemy_spawn_routine()
    {
        while (true)
        {

            Instantiate(enemy_ship, new Vector3(Random.Range(-7, 7), 7), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
    }



    //speed up spawn
    IEnumerator speed()
    {
        while (true)
        {

            Instantiate(extra[1], new Vector3(Random.Range(-8, 7), 7), Quaternion.identity);
            yield return new WaitForSeconds(20.0f);
        }
    }
    //shield
    IEnumerator shield()
    {
        while (true)
        {

            Instantiate(extra[0], new Vector3(Random.Range(-6, 7), 7), Quaternion.identity);
            yield return new WaitForSeconds(9.0f);
        }
    }
    //tripleshot
    IEnumerator tripleshot()
    {
        while (true)
        {

            Instantiate(extra[2], new Vector3(Random.Range(-6, 7), 7), Quaternion.identity);
            yield return new WaitForSeconds(15.0f);
        }
    }
}
