# LoanApplication

VS version: 2022 17.1.0

Database structure:
- Demographic table contains applicant's demographic information.
- Businesses table contains business's information. 
- LoanApp table contains loan application information.
 
Relationships between tables:
- Demographic -> Businesses : 1->M
- Businesses -> LoanApp: 1->M

On startup, 1000 random records for each table will be created. 
Because of the 1->M relationships, some applicants might have multiple businesses while some has none. The same for business and loan applications.
