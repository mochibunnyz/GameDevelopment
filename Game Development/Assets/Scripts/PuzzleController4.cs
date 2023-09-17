using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PuzzleController4 : MonoBehaviour
{
    public Canvas KeypadCanvas;
    public GameObject KeyPad;
    public GameObject Sign;
    public GameObject Fences;
    public GameObject WorkingKeyPad;
    public RawImage ImageBackground;
    string Code = "302";
    string Nr = null;
    int NrIndex = 0;
    int WrongCounter = 0;
    int Case = 0;
    string aplha;
    public Text UiText = null;
    string TheCode = "HEW";
    public Text CodeText;
    public TextMeshProUGUI OnSceneCode_Text;
    public Text AttemptText;
    int Attempts = 3;

    public void CodeFunction(string Numbers)
    {   //code to allow the user to key in numbers
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }

    public void Enter()
    {
        if (Nr == Code)
        {  //check if the puzzle on the input keypad matches the code and destroy function will kick in to free the chest
            UiText.text = "Correct";
            StartCoroutine(PuzzleSolved());
            Cursor.visible = false;
            Destroy();


        }
        else if (Nr != Code)
        {   //When the input code does not match the code to be solved, the user would have used one attempt which will count each time there is a wrong input
            UiText.text = "Try again";
            StartCoroutine(PuzzleWrong());
            WrongCounter++;
            Attempts--;
            AttemptText.text = "Attempts left: " + Attempts;
        }

        if (Nr != Code & WrongCounter == 3 & Case == 0)
        {  // Case 0 where the user  entered the wrong passcode three times and the puzzle is reset, it will change the code in the text as well as attempts
            UiText.text = "Puzzle reset";
            Code = "581";
            TheCode = "Q V U";
            CodeText.text = TheCode;
            OnSceneCode_Text.text = TheCode;
            WrongCounter = 0;
            Case++;
            Attempts = 3;
            AttemptText.text = "Attempts left: " + Attempts;



        }
        if (Nr != Code & WrongCounter == 3 & Case == 1)
        {   // Case 1 where the user and entered the wrong passcode six times and the puzzle is reset, it will change the code in the text as well as attempts 
            UiText.text = "Puzzle reset";
            Code = "102";
            TheCode = "U E W";
            CodeText.text = TheCode;
            OnSceneCode_Text.text = TheCode;
            WrongCounter = 0;
            Case++;
            Attempts = 3;
            AttemptText.text = "Attempts left: " + Attempts;

        }
        if (Nr != Code & WrongCounter == 3 & Case == 2)
        {   // Case 2 where the user and entered the wrong passcode nine times and the puzzle is reset, it will change the code in the text as well as attempts 
            UiText.text = "All Attempts used";
            Code = "810";
            TheCode = "V U E";
            CodeText.text = TheCode;
            OnSceneCode_Text.text = TheCode;
            WrongCounter = 0;
            Case = 0;
            //Set the case to zero so that the puzzle will not stop if the player keeps getting it wrong as he will go in a loop from case 0 to 1 to 2 and back to 0
            Attempts = 3;
            AttemptText.text = "Attempts left: " + Attempts;

        }
    }
    public void Destroy()
    {  //Destroy the gameobjects and canvas so that the player is able to get the treasure chest
        Destroy(KeyPad);
        Destroy(Sign);
        Destroy(Fences);
        Destroy(WorkingKeyPad);
        Destroy(ImageBackground);
    }
    private IEnumerator PuzzleSolved()
    {  //added delay so that the player knows that they have solved the puzzle
        yield return new WaitForSeconds(2);
        KeypadCanvas.enabled = false;
    }

    private IEnumerator PuzzleWrong()
    {   //auto clear the passcode they have typed in wrongly
        yield return new WaitForSeconds(1);
        Delete();
    }

    public void Delete()
    { //Delete function to remove what they have written that they may feel is wrong on the passcode
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
    }
}