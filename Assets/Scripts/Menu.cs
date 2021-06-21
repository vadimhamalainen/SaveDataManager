using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject maxScoreTextGO;
    private Text maxScoreText;

    public GameObject playerNameInputFieldGO;
    private InputField playerNameInputField;

    public GameObject playerNamePlaceHolderGO;
    private Text playerNamePlaceHolderText;

    public GameObject confirmButtonGO;
    private Button confirmButton;

    // Start is called before the first frame update
    void Start()
    {
        maxScoreText = maxScoreTextGO.GetComponent<Text>();

        playerNameInputField = playerNameInputFieldGO.GetComponent<InputField>();
        playerNamePlaceHolderText = playerNamePlaceHolderGO.GetComponent<Text>();

        confirmButton = confirmButtonGO.GetComponent<Button>();
        confirmButton.onClick.AddListener(ConfirmButtonOnClick);

        if(SaveDataManager.instance != null)
        {
            SaveDataManager.LoadData();

            playerNamePlaceHolderText.text = SaveDataManager.instance.playerName;
            maxScoreText.text = "max score: " + SaveDataManager.instance.maxScore;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ConfirmButtonOnClick()
    {
        if(SaveDataManager.instance != null)
        {
            SaveDataManager.instance.playerName = playerNameInputField.text;
            SaveDataManager.SaveData();

            SceneManager.LoadScene("Game");
        }
    }
}
