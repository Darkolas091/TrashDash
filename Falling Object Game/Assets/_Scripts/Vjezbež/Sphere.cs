using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private int scoreAmount;
    [SerializeField] private bool isBad;

    private bool wasCaught = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            wasCaught = true;
            playerMovement.IncreaseScore(scoreAmount);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Floor"))
        {
            if (!isBad && !wasCaught)
            {
                Debug.Log("Good Fell");
                PlayerMovement.Instance.BreakCombo();
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Bad Fell");
                Destroy(gameObject);
            }
        }

    }
}
