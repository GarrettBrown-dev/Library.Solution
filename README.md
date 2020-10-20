# _Local Library's Listy Log_

#### _An app to keep track of the library's transactions of all sorts. Created 10/19/2020_

#### By _**Garrett Dean Brown** , **Jeff Dinsmore**_ & **William Donovan-Sied**

## Description

_A website specially made for our unnamed local library to help log the books checked out as well as allow the user to create a profile and log the books they've checked out and need to check back in._

##User Stories

- As a librarian, I want to create, read, update, delete, and list books in the catalog, so that we can keep track of our inventory.

- As a librarian, I want to search for a book by author or title, so that I can find a book when there are a lot of books in the library.

- As a librarian, I want to enter multiple authors for a book, so that I can include accurate information in my catalog. (Hint: make an authors table and a books table with a many-to-many relationship.)

- As a patron, I want to check a book out, so that I can take it home with me.

- As a patron, I want to know how many copies of a book are on the shelf, so that I can see if any are available. (Hint: make a copies table; a book should have many copies.)

- As a patron, I want to see a history of all the books I checked out, so that I can look up the name of that awesome sci-fi novel I read three years ago. (Hint: make a checkouts table that is a join table between patrons and copies.)

- As a patron, I want to know when a book I checked out is due, so that I know when to return it.

- As a librarian, I want to see a list of overdue books, so that I can call up the patron who checked them out and tell them to bring them back - OR ELSE!


## Book Object Properties
* Id
* Name
* Author
--------

## Catalog Object Properties
* Id
* Name
* Book Count

### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
|  1. Site has a splash page with for the library | dotnet run  |  Splash Page |
|  2. User should be able to enter a new Profile | user clicks "New User" | User now has a profile in the database |
|  3. User should be able to view previous checkouts, current checkouts, and book counts.| user clicks "Catalog" | "A list of books in the library." | 

## Setup/Installation Requirements

* Database setup instructions:
  * Ensure Garrett_Brown.sql was downloaded
  * Create an appsettings.json file
  * add localhost port, database name (garrett_brown) and your mysql password. 
  * Run dotnet restore and dotnet build.
  * Dotnet run and navigate to your localhost, and enjoy!

* Download option
  * Download files from GitHub repository by click Code and Download Zip
  * Extract files into a single directory 
  * Run GitBASH in directory
  * Type "dotnet run" in GitBash to run the program
  * Enjoy!

* Cloning options
  * For cloning please use the following GitHub [tutorial](https://docs.github.com/en/enterprise/2.16/user/github/creating-cloning-and-archiving-repositories/cloning-a-repository)
  * Place files into a single directory 
  * Run GitBASH in directory
  * Type "dotnet run" in GitBash to run the program

## Known Bugs

_No known bugs!_

## Support and contact details

_Feel free to email me with any questions, comments, or reports!: gman9mm@live.com_

## Technologies Used

* C#
* cshtml
* CSS
* MySQL
* Entity
* Linq
* MVCTest
* MarkDown

### License

_Copyright (c) 2020 **_{Garrett Brown}_** , **_{Jeff Dinsmore}_** & **_{William Donovan-Sied}_**
_Licensed under MIT_

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.