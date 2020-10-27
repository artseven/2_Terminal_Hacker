using UnityEngine;

public class Hacker : MonoBehaviour {
    //Game configuration data
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    // Game state
    int level;
    enum Screen { MainMenu, Password, Win }
    string password;
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
        } else if (currentScreen == Screen.Password) {
            CheckPassword (input);
        }
    }
    void RunMainMenu (string input) {
        bool isValidLevelNumber = (input == "1" || input == "2");

        if (isValidLevelNumber) {
            level = int.Parse (input);
            AskForPassword ();
        } else if (input == "007") { //easter egg
            Terminal.WriteLine ("Please select a level Mr Bond!");
        } else {
            Terminal.WriteLine ("Please choose a valid level");
            UserMenuReminder ();
        }
    }

    void AskForPassword () {
        currentScreen = Screen.Password;
        Terminal.ClearScreen ();
        SetRandomPassword ();
        Terminal.WriteLine ("Enter your password, hint: " + password.Anagram ());
        UserMenuReminder ();
    }

    void SetRandomPassword () {
        switch (level) {
            case 1:
                password = level1Passwords[Random.Range (0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range (0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError ("Invalid level number");
                break;
        }
    }

    void UserMenuReminder () {
        Terminal.WriteLine ("Type 'menu' to return back to menu");
    }

    void CheckPassword (string input) {
        if (input == password) {
            DisplayWinScreen ();
        } else {
            Terminal.WriteLine ("Sorry, wrong password!");
        }
    }

    void DisplayWinScreen () {
        currentScreen = Screen.Win;
        Terminal.ClearScreen ();
        ShowLevelReward ();
    }

    void ShowLevelReward () {
        switch (level) {
            case 1:
                Terminal.WriteLine ("Have a book...");
                Terminal.WriteLine (@"
    ________
   /______//
  /______//                
 /______//    
(______(/

                ");
                UserMenuReminder ();
                break;
            case 2:
                Terminal.WriteLine ("Have a book...");
                Terminal.WriteLine (@"
 < blah >

                ");
                UserMenuReminder ();
                break;
            default:
                Debug.LogError ("Invalid level reached");
                break;
        }
    }
}