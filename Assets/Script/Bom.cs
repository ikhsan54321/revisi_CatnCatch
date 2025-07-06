using UnityEngine;

public class Bom : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // hanya bereaksi saat menyentuh karakter
        {
            // Kena Bom kurangi nyawa
            Kucing kucing = other.GetComponent<Kucing>();
            if (kucing != null)
            {
                kucing.KurangiNyawa(); // panggil method di Kucing
            }

            Destroy(gameObject); // hancurkan item
        }
    }
}