using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerNameManager : MonoBehaviour
{
    public TMP_InputField nameInputField; // Campo de entrada para o nome
    public Button confirmButton; // Botão de confirmação
    public static string playerName = "Katsu"; // Nome padrão

    void Start()
    {
        // Desabilita o botão inicialmente
        confirmButton.interactable = false;

        // Adiciona o evento de validação para o campo de entrada
        nameInputField.onValueChanged.AddListener(delegate { ValidateInput(); });

        // Adiciona o evento de clique no botão "Confirmar"
        confirmButton.onClick.AddListener(SetPlayerNameAndLoadScene);
    }

    private void ValidateInput()
    {
        // Habilita o botão apenas se o campo não estiver vazio
        confirmButton.interactable = !string.IsNullOrEmpty(nameInputField.text);
    }

    private void SetPlayerNameAndLoadScene()
    {
        // Salva o nome do jogador
        playerName = nameInputField.text;
        Debug.Log("Nome do jogador: " + playerName);

        // Carrega a próxima cena
        SceneManager.LoadScene("MainScene");
    }
}
