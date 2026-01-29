# Software Design
* https://stackoverflow.com/questions/704855/software-design-vs-software-architecture

## Backend
* Endpoints:
  * Create Game
    * Receive the selected filters (could be none) from the frontend, and return a collection of Kanas.

## Frontend Components
* Layout
* Game menu
  * It will call the api to send the filter selection to the backend.
* Game
  * Start the game based on the api response, if endless, reshuffle the collection when the last one ends.
  * Fill the options with the correct Kana together with other Kanas that are also present in the collection.
* Cards
* Finish Game