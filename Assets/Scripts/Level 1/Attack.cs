using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bullet;
    public GameObject slam;
    public GameObject wallPrefab;

    float firerate;
    float nextfire;
    float firerate2;
    float nextfire2;

    public Transform bulletSpawnPoint;
    public Transform bulletSpawnPoint2;

    public Transform smashSpawnPoint;
    public float bulletSpawnRate;
    public GameObject boss;

    public GameObject go;
    DepressionBoss charged;

    public Transform wall1;
    public Transform wall2;

    private GameObject clone1;
    private GameObject clone2;

    public bool wallsActive = false;
    bool chargedAttack;
    public float chargedAttackTimer = 15f;
    public GameObject text;
    public float textTimer = 2f;
    public bool reset = false;
    public float resetTimer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        charged = go.GetComponent<DepressionBoss>();

        firerate = 1f;
        nextfire = Time.time;

        firerate2 = 1f;
        nextfire2 = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        chargedAttack = charged.chargedAttack;

        bulletSpawnRate += Time.deltaTime;
        if (chargedAttack == true && chargedAttackTimer > 0)
        {
            chargedAttackTimer -= Time.deltaTime;
            EnragedAttack();

            if (bulletSpawnRate > 8)
            {
                Smash();
                bulletSpawnRate = 0;
            }
            else if (bulletSpawnRate > 2 && bulletSpawnRate < 7)
            {
                boss.gameObject.SetActive(true);
                CheckIfTimeToFire();
                CheckIfTimeToFire2();
            }
        }
        else if (reset == false)
        {
            if (bulletSpawnRate > 10)
            {
                Smash();
                bulletSpawnRate = 0;
            }
            else if (bulletSpawnRate > 2 && bulletSpawnRate < 10)
            {
                boss.gameObject.SetActive(true);
                CheckIfTimeToFire();
            }
        }
        else if (reset == true)
        {
            if (resetTimer <= 0)
            {
                Reset();
            }
            else if (resetTimer > 0)
            {
                resetTimer -= Time.deltaTime;
            }
        }
    }

    void EnragedAttack()
    {
        if (wallsActive == false)
        {
            text.gameObject.SetActive(true);
            clone1 = Instantiate(wallPrefab, wall1.position, wall1.rotation);
            clone2 = Instantiate(wallPrefab, wall2.position, wall2.rotation);
            wallsActive = true;
        }

        if (textTimer > 0)
        {
            text.gameObject.SetActive(true);
            textTimer -= Time.deltaTime;
        }
        else if (textTimer <= 0)
        {
            text.gameObject.SetActive(false);
        }

        if (chargedAttackTimer <= 0)
        {
            textTimer = 2f;
            Destroy(clone1);
            Destroy(clone2);
            reset = true;
        }
    }

    void Reset()
    {
        wallsActive = false;
        chargedAttackTimer = 15f;
        reset = false;
        resetTimer = 10f;
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextfire)
        {
            Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            nextfire = Time.time + firerate;
        }
    }

    void CheckIfTimeToFire2()
    {
        if (Time.time > nextfire2)
        {
            Instantiate(bullet, bulletSpawnPoint2.position, Quaternion.identity);
            nextfire2 = Time.time + firerate2;
        }
    }

    void Smash()
    {
        boss.gameObject.SetActive(false);
        Instantiate(slam, smashSpawnPoint.position, Quaternion.identity);
    }
}
