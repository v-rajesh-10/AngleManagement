Details on the Design and Considerations
 - DegreeAngle and RadianAngle are public and Inherit from Angle Base Class
 - Only Explicit Casting is Supported given the Intent of this problem is to AVOID angle values passed around.
 - All Operations are Abstract classes and Implemented by the Corresponding Angles(Radian Or Degree)
 - ToRadian ToDegree Conversions are Declared virtual in base class to avoid overriding the same type in the corresponding classes
   For example - We don't have to override ToRadian in the Radian Class since the value is just returning the value that's done in base class.
 - IsValid is Declared as virtual in the base class and its up to the Derive class to override this feature and take corresponding action.
	- As of this Design - The IsValid check is done in both Radian and Degree class. It's possible that  in future an angle type does not 
						  require any validation in which case there is no need for additional overriding of IsValid and setting it as true.

Assumptions
 - All the methods in the Derived classes are not availble for an external users except (Equals, IsValid, ToRadian, ToDegree). The assumption was
   the usage would be using the operator and NOT using the abstract methods.
   For example - DegreeAngle angle1 = new DegreeAngle(180);
				 DegreeAngle angle2 = new DegreeAngle(180);
				 var angle3 = angle + angle2 // Available
				 var angle3 = angle.Sum(angle2) // Sum is not available to the consumer of the library
 - Trignometric Functions
    I have Implemented Properties that would retrirve the "VALUES" corresponding to the trignometric function. As of now I am ONLY supporting,
	DegreeAngle angle1 = new DegreeAngle(180);
	angle1.SineValue() // Available
	var angle = angle1.Sin() // NOT Implemented As of now. The Implementation would again have common Implementation in the base classe like how its done for properties.

UnitTests
 - 80 tests written in MSTests with Shouldly (for readable assertions)
 - CodeCoverage using MSTests - 92.25%
 - AngleTests contains all the operations and avoided adding the same the DegreeTest and RadianTest class 
   since the consumer ONLY can invoke using the exposed operators ( As per the Implementation ).
 - DegreeTest and RadianTest does contain tests for casting

Limitations In Direction Casting ( Lack of Domain Knowledge on Directions )
Based on my initial self review there seems an issue with Angles in a "Direction" which is ALWAYS converted to "DEGREES" on CASTING ( as per my implementation ).
I am forced to do this in the casting operation and it goes back to the logic which I have used for converting Directions. 
As of now the logic reflects based on the below formula,
		(450 - direction.Angle.ToDegree()) % 360;
The above converted degree seems to work across angles with the types of directions however the limitation what is seen (IMO),
"The ANGLE Instance in Direction does not expose any property indicating its type". 
Let's assume that this is taken care and even if we do this we would result in 
either adding if else or switch statements for every casting implementation of direction for ensuring that the "Casted Instance" 
need to have the same angle type

The Implementation as of now DOES casting of directions but the cased instance angle is ALWAYS in DEGREES.

I am guessing there could be a better way or a Mathematical Formula that could exists which would use the trignometric functions for computation
and this would no longer require any specific logic in the casting operations method and shoule get rid of this problem. If this is true then we 
also need to support Trignometric functions returning "Angle" instead of double.

Thoughts / Observations
 Given that this is a library should we even expose the "DegreeAngle" and "RadianAngle" objects. Initially when I started the design was thinking of
 an expression builder pattern (https://www.martinfowler.com/bliki/ExpressionBuilder.html) in which case the consumer of the library would only have to
 - Provide a value (double)
 - Specify the unit (string) - The string would represnt the type of the angle and the consumer need to pass this as "string" since we can extend this
						       without having to compile the client code ( the consumer of this library).
However reading the question there was need for casting across different angles and hence decided not to take this route and made the Derived classes as public.