using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackableStructure : MonoBehaviour
{
    [SerializeField] List<AttackPerimiter> attackPerimiters = new List<AttackPerimiter>();

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnDrawGizmos()
    {
        foreach (AttackPerimiter attackPerimiter in this.attackPerimiters)
        {
            Gizmos.DrawLine(
                new Vector3(this.transform.position.x - attackPerimiter.perimiterBounds.x, this.transform.position.y - attackPerimiter.perimiterBounds.y, 0f),
                new Vector3(this.transform.position.x + attackPerimiter.perimiterBounds.x, this.transform.position.y - attackPerimiter.perimiterBounds.y, 0f)
            );
        }
    }
}

[Serializable]
public class AttackPerimiter
{
    [SerializeField] public Vector2 perimiterBounds;
    [SerializeField] public String tag;
}
