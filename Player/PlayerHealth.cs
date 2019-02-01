using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    private int hitPoints;

	// Use this for initialization
	void Start () {

        hitPoints = 100;

	}
	
	// Update is called once per frame
	void Update () {

        print(hitPoints);

        Vector2 goTo = transform.position;
        goTo.x -= .1f;
        transform.position = goTo;

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OOF!");

        if(collision.gameObject.tag == "Object")
        {
            Debug.Log("OOF!");
            hitPoints -= 10;
        }
    }
}
