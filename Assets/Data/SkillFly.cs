using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFly : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 direction = Vector3.right;
    public void Update()
    {
        transform.parent.Translate(direction * this.speed * Time.deltaTime);
    }
}
