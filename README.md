# LoanApplication

VS version: 2022 17.1.0

How to run:
 - Step 1: Run LoanAppInitDBQuery.sql to create database and tables
 - Step 2: Run LoanAppWebApi project. 
    Uncomment SeedData() part in Program.cs if you want to create sample data. 1000 records for each table will be created. It might take up to 10 seconds.
 - Step 3: Run LoanAppMVC

Database structure:
- Demographic table contains applicant's demographic information.
- Businesses table contains business's information. 
- LoanApp table contains loan application information.
 
Relationships between tables:
- Demographic -> Businesses : 1->M
- Businesses -> LoanApp: 1->M

Because of the 1->M relationships, some applicants might have multiple businesses while some has none. 
Some businesses might have multiple applications while some has none
