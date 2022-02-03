using CommandPattern;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Block b1 = new Block("Block 1");
Block b2 = new Block("Block 2");

ICommand stackBlockCommand = new StackBlockCommand(b1, b2);

Console.WriteLine(stackBlockCommand.CanExecute());
stackBlockCommand.Execute();
Console.WriteLine(stackBlockCommand.CanExecute());