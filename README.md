# PatientsEvidence

Backend: 
- implemented onion architecture proposal:
  - application core
  - repositories filling core entities with data
    - data are stored in XML, XML structure is defined and validated by XML Schema document
  - bussiness logic getting data from repositories and doing manipulation on data
- implemented in c#

Frontend
- main approach
  - .netcore MVC application 
  - jquery DataTables plugin for Table manipulation and appearance
- second approach
  - AngularJS 
    - for learning purposes only, i have never really worked with Angular before
    - might require dependencies installation (nodeJS e.g.) to run application
