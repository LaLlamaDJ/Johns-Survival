using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject bullet;
    public GameObject john_idle_0;

    private float LastShoot;
    private int Health = 20;

    private void Update()
    {
        if (john_idle_0 == null) return;

        Vector3 direction = john_idle_0.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(john_idle_0.transform.position.x - transform.position.x);

        if(distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;


        GameObject Bullet = Instantiate(bullet, transform.position + direction * 0.1f, Quaternion.identity);
        Bullet.GetComponent<Bala>().SetDirection(direction);
    }

    public void Hit()
    {
        Health = Health - 5;
        if (Health == 0) Destroy(gameObject);
    }
}
