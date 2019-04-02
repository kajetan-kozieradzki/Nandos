# Nandos

MarsRovers\Logic - core classes, the solution of the problem.
MarsRovers\Infrastructure - helper classes such as parser, rover runner etc.
MarsRovers.Tests - unit tests for MarsRovers\Logic.
MarsRovers.IntegrationTests - test scenarios that parse the input from a string, place rovers in the right location, execute the instructions and assert that the the final position is the right one.
MarsRovers\Program.cs - same test scenarios as above, but it displays the output in the console.

I have assumed that the input is always in the correct format.

It runs on .NET Core 2.2 and utilises xUnit as a testing framework.
