using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Point")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Paremeters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;
    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void Update()
    {
        if(movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
                MoveInDerection(-1);
            else
                directionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDerection(1);
            else
                directionChange();


        }
        
    }
    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }
    private void MoveInDerection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving",true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,enemy.position.y,enemy.position.z);
    }
    private void directionChange()
    {
        anim.SetBool("moving", false);

        idleTimer += Time.deltaTime;
        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }
}
