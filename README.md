> **_NOTE:_** This README file is copied from the original project thus previous parts of the project are referenced. This was kept in to demonstrate the feedback implementation in this project.

**This application stores recipes that a user inputs temporarily while the program is running.**

# System requirements

- Must be using a Windows operating system (Windows 7 or later version)
- Must have Microsoft Visual Studio installed and is able to run WPF applications on it.

# Installing and Starting the program

1. In order to install this program the user can download a zipped folder of this program from this GitHub repository.

2. To open the program the user can open a file within the programs folder with the extension 'sln'. 

3. Once the file is open in Microsoft visual studio with its code displayed the user can click the 'start without debugging' option. 

4. A window should appear on the screen indicating the program has started running.

# Using the program

- When the program starts up the user is greeted with a window with a heading saying "Sanele's recipe app" with a button saying 'view my recipes'.

- The user will be taken to a screen that shows various buttons and fields, this will be referred to as the "Display Recipe Window".
- The user can add a recipe by clicking the "add a recipe" button
- The user can enter an unlimited amount of recipes by using this button.
- A window will appear with various fields for the user to fill in regarding the recipe's information.
- To add a step the user will fill the relevant textbox under the "add a step" title, this can be done as many times as the user desires.
- To add an ingredient the user will click the "add ingredient" button, this can be done as many times as the user desires.
- When the button is clicked a window will appear with various fields for the user to fill in regarding the ingredients information.
- The relevant textbox will be filled for the ingredient's name, amount and calory amount.
- The relevant dropdown menus will be displayed for the user to choose their desired option for the ingredients' unit of measurement and food group.
- If the desired unit of measurement is not in the dropdown menu then the user can input their desired unit of measurement in the textbox with 'other' written in it.
- If at any point throughout the application the user inputs an invalid input the program will inform the user.
- When the user has entered the various fields with their desirable information then they can click the 'add'  to add the ingredient to the recipe.
- This will also cause the add ingredient window to close.
- To enter the recipes' name the user fills the field under the 'Recipe Name' heading. 
- To display the recipe's current information the user would press the refresh button.
- To add the recipe displayed to the list of all the recipes the user would click the add button.
- When the user clicks the refresh button in the display recipes window the latest list of all the recipes stored will be displayed to the user.
- To filter the recipes the user will select from the relevant dropdown menu which filtering method they desire and then fill in the relevant information in the textbox next to it then they click the filter button.
- To search a recipe the user will enter the desired recipe into the relevant textbox and click the search button.
- When the filter or search button is clicked an additional button saying 'show all recipes' on it will appear, the user will click this when they desire to see all the recipes stored in the application. 
- To clear a recipe's data the user will select which recipe they desire to clear from the list box displaying all the recipes, the user will then click the 'Clear Recipe' button. The user will be prompted if check if they are sure that they want to clear the recipe, the user should follow the prompt accordingly.
- To scale a recipe the user will select which recipe they desire to scale they will then select by which factor to scale the recipe by using the relevant dropdown menu the user will then select which recipe they desire to scale and then click the button with 'Scale' written on it.
    -To revert a recipe back to its original values the user will select the recipe they desire to revert then click the button labeled 'Revert'
- If the user wants to use a recipe and view it in a manner that will be useful they would select the relevant recipe and then click the make this recipe button.
    - A window will appear that displays the recipe selected and it allows the user to check boxes next to each step as they complete it.
    - To leave this window the user can click the button labeled 'Back'.
- This application will also automatically convert the quantities of a recipe to a reasonable quantity (for example 16 tablespoons will be converted to 1 cup), this is done both when the user enters the recipe and when the user scales their recipe. 
- The application will also inform the user about calories and food groups. 
    - The user will also be informed if their recipe exceeds the recommended daily calories or if it is over half the amount of the recommended daily calories.
    - The total calories will also be printed along with its associated recipe and its information.
- If the user clicks the button labeled 'Exit' the program will be terminated.

# Updates made for POE Final Part
- The program's user interface is no longer the console. Instead the more user-friendly WPF application foundation is used for the user to interface with.
- The ability for the user to filter the recipes displayed has also been added.
    - The user can either filter the recipes by:
       - Entering the name of an ingredient they want to be present in the recipe
       - Choosing which food group must be present in the recipe
       - Entering the maximum amount of calories the recipes can have
## Changes made to code according to POE Part 2 feedback
- I achieved a mark of 100% in my previous submission thus I did not need to make any additional changes to my code. 
