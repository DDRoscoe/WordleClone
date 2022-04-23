using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Type : MonoBehaviour
{
    public KeyCode[] desiredKeys = {KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, 
    KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z};
    public string[] dictionary = {"adult", "beach", "chair", "dream", "enemy", "faith", "glass", "horse", "image", "judge", "knife", "light", "major", "nurse", "owner", 
    "phone", "queen", "radio", "scope", "taste", "unity", "value", "white", "young"};
    public GameObject gameOverText;
    public bool gameOver = false;
    public GameObject[] letters;
    public string stringInput; 
    private string letterInput = string.Empty;
    public string puzzleWord;
    private int randomNum;
    public int placeHolder = 0;
    private int currentTry;
    public int it = 0;
    public int numTries = 0;
    public int numCorrectLetters = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(0, 23);
        puzzleWord = dictionary[randomNum];
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }


    private bool isALetter()
    {
        foreach (KeyCode keyToCheck in desiredKeys)
        {
            if (Input.GetKeyDown(keyToCheck))
                return true;
        }
        return false;
    }


    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && it > 0)
        {
            it--;
        }
        else if (isALetter() && !Input.GetKeyDown(KeyCode.Backspace) && it < 4)
        {
            it++;
        }
        else if (it == 4 && Input.GetKeyDown(KeyCode.Return) && placeHolder < 30)
        {
            // fill the stringInput with characters
            for (int i = placeHolder; i < placeHolder + 5; i++)
            {
                stringInput += letters[i].GetComponent<InputField>().text[0];
            }

            CheckString();

            if (gameOver == false)
            {
                letters[4].GetComponent<InputField>().DeactivateInputField();
                it = 0;
                numTries++;
                placeHolder += 5;
                stringInput = "";
            }
        }

        // Activate the next input field
        if (numTries < 6 && gameOver == false)
        {
            letters[it + placeHolder].GetComponent<InputField>().ActivateInputField();
        }
    }


    private void CheckString()
    {
        numCorrectLetters = 0;

        // Check for completely right or completely wrong inputs
        for (int i = 0; i < puzzleWord.Length; i++)
        {
            if (stringInput[i] == puzzleWord[i])
            {
                letters[i + placeHolder].GetComponent<InputField>().GetComponent<Image>().color = Color.green;
                numCorrectLetters++;
            }
            else
            {
                letters[i + placeHolder].GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1);
            }
        }

        // Check for half-correct inputs
        for (int i = 0; i < puzzleWord.Length; i++)
        {
            for (int j = 0; j < puzzleWord.Length; j++)
            {
                if (stringInput[i] == puzzleWord[j] && stringInput[i] != puzzleWord[i])
                {
                    letters[i + placeHolder].GetComponent<InputField>().GetComponent<Image>().color = Color.yellow;
                }
            }
        }

        // If all letters are completely correct, win. If number tries > 6, lose.
        if (numCorrectLetters == 5)
        {
            gameOver = true;
            gameOverText.GetComponent<Text>().color = Color.green;
            gameOverText.GetComponent<Text>().text = "You win!";
            gameOverText.SetActive(true);
        }
        else if (numTries == 5)
        {
            gameOver = true;
            gameOverText.GetComponent<Text>().color = Color.red;
            gameOverText.GetComponent<Text>().text = "You lose!";
            gameOverText.SetActive(true);
        }
    }
}
