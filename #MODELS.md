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
| ImageUrl	   | varchar(40)	| YES	|     |	NULL	| 		|
| Country_Code | char(3)		| NO	| FK  |			| 		|


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
| ImageUrl	   	 | varchar(40)	| YES	|     |	NULL	| 		|
| Country_code   | char(3)		| NO	| FK  |			| 		|
| Driver1_id 	 | int(11)		| NO	| FK  |			| 		|
| Driver2_id 	 | int(11)		| NO	| FK  |			| 		|


## Circuit

Table: Circuits

Definition:
| field      	 | type         | null? | key | default | extra |
|----------------|--------------|-------|-----|---------|-------|
| Id		 	 | int(11)		| NO	| PK  |			| AI	|
| Name		 	 | varchar(40)	| NO	|     |			| 		|
| Length	 	 | int(10)		| NO	|     |			| 		|
| RecordLap		 | int(10)		| YES	|     |	NULL	| 		|
| Location	 	 | varchar(80)	| NO	|     |			| 		|
| ImageUrl	     | varchar(40)	| YES	|     |	NULL	| 		|
| Country_Code   | char(3)		| NO	| FK  |			| 		|


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



## Result

Table: Results

Definition:
| field      	 | type         | null? | key | default | extra |
|----------------|--------------|-------|-----|---------|-------|
| Id		 	 | int(11)		| NO	| PK  |			| AI	|
| Position	 	 | int(10)		| NO	|     |			| 		|
| Score		 	 | int(10)		| NO	|     |			| 		|
| FastestLap 	 | int(10)		| NO	|     |			| 		|
| Driver_Id 	 | int(11)		| NO	| FK  |			| 		|
| Race_Id 	 	 | int(11)		| NO	| FK  |			| 		|
