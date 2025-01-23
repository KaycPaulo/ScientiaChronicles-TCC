using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private string destinyId;
    private bool canTeleport = true;
    private StartTransitionManager transitionManager;


    private void Start()
    {
        transitionManager = FindObjectOfType<StartTransitionManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player) && canTeleport)
        {
            StartCoroutine(TeleportWithTransition(player));
        }
    }

    private IEnumerator TeleportWithTransition(Player player){
        if(transitionManager != null){
            yield return StartCoroutine(transitionManager.FadeOut());
        }

        TeleportPlayer(player);

        if(transitionManager != null){
            yield return StartCoroutine(transitionManager.FadeIn());
        }
    }

    private void TeleportPlayer(Player player)
    {
        
        Transform exitPoint = TeleporterManager.Instance.SearchPoints(destinyId);

        if (exitPoint != null)
        {
            
            player.transform.position = exitPoint.position;
            player.transform.rotation = exitPoint.rotation;

            
            Teleporter outerTeleporter = exitPoint.GetComponent<Teleporter>();
            if (outerTeleporter != null)
            {
                outerTeleporter.DisableTeleportTemporarily();
            }

            
            DisableTeleportTemporarily();
        }
    }

    private void DisableTeleportTemporarily()
    {
        canTeleport = false;
        Invoke(nameof(EnableTeleport), 0.5f);
    }

    private void EnableTeleport()
    {
        canTeleport = true;
    }
}
