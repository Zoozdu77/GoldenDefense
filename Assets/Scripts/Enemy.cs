using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UnitData data;

    public Transform LifeBar;

    public Animator Anim;

    public SpriteRenderer sprite;

    [SerializeField] private GameObject deathParticle;

    [SerializeField] private AudioClip death;
    [SerializeField] private AudioClip damageThrone;

    private float speed;
    private float MaxSpeed;
    private float MaxLife;
    private float Life;
    private float EnemyCost;
    private float FireCooldown;
    public GameObject[] checkPoints;
    private GameObject target;
    private int targNum = 0;
    private float SlowCooldown;

    void Start()
    {
        LoadEnemy();
        target = checkPoints[targNum];
    }

    private void Update()
    {
        if(FireCooldown > 0)
        {
            FireCooldown -= Time.deltaTime;
        }
        if (Life <= 0)
        {
            Die();
        }
        if (SlowCooldown <= 0)
        {
            speed = MaxSpeed;
        } else
        {
            SlowCooldown -= Time.deltaTime;
        }


        Vector2 direction = target.transform.position - transform.position;
        Anim.SetFloat("MovementX", direction.x);
        Anim.SetFloat("MovementY", direction.y);
        if (direction.x < 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (transform.localScale.x > 0 && direction.x >= 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        transform.Translate(speed * Time.deltaTime * direction.normalized);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject == checkPoints[targNum])
        {

            targNum++;
            if (targNum < checkPoints.Length)
            {
            target = checkPoints[targNum];
            } else
            {
                GeneralVars.throneHealth--;
                Buttons SoundGestion = GameObject.Find("SoundController").GetComponent<Buttons>();
                SoundGestion.SoundSource.PlayOneShot(damageThrone);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (FireCooldown <= 0 && other.CompareTag("Fire"))
        {
            Damaged(other.GetComponent<Bullet>().Damage);
            FireCooldown += 0.2f;
        }
    }

    #region(fonctions)

    public void LoadEnemy()
    {
        MaxLife = data.life + GeneralVars.BonusHp;
        Life = MaxLife;
        MaxSpeed = data.speed;
        EnemyCost = data.UnitPrice;
    }

    public void Damaged(float damaged)
    {
        if (damaged > 0)
        {
            StartCoroutine(Hurt());
        }
        else
        {
            StartCoroutine(Healed());
        }
        if (Life - damaged <= MaxLife)
        {
        Life -= damaged;
        }
        LifeBar.localScale = new Vector3(Life / MaxLife, 0.75f);
    }

    public IEnumerator SlowDown()
    {
        SlowCooldown = 1f;
        speed = (MaxSpeed / 3) * 2;
        sprite.color = Color.blue;
        yield return new WaitForSeconds(0.5f);
        sprite.color = Color.white;
    }

    public void Die()
    {
        Buttons SoundGestion = GameObject.Find("SoundController").GetComponent<Buttons>();
        SoundGestion.SoundSource.PlayOneShot(death);

        GeneralVars.Money += 700 + 1.5f  * ((int)EnemyCost) + ((int)GeneralVars.BonusHp);
        GeneralVars.score += ((int)EnemyCost * 100);
        GeneralVars.ennemyNumber--;
        Instantiate(deathParticle, transform.position, transform.rotation, null);

        Destroy(this.gameObject);
    }
    #endregion

    #region(coroutines)
    public IEnumerator Hurt()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        sprite.color = Color.white;
    }

    public IEnumerator Healed()
    {
        sprite.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        sprite.color = Color.white;
    }
    #endregion

}
