Create a command pattern design using reflection. Use the provided skeleton,
 which contains a public StartUp class with a written logic inside the Main method.
 It is commented, so when you write the logic of your program, you can uncomment the code and test it. 
The input of commands will be received until the "Exit" command. Each command line will look as it follows:
 "{CommandName} {CommandArgs}". CommandName will be as follows: "Hello" -> executing HelloCommand and so on.
There are a few steps you can follow to employ the command pattern design:
Create a Command Interface
Create a Command interface - ICommand, which contains a method - Execute(string[] args). 
Create Command Objects
For this exercise, you need to create the following commands:
HelloCommand - The result from its execution should be: $"Hello, {args[0]}".
ExitCommand - It should exit the program and return null.
Create a Command Interpreter Interface
Create a command interpreter interface ICommandInterpreter, which contains a method Read(string args).
Create a Command Interpreter Class
Create a class CommandInterpreter. Its purpose is to read commands, execute them and return the result from their execution.  
Create a Class Engine
Create a class Engine, which contains a void Run() method. It should hold the following field:
private readonly ICommandInterpreter commandInterpreter;
It should have a constructor, which accepts an ICommandInterpreter: 
public Engine(ICommandInterpreter commandInterpreter)
The Run() method should accept input from the console and pass it to the proper class,
 as well as print the output from the commands. 
