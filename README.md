# Stocks Client

<p align="center">
<img src="https://img.shields.io/badge/C%23--brightgreen.svg" style="max-height: 300px;"></a>
<img src="https://img.shields.io/badge/Platform-.NET Forms-lightgrey.svg" style="max-height: 300px;" alt="Platform: Windows">
</p>

## About

This client displays the current stocks and auto-refreshes when stock is purchased or sold, various error handling is in 
place as to not allow a user to sell stocks they don't own etc. The client also supports multiple users as you 
can logout and sign in as a different user. As this was just a University project i decided that a password wasn't 
required and a new user could be created simply by created by entering a new username.

## Features

* Buy and sell stock from a database
* Supports multiple clients
* Shows order history

## Possible to do list 

* Remove the message box pop-ups to allow for correct use of multi-threading
* Handling sudden server connection loss

## How to use

**Note: This program can only be used when the matching server is running and is bound to the correct ip**

* Start client and enter server ip address found by command prompt after server is running.
* Select stock you wish to sell or purchase and hit the buy or sell button respectively.
* Order history is avaliable after purchasing an item.

## Installation

Download/Clone the repo and grab the debug/bin folder, as long as you have all of the files within this folder 
double click the the .exe to run the program. However feel free to fork/clone this repo or build the program for 
yourself instead of using the bin folder.

## Issues

If you come across any issues while using this program or have any suggestions, feel free to create an 
issue with as much information as you can.

## Dependencies

* The matching stock server avaliable on this ([github](https://github.com/Jstanford5216/Stocks_Server))

## License

This project is available under the MIT license. See the LICENSE file for more info.

