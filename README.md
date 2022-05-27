# Support Wheel Of Fate

The application is made up of a React front-end communicating with a simple API that performs the following functions
- Returns previously held engineer names
- Generates and persists a randomized two week rota

## To execute

1. Open a terminal to the web project and navigate to `.\ClientApp\` directory
2. Execute `npm install` to install the dependencies
3. <kbd>F5</kbd> to run the application.

## Process

Each of the engineers sent to API service get added to a `Dictionary<Guid, Engineer>` collection.  Due to the random nature of the GUID when calling the `Sort` method will randomize the collection.

The collection object is then stored in the fake repository and returned to the React app.

The React app then pushes each of the returned names into the week planner and is then displayed twice.

### This table shows the allocation process
| Day       | Position in dataset | Position in dataset |
|-----------|---------------------|---------------------|
| Monday    | 1                   | 2                   |
| Tuesday   | 3                   | 4                   |
| Wednesday | 5                   | 6                   |
| Thursday  | 7                   | 8                   |
| Friday    | 9                   | 10                  |
| Monday    | 1                   | 2                   |
| Tuesday   | 3                   | 4                   |
| Wednesday | 5                   | 6                   |
| Thursday  | 7                   | 8                   |
| Friday    | 9                   | 10                  |

If you're in position 1 of the returned dataset then you get allocated to Monday AM slot

## Trade offs

1. The application is designed for 10 engineers, any more will mean some may not be allocated a shift, any less and gaps will appear in the schedule.
2. Week one is repeated into week two, this meets the requirements without complicated logic.

## Deployment
This application can be hosted using Azure Static Websites and API requests proxied to an Azure Website host.