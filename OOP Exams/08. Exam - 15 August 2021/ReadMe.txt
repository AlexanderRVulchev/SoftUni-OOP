1.	Overview
In this exam your task will be to create a basic Racing game. In the game there are Map, Racers and Cars. 

2.	Setup
•	Upload only the CarRacing project in every problem except Unit Tests
•	Do not modify the interfaces or their namespaces
•	Use strong cohesion and loose coupling
•	Use inheritance and the provided interfaces wherever possible. 
•	This includes constructors, method parameters and return types
•	Do not violate your interface implementations by adding more public methods or properties in the concrete class than the interface has defined
•	Make sure you have no public fields anywhere

3.	Task 1: Structure (50 points)
Evaluation logic in the methods isn't included for this task.
You are given interfaces, and you have to implement their functionality in the correct classes.
There are 3 types of entities in the application: Car, Racer, Map. There should also be CarRepository and RacerRepository.
Car
Car is a base class of any type of car and it should not be able to be instantiated.
Data
•	Make – string
o	If the make is null or whitespace, throw an ArgumentException with message: "Car make cannot be null or empty."
•	Model – string  
o	If the model is null or whitespace, throw an ArgumentException with message: "Car model cannot be null or empty."
•	VIN – string
o	If the VIN is not exactly 17 characters long, throw an ArgumentException with message: "Car VIN must be exactly 17 characters long."
o	All VINs will be unique
•	HorsePower – int
o	If the horse power is below 0, throw an ArgumentException with message: "Horse power cannot be below 0."
•	FuelAvailable – double
o	If the fuel available drops below 0, just set it to 0
•	FuelConsumtpionPerRace – double
o	If the fuel consumption per race is below 0, throw an ArgumentException with message: "Fuel consumption cannot be below 0."
Behavior
void Drive()
The Drive() method should reduce the fuel available by the fuel consumption per race . Also when driving TunedCar reduces its horse power by 3% every time because of engine wear.  Horse power should be rounded to the closest integer number.
Constructor
A Car should take the following values upon initialization: 
string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace
Child Classes
There are two types of Car:
SuperCar
Constructor should take string make, string model, string VIN and int horsePower upon initialization.
SuperCar always starts with 80 liters available fuel and 10 liters fuel consumption per race.
TunedCar
Constructor should take string make, string model, string VIN and int horsePower upon initialization.
TunedCar always starts with 65 liters available fuel and 7.5 liters fuel consumption per race.
Racer
Racer is a base class for any type of racer and it should not be able to be instantiated.
Data
•	Username - string 
o	If the username is null or whitespace, throw an ArgumentException with message: "Username cannot be null or empty."
o	All usernames are unique
•	RacingBehavior -  string
o	If the racing behavior is null or whitespace, throw an ArgumentException with message: "Racing behavior cannot be null or empty."
•	DrivingExperience -  int
o	If the driving experience is below 0 or over 100, throw an ArgumentException with message: "Racer driving experience must be between 0 and 100."
 
•	Car -  Car
o	If the car is null, throw an ArgumentException with message:
 "Car cannot be null or empty."
