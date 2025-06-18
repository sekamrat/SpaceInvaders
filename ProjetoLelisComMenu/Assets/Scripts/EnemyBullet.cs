using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tomardano dano = other.GetComponent<tomardano>();
            if (dano != null)
                dano.TomarDano(1);
            Destroy(gameObject);
        }
    }
}
