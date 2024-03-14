using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMouseFollowEnemy : MonoBehaviour
{
    [SerializeField] private Camera cam;

    void Update()
    {
        this.transform.position = this.cam.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)
        );
    }
}
