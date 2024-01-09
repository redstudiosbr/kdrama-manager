using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputNameController : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button randomizeButton;
    [SerializeField] private Button saveButton;
    [SerializeField] private NameDataLoader nameDataLoader;

    private void Start()
    {
        if (randomizeButton != null)
            randomizeButton.onClick.AddListener(RandomizeName);

        if (saveButton != null)
            saveButton.onClick.AddListener(SaveName);
    }

    private void RandomizeName()
    {
        nameInputField.text = $"{nameDataLoader.GetRandomLastName()} {nameDataLoader.GetRandomAnyName()}";
    }

    private void SaveName()
    {
        string playerName = nameInputField.text;
        GameProgressManager.Instance.UpdatePlayerName(playerName);
        Debug.Log("Name saved: " + playerName);
    }
}
