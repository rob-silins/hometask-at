<h1>About this project</h1>

This project was a home task from a position I was applying for.

The requests were as follow:

Every minute, fetch data from https://api.publicapis.org/random?auth=null and store success/failure attempt log in the table and full payload in the blob.
Create a GET API call to list all logs for specific time period (from/to)
Create a GET API call to fetch a payload from blob for specific log entry.

And also I had to use these tools:

• Azure Function (Cloud/Local)
• Azure Storage (Cloud /Local storage emulator)
a. Table
b. Blob

Since I did not want to be associated with an Azure account do to connection strings and such, I made this happen by using <a href="https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator"> Azure Storage Emulator</a>.

Also, just to be sure if my code does actually what it was intended to do, I used <a href="https://azure.microsoft.com/en-us/features/storage-explorer/">Microsoft Azure Storage Explorer</a>.

Also, for the API calls, you can use the browser to check the required data, but I used <a href="https://www.postman.com/"> Postman </a> for it was easier to navigate rather than in a browser.

As for the actual actions and use of the code, it does what the task description asks of it to do. 

When you launch the application, the console will look like this:

![console](https://user-images.githubusercontent.com/54059134/96563991-48902780-12cb-11eb-82d5-8c0a1a872eaf.JPG)

Informing you that the time trigger function is working as it should and also, that there are both API calls available for use.

Also, when you start the application and if you have the <a href="https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator"> Azure Storage Emulator</a> installed, it should start automatically.

When you open the <a href="https://azure.microsoft.com/en-us/features/storage-explorer/">Microsoft Azure Storage Explorer</a> blob containers, you will see that there are blob files storing every minute:

![blob](https://user-images.githubusercontent.com/54059134/96565642-4fb83500-12cd-11eb-9d39-23f8630253cf.JPG)

When you check the table, you will see that it is updating every minute as well:

![table](https://user-images.githubusercontent.com/54059134/96565808-84c48780-12cd-11eb-8717-88f523988373.JPG)

Now that there are files being saved on the local storage emulator, we can check some API GET calls. For this I'm using postman, because it saves previous calls and there is no need to retype a different request. Let's start with a blob GET call: 

![getblob](https://user-images.githubusercontent.com/54059134/96568547-bab73b00-12d0-11eb-879e-98ed9a47136e.JPG)

It returns the blob of the specified name/date.
In case of an empty string, wrong data format and non existing data, it will return a corresponding message.

An the table:

![gettable](https://user-images.githubusercontent.com/54059134/96568724-ef2af700-12d0-11eb-8bb6-64405bad9b50.JPG)

It returns the range of the log dates that you entered.
In case of an empty string, wrong data format and non existing data, it will return a corresponding message.
Also, if you enter a wide range, lets say from year 1900 - 2100, it will just return every record in between those dates.

Thank you for checking this out!

