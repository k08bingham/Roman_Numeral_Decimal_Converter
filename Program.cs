using System;
namespace RomanNumeraltoNumber
{
class Program
{
static void Main(string[] args)
{
    string runner = "Y";
    while (runner == "Y"){ 
        
        Console.WriteLine("Type Decimal number or Roman Numeral up to a value of 3999 to be converted... \n");  
        string thingIn = "I";
        thingIn = Console.ReadLine();
        bool isIntString = thingIn.All(char.IsDigit);  //Googled what command to use

        if (isIntString == true) {
      	    Console.WriteLine("Decimal input.  Will convert to Roman Numerals.\n");
            int thingInNum = int.Parse(thingIn);  //Googled what command to use
            string theOutput = ToRomanNum(thingInNum);
            Console.WriteLine("You entered "+thingIn+".  In the Roman Numeral system, that value would be written: "+theOutput+".");
        } else {
      	    Console.WriteLine("Roman Numeral input.  Will convert to Decimal answer.\n");
            string theOutput = ToNumber(thingIn);
            Console.WriteLine("You entered "+thingIn+".  In the Decimal system, that value would be written: "+theOutput+".");
        }  //END    If-Else

        Console.WriteLine("Type 'Y' to try again, or any other character to end program.");
        runner = Console.ReadLine();
    } //END while loop

}//END Main

public static string ToRomanNum (int myNumber) {
    string NumToRomanNum = "";
    while (myNumber > 0) {
        if (myNumber > 999) {
            NumToRomanNum += "M";
            myNumber -= 1000;
        } else if (myNumber > 899) {
            NumToRomanNum += "CM";
            myNumber -= 900;
        } else if (myNumber > 499) {
            NumToRomanNum += "D";
            myNumber -= 500;
        } else if (myNumber > 399) {
            NumToRomanNum += "CD";
            myNumber -= 400;
        } else if (myNumber > 99) {
            NumToRomanNum += "C";
            myNumber -= 100;
        } else if (myNumber > 89) {
            NumToRomanNum += "XC";
            myNumber -= 90;
        } else if (myNumber > 49) {
            NumToRomanNum += "L";
            myNumber -= 50;
        } else if (myNumber > 39) {
            NumToRomanNum += "XL";
            myNumber -= 40;
        } else if (myNumber > 9) {
            NumToRomanNum += "X";
            myNumber -= 10;
        } else if (myNumber > 8) {
            NumToRomanNum += "IX";
            myNumber -= 9;
        } else if (myNumber > 4) {
            NumToRomanNum += "V";
            myNumber -= 5;
        } else if (myNumber > 3) {
            NumToRomanNum += "IV";
            myNumber -= 4;
        } else {
            NumToRomanNum += "I";
            myNumber -= 1;
        } //END if-else
    }//END while
    return NumToRomanNum;
}//END ToRomanNum

public static string ToNumber (string myRomanNum) {
    int currentDigit = 0;
    int finalNum = 0;

    while(currentDigit < myRomanNum.Length){ //Looks at each character in the Roman Num
        char currentChar = myRomanNum[currentDigit];   //Googled syntax
        if        (currentChar == 'M'){ // Check for 1000
            finalNum += 1000;

        } else if (currentChar == 'D') { // Check for 500
            finalNum += 500;

        } else if (currentChar == 'C') { // Check for 100
            // "C" can be used for special cases (400 or 900) which needs next char
            if (currentDigit < myRomanNum.Length-1){ 
                char nextChar = myRomanNum[currentDigit +1];
                if (nextChar == 'M') { // Check for 900 special case
                    finalNum += 900;
                    currentDigit +=1;
                } else if (nextChar == 'D') { // Check for 400 special case
                    finalNum += 400;
                    currentDigit +=1;
                } else {
                    finalNum += 100; // Adds the 100 by itself
                }
            } else {
                finalNum += 100; // If last char, then add 100
            }
        } else if (currentChar == 'L') { // Check for 50
            finalNum += 50;

        } else if (currentChar == 'X') { // Check for 10,
            // "X" can be used for special cases (40 or 90) which needs next char
            if (currentDigit < myRomanNum.Length-1){
                char nextChar = myRomanNum[currentDigit +1];

                if (nextChar == 'C') { // Check for 90
                    finalNum += 90;
                    currentDigit +=1;
                } else if (nextChar == 'L') { // Check for 40
                    finalNum += 40;
                    currentDigit +=1;
                } else {
                    finalNum += 10; // Adds the 10 by itself
                }
            } else {
                finalNum += 10; // If last char, then add 10
            }
        } else if (currentChar == 'V') { // Check for 5
            finalNum += 5;
        } else if (currentChar == 'I') { // Check for 1
            // "I" can be used for special cases (4 or 9) which needs next char
            if (currentDigit < myRomanNum.Length-1){
                char nextChar = myRomanNum[currentDigit +1];
        
                if (nextChar == 'X') { // Check for 9
                    finalNum += 9;
                    currentDigit +=1;
                } else if (nextChar == 'V') { // Check for 4
                    finalNum += 4;
                    currentDigit +=1;
                } else {
                finalNum += 1; // Adds the 1 by itself
                }
            } else {
                finalNum += 1; // If last char, then add 1
            }
        } else {
            // If user entered an incorrect letter...
            return "Invalid Character: Not a Roman Numeral";
        }
        currentDigit += 1; // Move to next Digit
        // Extra digit is already moved if 'combo' is found (4, 9, etc)
        }
    return Convert.ToString(finalNum);  //Googled what command to use
}//END ToNumber

}//END Program
 
}//END RomanNumeral