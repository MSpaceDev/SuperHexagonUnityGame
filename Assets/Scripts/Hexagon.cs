using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour {

    public float moveSpeed;

	// Update is called once per frame
	void Update () {
        transform.localScale -= Vector3.one * moveSpeed;

        if (transform.localScale.x < float.Epsilon)
        {
            GameManager.instance.PlaySound(0);
            GameManager.instance.IncrementScore();
            Destroy(gameObject);
        }
	}
}