Behavior
void Race()
When the Race() method is being called, the Racer's car is beign driven. Also everytime Racer is racing, his driving experience is being increased depending on the racer type. ProfessionalRacer increases his driving experience with 10 everytime he races and StreetRacer increases his driving experience with 5 every time he races. 
bool IsAvailable()
Returns if the Racer is available for a race. Racer is available for a race only if his Car has enough fuel available for completing a race.
Constructor
A Racer should take the following values upon initialization: 
string username, string racingBehavior, int drivingExperience, ICar car
Child Classes
There are two types of Racer:
ProfessionalRacer
Constructor should take the following values upon initialization: 
string username, ICar car
ProfessionalRacer always starts with 30 driving experience and always have "strict" racing behavior.
StreetRacer
Constructor should take the following values upon initialization:
string username, ICar car
StreetRacer always starts with 10 driving experience and always have "aggressive" racing behavior.
Map
Behavior
string StartRace(IRacer racerOne, IRacer racerTwo)
This method calls the two players for a race. When a race is being completed, the both racers should race. If one of the racers is not available for a race, the other one automatically wins the race. If both of the racers are not available for a race method returns a message saying that the race cannot be completed. When Racer race he drives his Car and gains driving experience. Also this method should calculate which one of the racers is the winner. The Racer chance of winning the race depends on his car's horse power, his driving experience and his racing behavior. The chance of winning a race is calculated by the car's horse power multiplied by driving experience multiplied by racing behavior multiplier. If the racing behavior is "strict" the multiplier is 1.2 and if the racing behavior is "aggressive" the multiplier is 1.1. All in all the chance of winning the race is:
•	chanceOfWinning = horsePower * drivingExperience * racingBehaviorMultiplier
Return a string that says which of the racers won:
•	If both of the racers are not available:
o	"Race cannot be completed because both racers are not available!"
•	If one of the racers is not available:
o	"{winnerUsername} wins the race! {lostUsername} was not available to race!" 
•	If both racers are available and the race is completed:
o	"{racerOneUsername} has just raced against {racerTwoUsername}! {winnerUsername} is the winner!"
Note: There will not be a case where both racers have the same chance of winning the race!
CarRepository
The car repository is a repository for all cars in the game.
Data
•	Models - a collection of cars (unmodifiable)
Behavior
void Add(ICar car)
•	If the car is null, throw an ArgumentException with message: "Cannot add null in Car Repository".
•	Adds a car in the collection.
bool Remove(ICar car)
•	Removes a car from the collection. Returns true if the removal was sucessful, otherwise - false.
ICar FindBy(string property)
•	Returns the car with the given VIN, if there is such a car. Otherwise, returns null.
RacerRepository
The racer repository is a repository for all racers in the game.
Data
•	Models - a collection of racers (unmodifiable)
Behavior
void Add(IRacer racer)
•	If the racer is null, throw an ArgumentException with message: "Cannot add null in Racer Repository".
•	Adds a racer in the collection.
bool Remove(IRacer racer)
•	Removes a racer from the collection. Returns true if the removal was sucessful, otherwise - false.
IPlayer FindBy(string property)
•	Returns the first player with the given username, if there is such player. Otherwise, returns null.
Task 2: Business Logic (150 points)
The Controller Class
The business logic of the program should be concentrated around several commands. You are given interfaces, which you have to implement in the correct classes.
Note: The Controller class SHOULD NOT handle exceptions! The tests are designed to expect exceptions, not messages!
The first interface is IController. You must create a Controller class, which implements the interface and all of its methods. The constructor of Controller does not take any arguments. The given methods should have the logic described for each in the Commands section.
Data
You need to keep track of some things, this is why you need some private fields in your controller class:
•	cars - CarRepository 
•	racers – RacerRepository
•	map - IMap
Commands
There are several commands, which control the business logic of the application. They are stated below.
AddCar Command
Parameters
•	type - string
•	make - string
•	model - string
•	VIN - string
•	horsePower - int
Functionality
Adds a Car and adds it to the CarRepository. Valid types are: "SuperCar" and "TunedCar".
If the Car type is invalid, you have to throw an ArgumentException with the following message:
•	"Invalid car type!"
If the Car is added successfully, the method should return the following string:
•	"Successfully added car {carMake} {carModel} ({VIN})."
AddRacer Command
Parameters
•	type - string
•	username - string
•	carVIN - string
Functionality
Creates a Racer of the given type and adds it to the RacerRepository. Valid types are: "ProfessionalRacer" and "StreetRacer". 
If the car is not found throw ArgumentException with message:
•	"Car cannot be found!"
If the racer type is invalid, throw an ArgumentException with message:
•	"Invalid racer type!"
The method should return the following string if the operation is successful:
•	"Successfully added racer {playerUsername}."
BeginRace Command
Parameters
•	racerOneUsername - string
•	racerTwoUsername - string
Functionality
Finds both Racers and they start racing.  It returns the result from StartRace() method.
If one of the racers cannot be found throw ArgumentException with message:
•	"Racer {racerUsername} cannot be found!"
Report Command
Functionality
Returns information about each racer separated with a new line. Order them by driving experience descending, then by username alphabetically. You can use the overridden ToString() Racer method.
"{racer type}: {racer username}"
"--Driving behavior: {racingBehavior}"
"--Driving experience: {drivingExperience}"
"--Car: {carMake} {carModel} ({carVIN})"
Note: Use \r\n or Environment.NewLine for a new line and don't forget to trim the end if you use StringBuilder.
Exit Command
Functionality
Ends the program.
Input / Output
You are provided with one interface, which will help you with the correct execution process of your program. The interface is IEngine and the class implementing this interface should read the input and when the program finishes, this class should print the output.
You are given the Engine class with written logic in it. In order for the code to be compiled, some parts are commented, don't forget to uncomment them. The try-catch block is also commented in order for the program to throw exceptions and for you to see them, uncomment it when you are ready with this too.
Input
Below, you can see the format in which each command will be given in the input:
•	AddCar {type} {make} {model} {VIN} {horsePower}
•	AddRacer {type} {username} {carVIN}
•	BeginRace {racerOneUsername} {racerTwoUsername}
•	Report
•	Exit
Output
Print the output from each command when issued. If an exception is thrown during any of the commands' execution, print the exception message.

4.	Task 3: Unit Tests (100 points)
You will receive a skeleton with Robot and RobotManager classes inside. The class will have some methods, fields and one constructor, which are working properly. You are NOT ALLOWED to change any classes. Cover the whole class with unit tests to make sure that the class is working as intended.
You are provided with a unit test project in the project skeleton.
Do NOT use Mocking in your unit tests!
