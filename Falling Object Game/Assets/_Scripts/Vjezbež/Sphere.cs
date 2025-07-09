using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private int scoreAmount;
    [SerializeField] private bool isBad;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.IncreaseScore(scoreAmount);
        }
        Destroy(gameObject);
    }

}
