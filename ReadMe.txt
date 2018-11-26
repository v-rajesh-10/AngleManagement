Details on the Design and Considerations
 - DegreeAngle and RadianAngle are public and Inherit from Angle Base Class
 - Supports Explicit Casting and avoided Implementing Implicit Cast give the conversion can fail 
	(Upper limit and Lowe Limit of angles is a constarint for validity of an angle instance)
 - All Operations are Abstract classes and Implemented by the Corresponding Angles(Radian Or Degree)
 - ToRadian ToDegree Conversions are Declared virtual in base class to avoid overriding the same type in the corresponding classes
 - IsValid is Declared as virtual in the base class and its up to the Derive class to override this feature and take corresponding action.
	- As of this Design - The IsValid check is done in both Radian and Degree class. It's possible that  in future a angle type does not require
	any validation in which case there is no need for additional overriding of IsValid and setting it as true. 
 
 Assumption
 - All the methods in the Derived classes are not availble for an external users except (Equals, IsValid, ToRadian, ToDegree). The assumption was
   the usage would be using the operator and NOT using the abstract methods.
   For example - DegreeAngle angle1 = new DegreeAngle(180);
				 DegreeAngle angle2 = new DegreeAngle(180);
				 var angle3 = angle + angle2 // Available
				 var angle3 = angle.Sum(angle2) // Sum is not available to the consumer of the library

UnitTests
 - 80 tests written in MSTests with Shouldly (for readable assertions)
 - CodeCoverage using MSTests - 87.5%
 - AngleTests contains all the operations and avoided adding the same the DegreeTest and RadianTest class since it would eventually Radian and Degree classes.
 - DegreeTest and RadianTest contains tests for casting

 What's Missing
 Based on my initial self review there seems an issue with Angles in a "Direction" which is ALWAYS converted to "DEGREES" on CASTING.
 I am forced to do this in the casting operation and it goes back to the logic which I have used for converting Directions. As of now the logic reflects based on the below formula,
		(450 - direction.Angle.ToDegree()) % 360;
The above converted degree seems to work however the limitation is "The ANGLE Instance in Direction does not expose any property indicating its type".

I am guessing there could be a better way or a Mathematical Formula that could exists which would use the trignometric functions for computation
and this would no longer require any specific logic in the casting operations method and shoule get rid of this problem.

Additional Stuff
For Trignometric Functions I assumed that a consumer could potentially do something like,
	var angle = angle.Sin() // Returns and Angle Instance
	double sinValue = angle.SinValue // ReadOnly Property with values of different Math functions loaded during object creation
I was not certain on the expectation from the document and both the flavours are implemented.

Thoughts / Observations
 Given that this is a library should we even expose the "DegreeAngle" and "RadianAngle" objects. Initially when I started the design was thinking of
 an expression builder pattern (https://www.martinfowler.com/bliki/ExpressionBuilder.html) in which case the consumer of the library would only have to
 - Provide a value (double)
 - Specify the unit (string) - The string would represnt the type of the angle and the consumer need to pass this as "string" since we can extend this
						       without having to compile the client code ( the consumer of this library).
However reading the question there was need for casting across different angles and hence decided not to take this route and made the Derived classes as public.