Overview
It’s that time of the year again and the annual Easter races are about to begin. You love to race with your car and you are the biggest fan of the Easter races and for that reason, the Easter races federation hired you to create platform for storing information about drivers, cars and races.
Setup
•	Upload only the EasterRaces package in every problem except Unit Tests
•	Do not modify the classes, interfaces or their packages
•	Use strong cohesion and loose coupling
•	Use inheritance and the provided interfaces wherever possible
•	This includes constructors, method parameters and return types
•	Do not violate your interface implementations by adding more public methods in the concrete class than the interface has defined
•	Make sure you have no public fields anywhere

Task 1: Structure (50 Points)
You are given 8 interfaces, and you have to implement their functionality in the correct classes.
It is not required to implement your structure with Engine, CommandHandler, ConsoleReader, ConsoleWriter and enc. It's good practice but it's not required.
There are 3 types of entities and 3 repositories in the application: Car, Driver, Race and a Repository for each of them:
Car
Car is a base class for any type of Car and it should not be able to be instantiated.
Data
•	Model - string
o	If the model is null, whitespace or less than 4 symbols, throw an ArgumentException with message "Model {model} cannot be less than 4 symbols."
o	All models are unique
•	HorsePower - int
o	Every type of car has different range of valid horsepower. If the horsepower is not in the valid range, throw an ArgumentException with message "Invalid horse power: {horsepower}."
•	CubicCentimeters - double 
o	Every type of car has different cubic centimeters.
Behavior
Double CalculateRacePoints(int Laps)
The CalculateRacePoints calculates the race points in the concrete Race with this formula:
cubic centimeters / horsepower * laps
Constructor
A Car should take the following values upon initialization:
string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower
Child Classes
There are several concrete types of Cars:
MuscleCar
The cubic centimeters for this type of car are 5000. Minimum horsepower is 400 and maximum horsepower is 600.
If you receive horsepower which is not in the given range throw ArgumentException with message "Invalid horse power: {horsepower}.".
SportsCar
The cubic centimeters for this type of car are 3000. Minimum horsepower is 250 and maximum horsepower is 450.
If you receive horsepower which is not in the given range throw ArgumentException with message "Invalid horse power: {horsepower}.".
Driver
Data
•	Name - string
o	If the name is null, empty or less than 5 symbols throw an ArgumentException with message "Name {name} cannot be less than 5 symbols."
o	All names are unique
•	Car - ICar
•	NumberOfWins - int
•	CanParticipate - bool 
o	Default behaviour is false
o	Driver can participate in race, ONLY if he has a Car (Car is not null)
Behavior
Void AddCar(Car Car)
This method adds a Car to the Driver. If the car is null, throw ArgumentNullException with message "Car cannot be null.".
If the given Car is not null, set the current Car as the given one and after that Driver can participate to race.
Void WinRace()
When the Driver wins a Race, the number of wins should be increased.
Constructor
A Driver should take the following values upon initialization:
string name
Race
Data
•	Name - string
o	If the name is null, empty or less than 5 symbols throw an ArgumentException with message "Name {name} cannot be less than 5 symbols."
o	All names are unique
•	Laps - int 
o	Throws ArgumentException with message "Laps cannot be less than 1.", if the laps are less than 1.
•	Drivers - A collection of IDriver
Behavior
Void AddDriver(Driver Driver)
This method adds a Driver to the Race if the Driver is valid. If the Driver is not valid, throw an Exception with the appropriate message.
Exceptions are:
•	If a Driver is null throw an ArgumentNullException with message "Driver cannot be null."
•	If a Driver cannot participate in the Race (the Driver doesn't own a Car) throw an ArgumentException with message "Driver {driver name} could not participate in race."
•	If the Driver already exists in the Race throw an ArgumentNullException with message:
"Driver {driver name} is already added in {race name} race."
Constructor
A Race should take the following values upon initialization:
string name
int laps

Repository
The repository holds information about the entity.
Data
•	Models - A collection of T (entity)
Behavior
void Add(T model)
Adds an entity in the collection.
bool Remove(T model)
Removes an entity from the collection.
T GetByName(string name)
Returns an entity with that name.
Collection<T> GetAll()
Returns all entities (unmodifiable)
Child Classes
Create CarRepository, DriverRepository and RaceRepository repositories.

Task 2: Business Logic (150 Points)
The Controller Class
The business logic of the program should be concentrated around several commands. You are given interfaces, which you have to implement in the correct classes.
Note: The ChampionshipController class SHOULD NOT handle exceptions! The tests are designed to expect exceptions, not messages!
Note: The ChampionshipController class SHOULD HAVE empty constructor!
The first interface is IChampionshipController. You must implement a ChampionshipController class, which implements the interface and implements all of its methods. The given methods should have the following logic:
Commands
There are several commands, which control the business logic of the application. They are stated below.
CreateDriver Command
Parameters
•	driverName - string
Functionality
Creates a Driver with the given name and adds it to the appropriate repository.
The method should return the following message:
"Driver {name} is created."
If a driver with the given name already exists in the driver repository, throw an ArgumentException with message 
"Driver {name} is already created."
CreateCar Command
Parameters
•	type - string
•	model - string
•	horsePower - int
Functionality
Create a Car with the provided model and horsepower and add it to the repository. There are two types of Car: "Muscle" and "Sports".
If the Car already exists in the appropriate repository throw an ArgumentException with following message:
"Car {model} is already created."
If the Car is successfully created, the method should return the following message:
"{"MuscleCar"/ "SportsCar"} {model} is created."
AddCarToDriver Command
Parameters
•	driverName - String
•	carModel - String
Functionality
Gives the Car with given name to the Driver with given name (if exists).
If the Driver does not exist in the DriverRepository, throw InvalidOperationException with message 
•	"Driver {name} could not be found."
If the Car does not exist in the CarRepository, throw InvalidOperationException with message 
•	"Car {name} could not be found."
If everything is successful you should add the Car to the Driver and return the following message:
•	"Driver {driver name} received car {car name}."
AddDriverToRace Command
Parameters
•	raceName - string
•	driverName - string
Functionality
Adds a Driver to the Race.
If the Race does not exist in the RaceRepository, throw an InvalidOperationException with message:
•	"Race {name} could not be found."
If the Driver does not exist in the DriverRepository, throw an InvalidOperationException with message:
•	"Driver {name} could not be found."
If everything is successful, you should add the Driver to the Race and return the following message:
•	"Driver {driver name} added in {race name} race."
CreateRace Command
Parameters
•	name - string
•	laps - int
Functionality
Creates a Race with the given name and laps and adds it to the RaceRepository.
If the Race with the given name already exists, throw an InvalidOperationException with message:
•	"Race {name} is already create."
If everything is successful you should return the following message:
•	"Race {name} is created."
StartRace Command
Parameters
•	raceName - string
Functionality
This method is the big deal. If everything is valid, you should arrange all Drivers and then return the three fastest Drivers. To do this you should sort all Drivers in descending order by the result of CalculateRacePoints method in the Car object. At the end, if everything is valid remove this Race from the race repository.
If the Race does not exist in RaceRepository, throw an InvalidOperationException with message:
•	"Race {name} could not be found."
If the participants in the race are less than 3, throw an InvalidOperationException with message:
•	"Race {race name} cannot start with less than 3 participants."
If everything is successful, you should return the following message:
•	"Driver {first driver name} wins {race name} race."
"Driver {second driver name} is second in {race name} race."
"Driver {third driver name} is third in {race name} race."
End Command
Exit the program.
Input / Output
You are provided with one interface, which will help with the correct execution process of your program. The interface is IEngine and the class implementing this interface should read the input and when the program finishes, this class should print the output.
Input
Below, you can see the format in which each command will be given in the input:
•	CreateDriver {name}
•	CreateCar {car type} {model} {horsepower}
•	AddCarToDriver {driver name} {car name}
•	AddDriverToRace {race name} {driver name}
•	CreateRace {name} {laps}
•	StartRace {race name}
•	End
Output
Print the output from each command when issued. If an exception is thrown during any of the commands' execution, print the exception message.


Task 3: Unit Tests (100 Points)
You will receive a skeleton with RaceEntry, UnitCar and UnitDriver classes inside. The class will have some methods, properties, fields and one constructor, which are working properly. You are NOT ALLOWED to change any class. Cover the whole class (RaceEntry) with unit tests to make sure that the class is working as intended. 
You are provided with a unit test project in the project skeleton. DO NOT modify its NuGet packages.
Do NOT use Mocking in your unit tests!

