using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera playerCamera; // Câmera principal que segue o jogador
    public Camera cutsceneCamera; // Câmera para cutscene

    private CameraFollowNpc cameraFollowNpc; // Referência ao script CameraFollow2D

    void Start()
    {
        // Tenta pegar automaticamente o componente CameraFollow2D na câmera do player
        cameraFollowNpc = playerCamera.GetComponent<CameraFollowNpc>();
    }

    public void ActivateCutsceneCamera()
    {
        if (cameraFollowNpc != null)
        {
            cameraFollowNpc.SetFollowing(false);
        }

        playerCamera.gameObject.SetActive(false);
        cutsceneCamera.gameObject.SetActive(true);
    }

    public void ActivatePlayerCamera()
    {
        cutsceneCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);

        if (cameraFollowNpc != null)
        {
            cameraFollowNpc.SetFollowing(true); // Reativa o comportamento de seguir
        }
    }
}
