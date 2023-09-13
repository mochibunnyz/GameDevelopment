using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttonpad : MonoBehaviour
{
        public TMP_InputField charHolder;
        public GameObject button1;
        public GameObject button2;
        public GameObject button3;
        public GameObject button4;
        public GameObject button5;
        public GameObject button6;
        public GameObject button7;
        public GameObject button8;
        public GameObject button9;

        public GameObject buttonPadPanel;

        public GameObject puzzleBook;

        // public void OpenbuttonPadPanel()
        // {
        //         if(buttonPadPanel != null)
        //         {
        //                 bool isActive = buttonPadPanel.activeSelf;

        //                 buttonPadPanel.SetActive(true);
        //         }
        // }

        void Update()
        {
                if (charHolder.text == "3")
                {
                        resetPuzzle();
                }

                if (charHolder.text == "4")
                {
                        resetPuzzle();
                }

                 if (charHolder.text == "7")
                {
                        resetPuzzle();
                }

                if (charHolder.text == "8")
                {
                        resetPuzzle();
                }
        }

        void resetPuzzle()
        {
                //show panel
                buttonPadPanel.gameObject.SetActive(true);

                //reset number in character holder
                charHolder.text = charHolder.text + "";

        }

        // void onMouseDown()
        // {
        //         if(gameObject.tag == "puzzleBook")
        //         {
        //                 bool isActive = buttonPadPanel.activeSelf;
        //                 buttonPadPanel.gameObject.SetActive(true);
        //         }
        // }


        public void b1()
        {
                charHolder.text = charHolder.text + "1";

                // if ()
                // {
                //         var colors = GetComponent<Button> ().colors;
                //         colors.normalColor = Color.white;
                //         colors.highlightedColor = new Color(152, 152, 152);
                //         colors.pressedColor = new Color(185, 255, 170);
                //         GetComponent<Button> ().colors = colors;
                // }

        }

        public void b2()
        {
                charHolder.text = charHolder.text + "2";
        }

        public void b3()
        {
                charHolder.text = charHolder.text + "3";
        }

        public void b4()
        {
                charHolder.text = charHolder.text + "4";
        }

        public void b5()
        {
                charHolder.text = charHolder.text + "5";
        }

        public void b6()
        {
                charHolder.text = charHolder.text + "6";
        }

        public void b7()
        {
                charHolder.text = charHolder.text + "7";
        }

        public void b8()
        {
                charHolder.text = charHolder.text + "8";
        }

        public void b9()
        {
                charHolder.text = charHolder.text + "9";
        }
        

        public void enterEvent()
        {
                if (charHolder.text == "12569")
                {
                    Debug.Log("correct");
                    buttonPadPanel.SetActive(false);
                }

                else 
                {
                    Debug.Log("wrong");
                }


                if (charHolder.text == "3")
                {
                    Debug.Log("wrong");
                }

                if (charHolder.text == "4")
                {
                    Debug.Log("wrong");
                }

                if (charHolder.text == "7")
                {
                    Debug.Log("wrong");
                }

                if (charHolder.text == "8")
                {
                    Debug.Log("wrong");
                }

        }

}
