Create your custom validation attributes. 
There is a written logic inside the provided skeleton,
 which you can use to test the logic of your program. 
It is commented, so when you write the logic of your program, you can uncomment the code and test it.
Create Attributes
Create a validation attribute: MyValidationAttribute. Its purpose is to validate properties. 
•	It should contain the following method: public abstract bool IsValid(object obj)
Create a validation attribute: MyRangeAttribute.
•	Its constructor should accept two parameters - int minValue, int maxValue, which represent a range of integer numbers
•	It should contain two fields: int minValue and int maxValue
•	It should implement the bool IsValid(object obj) method and its logic
 should validate whether the passed object obj parameter is within the set range
Create a validation attribute: MyRequiredAttribute.
•	It should implement the bool IsValid(object obj) method and its logic
 should validate whether a property has the attribute or not
Create an Entity
Create a class Person. It should have a constructor, which accepts two parameters: string fullName, int age.
It should have two properties:
•	string FullName - the property is required. Apply the MyRequiredAttribute
•	int Age - the age should be between 12 and 90. 
Apply the MyRangeAttribute and set the right values for minimum and maximum age
Create a Validator Class
Create a static class Validator. It should contain a method - 
public static bool IsValid(object obj), which must validate the properties of a given object.
