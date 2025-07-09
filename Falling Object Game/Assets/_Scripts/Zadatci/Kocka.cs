using UnityEngine;

public class Kocka : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Sfera sfera))
        {
            Debug.Log("Usla u kocku");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Sfera sfera))
        {
            Debug.Log("Izasla iz kocke");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Sfera sfera))
        {
            Debug.Log("Sfera u kocki");

        }
    }


}
