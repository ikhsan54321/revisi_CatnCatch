using UnityEngine;

public class Item : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // hanya bereaksi saat menyentuh karakter
        {
            // Ambil komponen Kucing untuk tambah poin
            Kucing kucing = other.GetComponent<Kucing>();
            if (kucing != null)
            {
                kucing.TambahPoin(); // panggil method di Kucing
            }

            Destroy(gameObject); // hancurkan item
        }
    }
}