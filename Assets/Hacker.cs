using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win }
    Screen currentScreen;

    // Use this for initialization
    void Start () {
        ShowMainMenu ();
    }

    void ShowMainMenu () {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen ();
        Terminal.WriteLine ("What would you like to hack into?");
        Terminal.WriteLine ("Press 1 for the local library");
        Terminal.WriteLine ("Press 2 for the police station");
        Terminal.WriteLine ("Enter your selection:");
    }

    //this should only decide how to handle user input
    void OnUserInput (string input) {
        if (input == "menu") {
            ShowMainMenu ();
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu (input);
        } 
    }
    void RunMainMenu (string input) {
        if (input == "1") {
            level = 1;
            StartGame ();
        } else if (input == "2") {
            level = 2;
            StartGame ();
        } else if (input == "007") {
            Terminal.WriteLine ("Please select a level Mr Bond!");
        } else {
            Terminal.WriteLine ("Please choose a valid level");
        }
    }

    void StartGame () {
        currentScreen = Screen.Password;
        Terminal.WriteLine ("You have chosen level " + level);
        Terminal.WriteLine ("Please enter your password: ");
    }
}