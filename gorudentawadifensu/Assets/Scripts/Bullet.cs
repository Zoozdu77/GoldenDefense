using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    public GameObject sprite;
    public GameObject Boom;

    public int Damage;
    public float speed;
    public float timeBeforeDestroy;
    private float cooldown;


    public bool DestroyOnCollide;
    public bool gotTarget;

    private void Start()
    {
        if (gotTarget)
        {
        Vector2 targetPos = target.transform.position;
        targetPos.x = targetPos.x - transform.position.x;
        targetPos.y = targetPos.y - transform.position.y;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        sprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
    }

    private void FixedUpdate()
    {
        if (target == null && gotTarget ||timeBeforeDestroy <= 0)
        {
            Destroy(gameObject);
        }
        timeBeforeDestroy -= Time.fixedDeltaTime;
        cooldown -= Time.fixedDeltaTime;
        if (target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && cooldown <= 0)
        {
            if(DestroyOnCollide)
            {
                collision.GetComponent<Enemy>().Damaged(Damage);
                if (Boom != null)
                {
                    GameObject BoomBoom = Instantiate(Boom, transform.position, Boom.transform.rotation, null);
                    BoomBoom.GetComponent<Bullet>().Damage += Damage / 3;
                }
                Destroy(gameObject);
            }
            //cooldown = 0.2f;
        }
    }
}
