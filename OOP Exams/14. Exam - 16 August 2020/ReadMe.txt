In this exam, you need to build an online shop project, which has peripherals, components, and computers. The project will consist of model classes and a controller class, which manages the interaction between the peripherals, components, and computers.

1.	Setup
•	Upload only the OnlineShop project in every problem except Unit Tests
•	Do not modify the interfaces or their namespaces
•	Use strong cohesion and loose coupling
•	Use inheritance and the provided interfaces wherever possible. 
•	This includes constructors, method parameters and return types
•	Do not violate your interface implementations by adding more public methods or properties in the specific class than the interface has defined
•	Make sure you have no public fields anywhere
 Task 1: Structure (50 Points)
For this task's evaluation, logic, in the methods, isn't included.
You are given interfaces and you have to implement their functionality in the correct classes.
There are 4 types of entities in the application: Product, Component, Peripheral, Computer.
Product
The Product is a base class for components, peripherals and computers and it should not be able to be instantiated.
Data
•	Id – int (cannot be less than or equal to 0. In that case, throw ArgumentException with message "Id can not be less or equal than 0.")
•	Manufacturer – string (cannot be null or whitespace. In that case, throw ArgumentException with message "Manufacturer can not be empty.")
•	Model – string (cannot be null or whitespace. In that case, throw ArgumentException with message "Model can not be empty.")
•	Price – decimal (cannot be less than or equal to 0. In that case, throw ArgumentException with message "Price can not be less or equal than 0.")
•	OverallPerformance – double (cannot be less than or equal to 0. In that case, throw ArgumentException with message "Overall Performance can not be less or equal than 0.")
Constructor
A product should take the following values upon initialization:
int id, string manufacturer, string model, decimal price, double overallPerformance
 
Override ToString() method:
"Overall Performance: {overall performance}. Price: {price} - {product type}: {manufacturer} {model} (Id: {id})"
Child Classes
There are several concrete types of products:
•	Component
•	Peripheral
•	Computer

Component
The Component is a derived class from Product and a base class for any components and it should not be able to be instantiated.
Data
•	Generation – int
Constructor
A product should take the following values upon initialization:
int id, string manufacturer, string model, decimal price, double overallPerformance, int generation
Override ToString() method:
"Overall Performance: {overall performance}. Price: {price} - {product type}: {manufacturer} {model} (Id: {id}) Generation: {generation}"
Child Classes
There are several specific types of components, where the overall performance has a different multiplier:
•	CentralProcessingUnit - multiplier is 1.25
•	Motherboard – multiplier is 1.25
•	PowerSupply – multiplier is 1.05
•	RandomAccessMemory – multiplier is 1.20
•	SolidStateDrive – multiplier is 1.20
•	VideoCard – multiplier is 1.15
Example: If we create the CentralProcessingUnit with overallPerformance – 50, from the constructor, and multiplier 1.25, the overallPerformance should be 62.50.
Peripheral
The Peripheral is a derived class from Product and a base class for any peripherals and it should not be able to be instantiated.
Data
•	ConnectionType – string
Constructor
A product should take the following values upon initialization:
int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType
Override ToString() method:
"Overall Performance: {overall performance}. Price: {price} - {product type}: {manufacturer} {model} (Id: {id}) Connection Type: {connection type}"
Child Classes
There are several concrete types of peripherals:
•	Headset
•	Keyboard
•	Monitor
•	Mouse

Computer
The Computer is a derived class from Product and a base class for any computers and it should not be able to be instantiated.
Data
•	Components – IReadOnlyCollection
•	Peripherals – IReadOnlyCollection
•	OverallPerformance – override the base functionality (if the components collection is empty, it should return only the computer overall performance, otherwise return the sum of the computer overall performance and the average overall performance from all components)
•	Price – override the base functionality (The price is equal to the total sum of the computer price with the sum of all component prices and the sum of all peripheral prices)
Constructor
A product should take the following values upon initialization:
int id, string manufacturer, string model, decimal price, double overallPerformance
Override ToString() method:
"Overall Performance: {overall performance}. Price: {price} - {product type}: {manufacturer} {model} (Id: {id})"
" Components ({components count}):"
"  {component one}"
"  {component two}"
"  {component n}"
" Peripherals ({peripherals count}); Average Overall Performance ({average overall performance peripherals}):"
"  {peripheral one}"
"  {peripheral two}"
"  {peripheral n}"

Note: Be careful, some of the rows have one or two whitespaces at the beginning of the sentences!
Behavior
void AddComponent(IComponent component)
If the components collection contains a component with the same component type, throw an ArgumentException with the message "Component {component type} already exists in {computer type} with Id {id}."
Otherwise add the component in the components collection.
IComponent RemoveComponent(string componentType)
If the components collection is empty or does not have a component of that type, throw an ArgumentException with the message "Component {component type} does not exist in {computer type} with Id {id}."
Otherwise remove the component of that type and return it.
void AddPeripheral(IPeripheral peripheral)
If the peripherals collection contains a peripheral with the same peripheral type, throw an ArgumentException with the message "Peripheral {peripheral type} already exists in {computer type} with Id {id}."
Otherwise add the peripheral in peripherals collection.
IPeripheral RemovePeripheral(string peripheralType)
If the peripherals collection is empty or does not have a peripheral of that type, throw an ArgumentException with the message "Peripheral {peripheral type} does not exist in {computer type} with Id {id}."
Otherwise remove the peripheral of that type and return it.
Child Classes
There are several specific types of computers, where the overall performance has a different value:
•	DesktopComputer – overall performance is 15
•	Laptop – overall performance is 10
Child classes should not receive an overall performance as a parameter from the constructor.

