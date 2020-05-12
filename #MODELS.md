# Models

Here listed the models of tables in DB

The complete diagram can be found here: [https://dbdiagram.io/d/5eb2dce339d18f5553fecad1](https://dbdiagram.io/d/5eb2dce339d18f5553fecad1)


## Country

Table: Countries
Definition:
| field       | type        | null? | key | default | extra |
|-------------|-------------|-------|-----|---------|-------|
| Code		  | char(3)		| NO	| PK  |			| 		|
| Name		  | varchar(40)	| NO	|     |			| 		|
| Nationality | varchar(40)	| NO	|     |			| 		|


## Driver

Table: Drivers
Definition:
| field        | type           | null? | key | default | extra |
|--------------|----------------|-------|-----|---------|-------|
| Id		   | int(11)		| NO	| PK  |			| AI	|
| Firstname	   | varchar(40)	| NO	|     |			| 		|
| Lasttname	   | varchar(40)	| NO	|     |			| 		|
| Dob		   | date			| NO	|     |			| 		|
| Pob		   | varchar(40)	| NO	|     |			| 		|
| Country_Code | char(3)		| NO	| FK  |			| 		|

Additional attributes:

| field   | returns   |
|---------|-----------|
| Country | Country	  |
| Teams   | Team[]	  |


## Team

Table: Teams
Definition:
| field      	 | type         | null? | key | default | extra |
|----------------|--------------|-------|-----|---------|-------|
| Id		 	 | int(11)		| NO	| PK  |			| AI	|
| Name		 	 | varchar(40)	| NO	|     |			| 		|
| FullName	 	 | varchar(80)	| NO	|     |			| 		|
| PowerUnit	 	 | varchar(40)	| NO	|     |			| 		|
| TechnicalChief | varchar(40)	| NO	|     |			| 		|
| Chassis	 	 | varchar(40)	| NO	|     |			| 		|
| Country_code   | char(3)		| NO	| FK  |			| 		|
| Driver1_id 	 | int(11)		| NO	| FK  |			| 		|
| Driver2_id 	 | int(11)		| NO	| FK  |			| 		|

Additional attributes:

| field   | returns   |
|---------|-----------|
| Country | Country   |
| Driver1 | Driver    |
| Driver2 | Driver    |


## Circuit

Table: Circuits
Definition:
| field      	 | type         | null? | key | default | extra |
|----------------|--------------|-------|-----|---------|-------|
| id		 	 | int(11)		| NO	| PK  |			| AI	|
| name		 	 | varchar(40)	| NO	|     |			| 		|
| length	 	 | int(10)		| NO	|     |			| 		|
| recordlap		 | int(10)		| YES	|     |	NULL	| 		|
| location	 	 | varchar(80)	| NO	|     |			| 		|
| country_code   | char(3)		| NO	| FK  |			| 		|

Additional attributes:

| field   | returns   |
|---------|-----------|
| country | Country   |
| reces   | Race[]    |


## Race

Table: Races
Definition:
| field      	 | type         | null? | key | default | extra |
|----------------|--------------|-------|-----|---------|-------|
| Id		 	 | int(11)		| NO	| PK  |			| AI	|
| Name		 	 | varchar(40)	| NO	|     |			| 		|
| Laps		 	 | int(10)		| YES	|     |	NULL	| 		|
| Date			 | date			| YES	|     |	NULL	| 		|
| Circuit_Id     | int(11)		| YES   | FK  | NULL	| 		|

Additional attributes:

| field   | returns     |
|---------|-------------|
| Circuit | Circuit     |
| Scores  | RaceScore[] |


## Score

Table: Scores
Definition:
| field      	 | type         | null? | key | default | extra |
|----------------|--------------|-------|-----|---------|-------|
| Id		 	 | int(11)		| NO	| PK  |			| AI	|
| Score		 	 | int(10)		| NO	|     |			| 		|
| Details	 	 | varchar(500)	| NO	|     |	""		| 		|



## [Pivot] RaceScore

Table: Races_Scores
Definition:
| field      	 | type         | null? | key | default | extra |
|----------------|--------------|-------|-----|---------|-------|
| Id		 	 | int(11)		| NO	| PK  |			| AI	|
| Position	 	 | int(10)		| NO	|     |			| 		|
| FastestLap 	 | int(10)		| YES	|     |	NULL	| 		|
| Driver_Id 	 | int(11)		| NO	| FK  |			| 		|
| Score_Id 	 	 | int(11)		| NO	| FK  |			| 		|
| Race_Id 	 	 | int(11)		| NO	| FK  |			| 		|

Additional attributes:

| field   | returns   |
|---------|-----------|
| Driver  | Driver    |
| Score   | Score     |
| Race    | Race      |
