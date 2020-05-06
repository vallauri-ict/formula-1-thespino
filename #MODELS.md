# Models

Here listed the models of tables in DB

The complete diagram can be found here: [https://dbdiagram.io/d/5eb2dce339d18f5553fecad1](https://dbdiagram.io/d/5eb2dce339d18f5553fecad1)


## Country

Table: countries
Definition:
| field       | type        | null? | key | default | extra |
|-------------|-------------|-------|-----|---------|-------|
| code		  | char(3)		| NO	| PK  |			| 		|
| name		  | varchar(40)	| NO	|     |			| 		|
| nationality | varchar(40)	| NO	|     |			| 		|


## Driver

Table: drivers
Definition:
| field        | type           | null? | key | default | extra |
|--------------|----------------|-------|-----|---------|-------|
| id		   | int(11)		| NO	| PK  |			| AI	|
| firstname	   | varchar(40)	| NO	|     |			| 		|
| lasttname	   | varchar(40)	| NO	|     |			| 		|
| dob		   | date			| NO	|     |			| 		|
| pob		   | varchar(40)	| NO	|     |			| 		|
| country_code | char(3)		| NO	| FK  |			| 		|
Additional attributes:
| field   | returns   |
|---------|-----------|
| country | Country	  |
| teams   | Team[]	  |


## Team

Table: teams
Definition:
| field      	 | type         | null? | key | default | extra |
|----------------|--------------|-------|-----|---------|-------|
| id		 	 | int(11)		| NO	| PK  |			| AI	|
| name		 	 | varchar(40)	| NO	|     |			| 		|
| fullname	 	 | varchar(80)	| NO	|     |			| 		|
| powerunit	 	 | varchar(40)	| NO	|     |			| 		|
| technicalchief | varchar(40)	| NO	|     |			| 		|
| chassis	 	 | varchar(40)	| NO	|     |			| 		|
| country_code   | char(3)		| NO	| FK  |			| 		|
| driver1_id 	 | int(11)		| NO	| FK  |			| 		|
| driver2_id 	 | int(11)		| NO	| FK  |			| 		|
Additional attributes:
| field   | returns   |
|---------|-----------|
| country | Country   |
| driver1 | Driver    |
| driver2 | Driver    |


## Circuit

Table: circuits
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

Table: races
Definition:
| field      	 | type         | null? | key | default | extra |
|----------------|--------------|-------|-----|---------|-------|
| id		 	 | int(11)		| NO	| PK  |			| AI	|
| name		 	 | varchar(40)	| NO	|     |			| 		|
| laps		 	 | int(10)		| YES	|     |	NULL	| 		|
| date			 | date			| YES	|     |	NULL	| 		|
| circuit_id     | int(11)		| YES   | FK  | NULL	| 		|
Additional attributes:
| field   | returns     |
|---------|-------------|
| circuit | Circuit     |
| scores  | RaceScore[] |


## Score

Table: scores
Definition:
| field      	 | type         | null? | key | default | extra |
|----------------|--------------|-------|-----|---------|-------|
| id		 	 | int(11)		| NO	| PK  |			| AI	|
| score		 	 | int(10)		| NO	|     |			| 		|
| details	 	 | varchar(500)	| NO	|     |	""		| 		|



## [Pivot] RaceScore

Table: races_scores
Definition:
| field      	 | type         | null? | key | default | extra |
|----------------|--------------|-------|-----|---------|-------|
| id		 	 | int(11)		| NO	| PK  |			| AI	|
| position	 	 | int(10)		| NO	|     |			| 		|
| fastestlap 	 | int(10)		| YES	|     |	NULL	| 		|
| driver_id 	 | int(11)		| NO	| FK  |			| 		|
| score_id 	 	 | int(11)		| NO	| FK  |			| 		|
| race_id 	 	 | int(11)		| NO	| FK  |			| 		|
Additional attributes:
| field   | returns   |
|---------|-----------|
| driver  | Driver    |
| score   | Score     |
| race    | Race      |
