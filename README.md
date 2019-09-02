# APLS-Project-school-mini
* I use a 3-tier model for this project. In the solution, there are 2 subprojects
* APLSProjectDomain part is composed of 2 data-tier and business-tier floors
* The APLSProject section contains the Presentation tier
# Set up
### First you need to import the file with the extension .bacpac into the sql server database
* You can follow the steps below:
- Login to SQL SERVER
- Right click on the database and select "Import Data-tier Application ..."
![](https://user-images.githubusercontent.com/54711078/64090332-d4b45800-cd74-11e9-9470-d501ebf3e745.png)
- A window appears then click next
![](https://user-images.githubusercontent.com/54711078/64090371-ff9eac00-cd74-11e9-8306-b9e79fbdeac1.png)
- Click browse and point to the file with .bacpac extension
![](https://user-images.githubusercontent.com/54711078/64090390-1b09b700-cd75-11e9-8861-769c873c261a.png)
-Next, you can change the database name to your liking and then click next
![](https://user-images.githubusercontent.com/54711078/64090391-2230c500-cd75-11e9-8dfc-a1a02a447e01.png)
-Then click Finish and wait for it to import
![](https://user-images.githubusercontent.com/54711078/64090398-28bf3c80-cd75-11e9-922a-89d1bf950c3c.png)
![](https://user-images.githubusercontent.com/54711078/64090401-2bba2d00-cd75-11e9-9d59-3ac1536b742b.png)
-Finally, check the database to see if there is a database we just imported
![](https://user-images.githubusercontent.com/54711078/64090404-2e1c8700-cd75-11e9-8a35-5f5feb89549d.png)

### Next, open the Project.sln file so you should configure the connection string to the newly imported database
