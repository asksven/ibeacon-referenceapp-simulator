# ibeacon-referenceapp-simulator
A command-line simulator to generate traffic to the backend

This is a command line app to simulate the flow of customers in a store:
- a store is composed of n departments
- each department has a queue
- a customer has a shopping list
- customers from the population enter the store in groups
- a customer goes from department to department, following the order of items from his shopping list
- when a customer enters a department he stays in the queue until he gets his article. He then puts the article into his shopping cart and goes to the next department
- the queues in each departments have glitches that disturb the customer flow, causing stalling in the waiting lines

The parameters of the simulation are located in `Constants`.

The simulation runs as long as there are customers left in the population and in the store.
