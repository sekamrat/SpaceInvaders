using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;         // Refer�ncia ao prefab da bala
    public Transform firePoint;             // Ponto de onde as balas ser�o disparadas
    public float bulletSpeed = 30f;         // Velocidade da bala
    public float fireRate = 0.2f;           // Intervalo entre tiros (em segundos)
    public float speed = 20f;
    private float nextFireTime;             // Tempo para o pr�ximo disparo

    public AudioSource audioSource;

    void Update()
    {
        // Se a tecla espa�o for pressionada e o tempo para o pr�ximo disparo tiver passado
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        audioSource.pitch = UnityEngine.Random.Range(1f, 2f);
        audioSource.Play();
        // Instancia a bala no ponto de disparo com a rota��o do firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Define a velocidade da bala
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.linearVelocity = firePoint.forward * bulletSpeed;
        }

        // Destr�i a bala ap�s 2 segundos
        Destroy(bullet, 2f);
    }
}
