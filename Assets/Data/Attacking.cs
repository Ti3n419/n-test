using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] protected bool isAttacking = false;
    [SerializeField] protected Transform skillPrefab;
    [SerializeField] private Animator anim;
    [SerializeField] protected Movement movement;
    

    protected void Update()
    {
        
        this.Attack();

    }
    protected virtual void Shooting()
    {
       
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform dart = Instantiate(this.skillPrefab,spawnPos,rotation);
        SkillFly skillFly= dart.GetComponentInChildren<SkillFly>();
        Debug.Log(movement.direction);
        skillFly.direction = movement.direction;

        Debug.Log("shotting");
    }
    public void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.Shooting();
            anim.SetTrigger("Attack");
        }
    }


}
