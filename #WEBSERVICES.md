# WebServices

Here listed all webservices with the relative return Model.
Every model, of cource, can have additional fields in addition of the ones in the DB, like an instance of an element referenced in a foreign key or additional fields with computed statistics/values.

## NOTES

- The prefix for all routes is `/api/`
- Any route that returns an Array should have pagination, so additional (but optional) query parameters might be: `page(\d)&limit(\d)`
- Another parameter for Array routes is `query` which means that the server will return only the count that match that query. It can search in the name but even in other fields. Each route can define more specific query types, but in general this is a good practise
- To prevent recursion, each additional attribute in models should be a method or a property that returns the instance of a specific object ONLY IF CALLED, and computed at the first interaction, otherwise loops can create. **Do not instanciate relational attributes in constructor**. Here you can see routes "Races" and "Scores" that will create a loop due to the Models structure



## Countries

### GET countries
Returns list of all countries

    {
	    Page: 1,
	    Pages: 5,
	    Limit: 15,
	    Count: 15,
	    Data: [
		    { Country },
		    { Country },
	    ]
    }

### GET countries/{code ({2})}
Returns specific country

    { Country }



## Drivers

### GET drivers
Returns list of all drivers

    {
	    Page: 1,
	    Pages: 5,
	    Limit: 15,
	    Count: 15,
	    Data: [
		    { Driver },
		    { Driver },
	    ]
    }

### GET drivers/{id (\d)}
Returns specific driver

    { Driver }



## Teams

### GET teams
Returns list of all teams

    {
	    Page: 1,
	    Pages: 5,
	    Limit: 15,
	    Count: 15,
	    Data: [
		    { Team },
		    { Team },
	    ]
    }

### GET teams/{id (\d)}
Returns specific team

    { Team }



## Circuits

### GET circuits
Returns list of all circuits

    {
	    Page: 1,
	    Pages: 5,
	    Limit: 15,
	    Count: 15,
	    Data: [
		    { Circuit },
		    { Circuit },
	    ]
    }

### GET circuits/{id (\d)}
Returns specific circuit

    { Circuit }



## Races

### GET races?date_start(date)&date_end(date)
Returns list of all races, eventually filtered between dates if specified

    {
	    Page: 1,
	    Pages: 5,
	    Limit: 15,
	    Count: 15,
	    Data: [
		    { Race },
		    { Race },
	    ]
    }

### GET races/{id (\d)}
Returns specific race

    { Race }



## Results

### GET results
Returns list of all results

    {
	    Page: 1,
	    Pages: 5,
	    Limit: 15,
	    Count: 15,
	    Data: [
		    { Result },
		    { Result },
	    ]
    }

### GET results/{id (\d)}
Returns specific result

    { Result }

### GET results/of-race/{id (\d)}
Returns all results of specific race

    [
		{ Result },
		{ Result },
	]