Task 2: Business Logic (150 Points)
The Controller Class
The business logic of the program should be concentrated around several commands. You are given interfaces, which you have to implement in the correct classes.
Note: The Controller class SHOULD NOT handle exceptions! The tests are designed to expect exceptions, not messages!
The first interface is the IController. You must create a Controller class, which implements the interface and implements all of its methods. The constructor, of the Controller, does not take any arguments. The given methods should have the logic, described for each in the Commands section.
Commands
There are several commands, which control the business logic of the application. They are stated below. 
NOTE: For each command, except for "AddComputer" and "BuyBest", you must check if a computer, with that id, exists in the computers collection. If it doesn't, throw an ArgumentException with the message "Computer with this id does not exist.".
AddComputer Command
Parameters
•	computerType – string
•	id – int
•	manufacturer – string
•	model – string
•	price – decimal
Functionality
Creates a computer with the correct type and adds it to the collection of computers.
If a computer, with the same id, already exists in the computers collection, throw an ArgumentException with the message "Computer with this id already exists."
If the computer type is invalid, throw an ArgumentException with the message "Computer type is invalid."
If it's successful, returns "Computer with id {id} added successfully.".
AddComponent Command
Parameters
•	computerId – int
•	id – int
•	componentType – string
•	manufacturer – string
•	model – string
•	price – decimal
•	overallPerformance – double
•	generation – int
Functionality
Creates a component with the correct type and adds it to the computer with that id, then adds it to the collection of components in the controller.
If a component, with the same id, already exists in the components collection, throws an ArgumentException with the message "Component with this id already exists."
If the component type is invalid, throws an ArgumentException with the message "Component type is invalid."
If it's successful, returns "Component {component type} with id {component id} added successfully in computer with id {computer id}.".
 
RemoveComponent Command
Parameters
•	componentType – string
•	computerId – int
Functionality
Removes a component, with the given type from the computer with that id, then removes component from the collection of components.
If it's successful, it returns "Successfully removed {component type} with id {component id}.".
AddPeripheral Command
Parameters
•	computerId – int
•	id – int
•	peripheralType – string
•	manufacturer – string
•	model – string
•	price – decimal
•	overallPerformance – double
•	connectionType – string
Functionality
Creates a peripheral, with the correct type, and adds it to the computer with that id, then adds it to the collection of peripherals in the controller.
If a peripheral, with the same id, already exists in the peripherals collection, it throws an ArgumentException with the message "Peripheral with this id already exists."
If the peripheral type is invalid, throws an ArgumentException with the message "Peripheral type is invalid."
If it's successful, it returns "Peripheral {peripheral type} with id {peripheral id} added successfully in computer with id {computer id}.".
RemovePeripheral Command
Parameters
•	peripheralType – string
•	computerId – int
Functionality
Removes a peripheral, with the given type from the computer with that id, then removes the peripheral from the collection of peripherals.
If it's successful, it returns "Successfully removed {peripheral type} with id { peripheral id}.".
 
BuyComputer Command
Parameters
•	id – int
Functionality
Removes a computer, with the given id, from the collection of computers.
If it's successful, it returns ToString method on the removed computer.
BuyBest Command
Parameters
•	budget – decimal
Functionality
Removes the computer with the highest overall performance and with a price, less or equal to the budget, from the collection of computers.
If there are not any computers in the collection or the budget is insufficient for any computer, throws an ArgumentException with the message "Can't buy a computer with a budget of ${budget}."
If it's successful, it returns ToString method on the removed computer.
GetComputerData Command
Parameters
•	id – int
Functionality
If it's successful, it returns ToString method on the computer with the given id.
Close Command
Functionality
Ends the program.
2.	Input / Output
You are provided with two interfaces, which will help you with the correct execution process of your program. The interface IEngine and the class, implementing this interface, should read the input and when the program finishes, this class should print the output. ICommandInterpreter and CommandInterpreter are responsible for executing a specific command. Call the appropriate method from the controller, and return the result to the engine class.
You are given the Engine and CommandInterpreter classes with written logic in them. In order the code to be compiled, some parts are commented, don't forget to comment them out.
Input
Below, you can see the format in which each command will be given in the input:
•	AddComputer {computer type} {id} {manufacturer} {model} {price}
•	AddComponent {computer id} {component id} {component type} {manufacturer} {model} {price} {overall performance} {generation}
•	RemoveComponent {component type} {computer id}
•	AddPeripheral {computer id} {peripheral id} { peripheral type} {manufacturer} {model} {price} {overall performance} {connection type}
•	RemovePeripheral {peripheral type} {computer id}
•	BuyComputer {id}
•	BuyBestComputer {budget}
•	GetComputerData {id}
•	Close
Output
Print the output, from each command, when issued. If an exception is thrown, during any of the commands' execution, print the exception message.

Task 3: Unit Testing (100 Points)
You will receive a skeleton with one class inside. The class will have some methods, properties, fields and constructors. Cover the whole class with unit test to make sure that the class is working as intended.
