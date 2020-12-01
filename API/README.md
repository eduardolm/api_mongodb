# API and MongoDB
## Objective
Create a C# API using Atlas MongoDB cloud server.
## Technologies
 + Mongo Atlas
 + C#
 + .NET Core 3.1.4
 + Github
## How to Use
In order to test this API, the following requirements must be met:
 + .NET Core 3.1.4 SDK
 + Mongo Atlas account

Attention!: This API is using dotnet user-secrets to store both username and password to access Mongo Atlas database.
Stored variables in dotnet user-secrets are:
dbUsername = <username>
dbPassword = <password>

The API accepts GET, POST, PUT and DELETE methods

## Endpoints
**Action** | **Endpoint** | **Method**
---------- | ------------ | ----------
Insert data | _/infected_ | POST
List data | _/infected_ | GET
Update gender | _/infected_ | PUT
Delete data | _/infected/{birthday}_ | DELETE

## Payload Layout
In this section, we can check both payload and responses for the various accepted HTTP methods:

#### POST - Request
    {
        "Birthday": "1990-03-01",
        "Gender": "M",
        "Latitude": -23.5630994,
        "Longitude": -46.6565712
    }

#### GET - Reponse
    [
        {
            "birthday": "1990-03-01T03:00:00Z",
            "gender": "M",
            "locale": {
                "values": [
                    -46.6565712,
                    -23.5630994
                ],
                "longitude": -46.6565712,
                "latitude": -23.5630994
            }
        },
        {
            "birthday": "1970-03-01T03:00:00Z",
            "gender": "F",
            "locale": {
                "values": [
                    -48.1836042,
                    -21.7994511
                ],
                "longitude": -48.1836042,
                "latitude": -21.7994511
            }
        },
        {
            "birthday": "1940-03-01T03:00:00Z",
            "gender": "M",
            "locale": {
                "values": [
                    -48.1836042,
                    -21.7994511
                ],
                "longitude": -48.1836042,
                "latitude": -21.7994511
            }
        }
    ]

#### PUT - Request
    {
        "Birthday": "1930-03-01",
        "Gender": "F",
        "Latitude": -21.7994511,
        "Longitude": -48.1836042
    }


