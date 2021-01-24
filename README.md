This project aims to utilize a Domain Driven Design (DDD) approach or Clean Architecture in the following ways: 

# SummerveldHoundResort.Application 
- The application level logic aims to hold logic that can't fit in the domain level. 
- This would promote decoupling in the application 

# SummerveldHoundResort.Domain 
- The domain level logic aims to hold logic specific to Summerveld Hound Resort. 
- Only Domain model classes would live here. 
- This layer wont reference any other projects & packages and all calls will be done through the application layer.

# SummerveldHoundResort.Infrastructure 
- The infrastructure layer aims to hold code that would access the mySQL database using Dapper.
- The application layer would access this infrastructure layer and pass the data to the domain layer.

# SummerveldHoundResort.WebAPI 
- The Web API layer aims to only contain code that is specific to the API. 
- The application and infrastructure layer would pass data to this layer.