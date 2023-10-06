# azure-resume
My own azure resume, following 
[ACG project video](https://www.youtube.com/watch?v=ieYrBWmkfno), [Git and GitHub for Beginners - Crash Course youtube videos](https://www.youtube.com/watch?v=RGOj5yH7evk), [Git: branches in Visual Studio Code](https://www.youtube.com/watch?v=b9LTz6joMf8).

## Pre-requisites
```
Azure Account  
.Net Core 3.1 SDK if not available use `.NET Core 6`  
Azure Functions Core Tools  
Visual Studio Code  
Azure CLI  
C# Extension  
Github Account
```
## **First section: Build the frontend**  
![Alt text](frontend/images/Build-frontend.png)

**1.** Set up our version control 
###### *Created a GitHub Repository, cloned the starter code and tried my best to understand the project structure before tackling this first step.* 
**2.** Update the HTML and implement `counter`  
###### *This is where I updated the HTML with my resume info and wrote the JavaScript code for the visitor counter.*
**3.** Test locally and push changes to GitHub  
###### *Viewed the website locally before pushing all the changes to GitHub.*



#### First step

- Frontend folder contains website. 
- main.js contains visitor counter code.


## **Second section: Build the backend**  

![Alt text](frontend/images/Build-backend.png)

**1.** Set up our Cosmos DB resources 
###### *Create a Cosmos DB account, database, and container, and data.* 
**2.** Set up an Azure Function  
###### *Create an Azure Function to interact with the Cosmos DB counter data.*
**3.** Test locally  
###### *At this point, test our Function locally to make sure the counter data can be viewed in a browser and in the website locally.*

