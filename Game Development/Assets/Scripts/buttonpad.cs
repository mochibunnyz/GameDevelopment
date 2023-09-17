using System;
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

        public GameObject treasureChest;

        public GameObject resetCanvas; // Reference to the Canvas GameObject you want to show.
        private bool showingResetCanvas = false;
        private float resetCanvasDuration = 3.0f;
        private float resetCanvasTimer = 0.0f;


        public bool PuzzleSolved {get {return puzzleSolved;}}
        public event Action OnPuzzleSolved;
        private bool puzzleSolved = false;


        void Start()
        {
                buttonPadPanel.SetActive(true);
        }
        
        void Update()
        {
                // Check if we should hide the resetCanvas after a certain duration
                if (showingResetCanvas)
                {
                        resetCanvasTimer += Time.deltaTime;
                        if (resetCanvasTimer >= resetCanvasDuration)
                        {
                                HideResetCanvas();
                        }
                }
        }

        void resetPuzzle()
        {
                //reset number in character holder
                charHolder.text = string.Empty;
                Debug.Log("puzzle reset");

                // Show the resetCanvas
                showingResetCanvas = true;
                resetCanvas.SetActive(true);

                // Start the timer for hiding the resetCanvas
                resetCanvasTimer = 0.0f;

        }

        public void b1()
        {
                charHolder.text = charHolder.text + "1";
                Debug.Log("button 1");
                checkAnswer();
        }

        public void b2()
        {
                charHolder.text = charHolder.text + "2";
                Debug.Log("button 2");
                checkAnswer();
        }

        public void b3()
        {
                charHolder.text = charHolder.text + "3";
                Debug.Log("button 3");
                checkAnswer();
        }

        public void b4()
        {
                charHolder.text = charHolder.text + "4";
                Debug.Log("button 4");
                checkAnswer();
        }

        public void b5()
        {
                charHolder.text = charHolder.text + "5";
                Debug.Log("button 5");
                checkAnswer();
        }

        public void b6()
        {
                charHolder.text = charHolder.text + "6";
                Debug.Log("button 6");
                checkAnswer();
        }

        public void b7()
        {
                charHolder.text = charHolder.text + "7";
                Debug.Log("button 7");
                checkAnswer();
        }

        public void b8()
        {
                charHolder.text = charHolder.text + "8";
                Debug.Log("button 8");
                checkAnswer();
        }

        public void b9()
        {
                charHolder.text = charHolder.text + "9";
                Debug.Log("button 9");
                checkAnswer();
        }
        

        void checkAnswer()
        {
                if (charHolder.text == "1")
                {
                    Debug.Log("correct");
                }
                        
                else if (charHolder.text == "12")
                {
                         Debug.Log("correct");
                }
                
                else if (charHolder.text == "125")
                {
                        Debug.Log("correct");
                }
                                                
                else if (charHolder.text == "1256")
                {
                        Debug.Log("correct");
                }
                                                        
                else if (charHolder.text == "12569")
                {
                        Debug.Log("puzzle solved");
                        buttonPadPanel.SetActive(false);
                        charHolder.text = string.Empty;

                        puzzleSolved = true;
                        OnPuzzleSolved?.Invoke();

                        //treasure appears
                        treasureChest.gameObject.SetActive(true);
                }

                else
                {
                    Debug.Log("wrong");
                    resetPuzzle();
                }

        }

        void HideResetCanvas()
        {
                resetCanvas.SetActive(false);
                showingResetCanvas = false;
        }

}
