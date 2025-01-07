using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private string destinyId; // ID do ponto de destino
    private bool canTeleport = true; // Controle para evitar loops de teleporte
    private StartTransitionManager transitionManager;


    private void Start()
    {
        transitionManager = FindObjectOfType<StartTransitionManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou no trigger é o Player
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
        // Busca o ponto de destino pelo TeleporterManager
        Transform exitPoint = TeleporterManager.Instance.SearchPoints(destinyId);

        if (exitPoint != null)
        {
            // Move o jogador para o ponto de destino
            player.transform.position = exitPoint.position;
            player.transform.rotation = exitPoint.rotation;

            // Desativa temporariamente o teleporte do outro ponto
            Teleporter outerTeleporter = exitPoint.GetComponent<Teleporter>();
            if (outerTeleporter != null)
            {
                outerTeleporter.DisableTeleportTemporarily();
            }

            // Desativa temporariamente o teleporte deste ponto
            DisableTeleportTemporarily();
        }
        else
        {
            Debug.LogWarning($"Ponto de teleporte com ID '{destinyId}' não encontrado.");
        }
    }

    private void DisableTeleportTemporarily()
    {
        canTeleport = false;
        Invoke(nameof(EnableTeleport), 0.5f); // Reativa o teleporte após um curto intervalo
    }

    private void EnableTeleport()
    {
        canTeleport = true;
    }
}
