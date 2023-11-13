
/*------------------------------------------------------------------------------
 *                      HTBLA-Leonding / Class: 3ACIF                           
 *------------------------------------------------------------------------------
 *                      Jan Ritt                                                
 *------------------------------------------------------------------------------
 *  Description:  A simple program for a cash vending maschine.                     
 *------------------------------------------------------------------------------
*/
using System;
using System.Text;
using System.Threading;


namespace CashMaschine
{
  class Program
  {
    static void Main()
    {
      Console.OutputEncoding = Encoding.UTF8;    ///  encoding to show € in console
      /*  Variables  */
      char choice;           ///  input choices
      // TESTING INPUTS
      bool testDouble,       ///  for double
           testInt;         ///  for integes 

      // VENDING MACHINE
      int machineBalance;    ///  money in the vending machine
      machineBalance = 12000;

      // USER
      int userPin,           ///  PIN-Code
         userBalance,       ///  Acount-balance
         userLimit;         ///  Acount-limit
      /// USERDATA
      userPin = 1234;
      userBalance = 3000;
      userLimit = 1000;

      /// INPUT
      int amountOfInputs = 0,
         userInputInt;
      string userInputString;

      /* INTRODUCTION */
      /// HEADER 
      Console.Clear();
      Console.Write("\n" +
                   "\n══════════════════════════════════" +
                   "\n  CASH VENDING MACHINE " +
                   "\n══════════════════════════════════");
      /* USER PIN INPUT */
      Console.Write("\n" +
                   "\n Bitte geben Sie ihren 4 stelligen PIN-Code ein:  ");
      // 3 POSSIBLE INPUTS
      do    ///  
      {
        amountOfInputs++;    ///  increment counter
        Console.Write($"\n   Eingabeversuch {amountOfInputs}/3 :  ");

        do    ///  PROMPT for valid integer
        {
          userInputString = Console.ReadLine();
          testInt = int.TryParse(userInputString, out userInputInt);
          if (testInt != true)    ///  parse didn't work
          {
            Console.Write("\n Sie können nur Pin-Zahlen eingeben!" +
                         "\n   weiterhin:" +
                        $"\n   Eingabeversuch {amountOfInputs}/3 :  ");
          }
        } while (testInt != true);
        // test PIN
        if (userInputInt != userPin)    ///  WRONG pin
        {
          Console.Write("\n Ihr eingegebener PIN ist falsch!" +
                       "\n    ");
        }
        else    ///  CORRECT pin
        {
          amountOfInputs = 3;    ///  -> quit loop early
        }
      } while (amountOfInputs < 3);   ///  loop 3 times
      // too many wrong inputs //
      if (userInputInt != userPin)    ///  wrong pin
      {
        Console.Write("\n Sie haben den PIN zu oft falsch eingegeben!" +
                     "\n    !  die Karte wird eingezogen  !");
        ///  EXIT PROMPT
        Console.Write("\n══════════════════════════════════" +
                     "\n Beenden mit beliebiger Taste ...  ");
        Console.ReadKey();
        Console.Clear();
      }
      /* CORRECT PIN */
      // GET YOUR MONEY //
      else if (userInputInt == userPin)
      {
        do    ///  input loop
        {
          do    ///  PROMPT for valid integer 
          {
            Console.Write("\n TOLL" +
                        $"\n    Ihr Kontostand:            {userBalance} €" +
                        $"\n   ( + Ihr Überziehungsrahmen: {userLimit} € )" +
                        $"\n ------------------------------------------------------" +
                        $"\n    maximaler Betrag:          {userBalance + userLimit} €" +
                        $"\n    Geben Sie den Betrag ein, " +
                        $"\n    den Sie abheben wollen:    ");
            userInputString = Console.ReadLine();
            testInt = int.TryParse(userInputString, out userInputInt);
            if (testInt != true)
            {
              Console.Write("\n    Sie können nur einen ganzzahligen Betrag " +
                           "\n    eingeben:            ");
            }
          } while (!testInt);
          // TEST THE MONEY AMOUNT //

          if (userInputInt <= userBalance)    ///  money avaliable
          {
            userBalance = userBalance - userInputInt;
            Console.Write("\n    Sie haben den Betrag am Konto verfügbar." +
                        $"\n     neuer Kontostand:         {userBalance}");
          }
          else if (userInputInt <= (userBalance + userLimit))
          {
            userInputInt = userInputInt - userBalance;
            userLimit = userLimit - userInputInt;
            userBalance = 0;
            Console.Write("\n    Ihr Limit reicht aus, um diese Abhebung durchzuführen." +
                        $"\n     neuer Kontostand:             0,00€ " +
                        $"\n     verfügbares Limit:         {userLimit}");
          }
          else if (userInputInt > machineBalance)    ///  machine empty
          {
            Console.Write("\n   ! derzeit keine Abhebungen in dieser Höhe möglich !\n");
          }
          else    ///  not enough money
          {
            Console.Write("\n   ! nicht die nötige Liquidität !\n");
          }
          /// PROMT imput loop
          Console.Write("\n    Eingabe wiederholen?  [ j / n ]    ");
          choice = Console.ReadKey().KeyChar;
        } while (char.ToUpper(choice) == 'J');

        /// wait 0.5 seconds   
        Thread.Sleep(500);
        ///  EXIT PROMPT
        Console.Write("\n══════════════════════════════════" +
                     "\n Beenden mit beliebiger Taste ...  ");
        Console.ReadKey();
        Console.Clear();
      }
    }
  }
}