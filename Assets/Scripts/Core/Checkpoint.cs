using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("UI Prompt")]
    [SerializeField] private GameObject interactionPrompt; //rest dialogue popup

    [Header("Settings")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    [SerializeField] private Transform playerPosition;
    private Collider2D checkpointCollider;

    private bool isPlayerInZone = false;

    private void Awake()
    {
        checkpointCollider = GetComponent<Collider2D>();
        if (checkpointCollider == null)
        {
            Debug.LogWarning($"{nameof(Checkpoint)} on '{gameObject.name}' has no Collider2D attached.");
        }
        if (checkpointCollider.bounds.Contains(playerPosition.position))
        {
            isPlayerInZone = true;
            if (interactionPrompt != null) interactionPrompt.SetActive(true);
        }
        else
        {
            isPlayerInZone = false;
            if (interactionPrompt != null) interactionPrompt.SetActive(false);
        }

    }

    private void Update()
    {
        // Listen for the key press only if the player is in front of the checkpoint
        if (isPlayerInZone && Input.GetKeyDown(interactKey))
        {
            RestAtCheckpoint();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;
            if (interactionPrompt != null) interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
            if (interactionPrompt != null) interactionPrompt.SetActive(false);
        }
    }

    private void RestAtCheckpoint()
    {
        Debug.Log("Player pressed E and is resting!");
        if (interactionPrompt != null) interactionPrompt.SetActive(false);
    }
}
