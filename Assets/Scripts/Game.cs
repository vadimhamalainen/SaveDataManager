using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject greetingsTextGO;
    private Text greetingsText;

    public GameObject confirmButtonGO;
    private Button confirmButton;

    public GameObject scoreInputFieldGO;
    private InputField scoreInputField;

    public GameObject menuButtonGO;
    private Button menuButton;

    int maxScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreInputField = scoreInputFieldGO.GetComponent<InputField>();
        greetingsText = greetingsTextGO.GetComponent<Text>();
        
        confirmButton = confirmButtonGO.GetComponent<Button>();
        confirmButton.onClick.AddListener(ConfirmButtonClick);

        menuButton = menuButtonGO.GetComponent<Button>();
        menuButton.onClick.AddListener(MenuButtonOnClick);

        string greetingsName = "no player name";

        if(SaveDataManager.instance != null)
        {
            greetingsName = SaveDataManager.instance.playerName;
            maxScore = SaveDataManager.instance.maxScore;                     
        }
        
        greetingsText.text = "Hello " + greetingsName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ConfirmButtonClick()
    {
        try
        {
            int inputScore = Convert.ToInt32(scoreInputField.text);
            if(SaveDataManager.instance != null)
            {
                if (inputScore > SaveDataManager.instance.maxScore)
                {
                    SaveDataManager.instance.maxScore = inputScore;
                    SaveDataManager.SaveData();

                    greetingsText.text = "Congratulations";

                    //SceneManager.LoadScene("Menu");
                }
                else
                {
                    greetingsText.text = "try number higher";
                }
            }

        }
        catch
        {

        }


        
    }

    private void MenuButtonOnClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
