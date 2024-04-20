using NytMiniGenerator;

var generator = new CrosswordGeneratorAi();
List<string> crossword = generator.Generate();
foreach(string word in crossword)
{
    Console.WriteLine(word);
}