namespace AstroClient.Tools.Bruteforcer
{
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    internal class TextBruteforcer : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientActions.ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        private void OnRoomLeft()
        {
            if (StartBruteforcer)
            {
                StartBruteforcer = false;
            }
            TestPasscode = null;
        }

        internal static bool HasFoundCode { get; set; }  = false;
        internal static Action<string> TestPasscode { get; set; }

        

        /// <summary>
        /// Check if the password in the brute force is equal to the password being checked
        /// </summary>
        /// <param name="passwordAttempt">List of characters that make up the password that is being tested</param>
        static void CheckPassword(ref List<char> passwordAttempt)
        {
            StringBuilder attempt = new StringBuilder();

            for (int i = 0; i < passwordAttempt.Count; i++)
            {
                char letter = passwordAttempt[i];
                attempt.Append(letter);
            }

            TestPasscode.SafetyRaiseWithParams(attempt.ToString());
         }
        /// <summary>
        /// Change the character at the intended index and if there are any characters that come after the index, change those to the first ascii value
        /// </summary>
        /// <param name="index"> position of character being changed </param>
        /// <param name="letters"> List of characters that make up the password attempt </param>
        static void UpdatePasswordAttempt(int index, ref List<char> letters)
        {
            if (index != letters.Count - 1)
            {
                for (int i = index + 1; i < letters.Count; i++)
                {
                    if (letters[i] == 'z')
                    {
                        letters[i] = ASCII[0];
                    }
                }
            }
            letters[index]++;
        }



        /// <summary>
        ///  Recursive function used for checking which letter needs to be updated
        ///  If there are no letters that can be updated, a character will need to be added to the list
        /// </summary>
        /// <param name="index"> the last character in the list </param>
        /// <param name="letters"> the list of attempted characters </param>
        /// <returns> the index of the character that needs to be incremented, -1 if a new character needs to be added </returns>
        private static int GetUpdateIndex(int index, List<char> letters)
        {

            if (letters[index] == 'z')
            {
                if (index != 0)
                {
                    index = GetUpdateIndex(index - 1, letters);
                }
                else
                    return -1;
            }

            return index;

        }

        private static bool isTargetedChar(char letter)
        {
            if(letter >= 'a' && letter <= 'z')
            {
                return true;
            }

            //if(letter >= 'A' && letter <= 'Z')
            //{
            //    return true;
            //}

            //if (letter >= '0' && letter <= '9')
            //{
            //    return true;
            //}

            return false;
        }

        private static List<char> _ASCII = null;
        internal static List<char> ASCII
        {
            get
            {
                if(_ASCII == null)
                {
                    _ASCII = new List<char>();
                    _ASCII.Add('a');
                    _ASCII.Add('b');
                    _ASCII.Add('c');
                    _ASCII.Add('d');
                    _ASCII.Add('e');
                    _ASCII.Add('f');
                    _ASCII.Add('g');
                    _ASCII.Add('h');
                    _ASCII.Add('i');
                    _ASCII.Add('j');
                    _ASCII.Add('k');
                    _ASCII.Add('l');
                    _ASCII.Add('m');
                    _ASCII.Add('n');
                    _ASCII.Add('o');
                    _ASCII.Add('p');
                    _ASCII.Add('q');
                    _ASCII.Add('r');
                    _ASCII.Add('s');
                    _ASCII.Add('t');
                    _ASCII.Add('u');
                    _ASCII.Add('v');
                    _ASCII.Add('w');
                    _ASCII.Add('x');
                    _ASCII.Add('y');
                    _ASCII.Add('z');
                    _ASCII.Add('z');

                    //char letter = '0';
                    //for (int i = 0; i < 81; i++)
                    //{
                    //    _ASCII.Add(letter);
                    //    letter++;
                    //}
                    return _ASCII;
                }
                return _ASCII;
            }
        }

        /// <summary>
        /// Add a new character to the list and set all of the existing values to the first ascii value in the ascii list
        /// </summary>
        /// <param name="letters"> the list of letters that make up the password attempt </param>
        static void AddNewCharacter(ref List<char> letters)
        {
            letters.Add('a');

            for (int i = 0; i < letters.Count; i++)
            {
                letters[i] = ASCII[0];
            }
        }
        private static object RoutineObject = null;
        private static bool _StartBruteForcer = false;

        internal static bool StartBruteforcer
        {
            get
            {
                return _StartBruteForcer;
            }
            set
            {
                if (value)
                {
                    if (RoutineObject == null)
                    {
                        _StartBruteForcer = value;
                        RoutineObject = MelonCoroutines.Start(Bruteforcer());
                    }
                }
                else
                {
                    if (RoutineObject != null)
                    {
                        MelonCoroutines.Stop(RoutineObject);
                        _StartBruteForcer = value;
                    }
                }
            }
        }


        private static IEnumerator Bruteforcer()
        {
            List<char> passwordAttempt = new List<char>();

            passwordAttempt.Add('g'); // First character to be checked (if there is a minimum length, add more 0s to the list)
            passwordAttempt.Add('c');
            passwordAttempt.Add('b');
            passwordAttempt.Add('w');
            passwordAttempt.Add('u');
            passwordAttempt.Add('g');
            int Counter = 0;
            while (!HasFoundCode)
            {


                // Get the character that needs to be updated
                int index = GetUpdateIndex(passwordAttempt.Count - 1, passwordAttempt);

                if (index != -1)
                {
                    // Update the characters in the password attempt
                    UpdatePasswordAttempt(index, ref passwordAttempt);
                }
                else
                {
                    // Add a new character to the list and set all of the letter to the first ascii value
                    AddNewCharacter(ref passwordAttempt);
                }

                // Check if the password is correct
                CheckPassword(ref passwordAttempt);
                if (Counter > 1000)
                {
                    Counter = 0;
                    yield return new WaitForEndOfFrame();
                }
                else
                {
                    Counter++;
                }
            }
            yield return null;
        }




    }
}