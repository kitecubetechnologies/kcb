select countries.id Country_id, countries.shortname AS Country_ShortName, cname Country_Name, 
countries.phonecode ISDCode, States.id as State_id, states.name as State_Name , cities.id as City_id,  cities.name as City_Name from countries
inner join states on states.country_id = countries.id
inner join cities on cities.state_id = states.id