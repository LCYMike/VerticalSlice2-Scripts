using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour {

    public Transform target;

	void Update () {
        if (!target)
            return;

        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0.390625f);

	}
}
