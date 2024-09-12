
# Developer Challenge: Word Finder

## Objective: 
The objective of this challenge is not necessarily just to solve the problem, but to evaluate your software development skills, code quality, analysis, creativity, and resourcefulness as a potential future colleague. Please share the necessary artifacts you would provide to your colleagues in a real-world professional setting to best evaluate your work.
##
Presented with a character matrix and a large stream of words, your task is to create a Class that searches the matrix to look for the words from the word stream. Words may appear horizontally, from left to right, or vertically, from top to bottom.
 
The search code must be implemented as a class with the following interface:

```c
public class WordFinder
{ 	
    public WordFinder(IEnumerable<string> matrix) { 
        ... 
    }
    public IEnumerable<string> Find(IEnumerable<string> wordstream) { 
        ... 
    }
}

```

The WordFinder constructor receives a set of strings which represents a character matrix. The matrix size needs to be 64x64, all strings contain the same number of characters.
The "Find" method should return the top 10 most repeated words from the word stream found in the matrix. If no words are found, the "Find" method should return an empty set of strings. If any word in the word stream is found more than once within the stream, the search results should count it only once.

Due to the size of the word stream, the code should be implemented in a **high performance** fashion both in terms of efficient algorithm and utilization of system resources. Where possible, please include your analysis and evaluation.

## Solution, Implementation and Functionality

The Word Finder application has two ways of work:

#### 1. Using text files to insert characters grid and words stream
If we choose this option, the application will ask first for the full file path of the character grid to process it.
Example: **C:\Files\grid.txt**
The application will make some validations, and if the file is succesfully processed, the application will create a matrix with the content and after that it will ask for the word stream full file path to process it.
Example: **C:\Files\words.txt**
The application will process the content and split the words that are inside in a list, to use within the grid.

#### 2. Insert characters grid and words stream manually
If we choose this option, the application will ask first to insert manually the characters of the row. We are going to insert row by row, and when we finish to write all the rows, we have to press enter (without any value) and the application will validate the data that we inserted and will try to create the matrix with this content.
After that we will have to make a similar step but to insert the words that are we going to use within the matrix, so the application will ask to insert manually word by word, and when we finish to insert all the words, we have to press enter (without any value) and the application will create a list to use these words within the grid.

##

#### public WordFinder(IEnumerable<string> matrix)
This constructor is in charge of receive a **IEnumerable\<string> matrix** that has inside our future grid. First we are going to make some validation:
- Check that the matrix has at leaste one row.
- Check that is not longer that 64 rows / 64 characters.
- Check that all the rows have the same number of characters.

If the matrix pass these validations, the constructor will iterate the content and create the grid that will be strored on a private variable.

#### public IEnumerable<string> Find(IEnumerable<string> wordstream)
This method is in charge of receive a **IEnumerable\<string> wordstream** that has inside the words that will search within the grid. First we validate that we have at least one word inside the wordStream. After that we get the number of rows and columns of the grid and we start to search the words.
the method will iterate the wordStream and for each word it will search within the grid horizontally and vertically. The idea first is to find the first character of the word in any place of the grid, orderly using iteration for both positions. If we find the first character, we will check if the second character matches, and the same process up to end all the word. Is also imporante to check the length of the word and how many rows or columns we have at the moment of search, because it hasn't got any sense to search a word that has 10 characters on a position in the grid that has for example 4 columns.

#### Helper
We can find on the repository a **"Helper"** folder that will have inside two files (grid.txt/words.txt) that will be useful to test the first way to use the application (By file).

#### UnitTest
The solution has also a Unit Test project called **WordFinder.UT**, that has inside some test to validate the main cases and the possible exceptions that we can get on a bad entry.