using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireIntervalMin = 1.5f;
    public float fireIntervalMax = 3.5f;
    public int vida = 1;

    private float nextFireTime;

    public AudioSource audioSource;
    public AudioClip somInimigo;
    void Start()
    {
        ScheduleNextShot();
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            ScheduleNextShot();
        }
    }

    void ScheduleNextShot()
    {
        nextFireTime = Time.time + Random.Range(fireIntervalMin, fireIntervalMax);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
            rb.linearVelocity = Vector3.down * bulletSpeed;
        Destroy(bullet, 3f);
    }

    public void TomarDano(int dano)
    {
        vida -= dano;
        
        if (vida <= 0)
        {
            // Score baseado no tempo de jogo
            int pontos = Mathf.FloorToInt(Time.timeSinceLevelLoad);
            ScoreManager.instance?.AddPoint(pontos);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            audioSource.pitch = UnityEngine.Random.Range(3f, 5f);
            audioSource.PlayOneShot(somInimigo);
            TomarDano(1);
            Destroy(other.gameObject);
        }
    }
}
