using PhiAi.Core;

namespace NytMiniGenerator;

public class CrosswordState : IState
{
    public string[,] Squares { get; set; } = new string[,] {
        {string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
        {string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
        {string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
        {string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
        {string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
    };
    public List<string> AcrossWords { get; set; } = new List<string> {
        new string(' ', CrosswordDomain.DIMENSION),
        new string(' ', CrosswordDomain.DIMENSION),
        new string(' ', CrosswordDomain.DIMENSION),
        new string(' ', CrosswordDomain.DIMENSION),
        new string(' ', CrosswordDomain.DIMENSION)
    };
    public List<string> DownWords { get; set; } = new List<string> {
        new string(' ', CrosswordDomain.DIMENSION),
        new string(' ', CrosswordDomain.DIMENSION),
        new string(' ', CrosswordDomain.DIMENSION),
        new string(' ', CrosswordDomain.DIMENSION),
        new string(' ', CrosswordDomain.DIMENSION)
    };

    public List<string> ReservedWords { get; set; } = new List<string>();
    public string Agent { get; set; } = "GENERATOR";
    public bool IsTerminal { get; set; } = false;

    public CrosswordState()
    {
        Squares = new string[,] {
            {string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
            {string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
            {string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
            {string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
            {string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
        };
    }

    public CrosswordState(CrosswordState state)
    {
        for (int i = 0; i < CrosswordDomain.DIMENSION; i++)
        {
            for (int j = 0; j < CrosswordDomain.DIMENSION; j++)
            {
                Squares[i,j] = state.Squares[i,j];
            }
        }
        AcrossWords.Clear();
        foreach (string word in state.AcrossWords)
        {
            AcrossWords.Add(word);
        }
        DownWords.Clear();
        foreach (string word in state.DownWords)
        {
            DownWords.Add(word);
        }
        ReservedWords.Clear();
        foreach (string word in state.ReservedWords)
        {
            ReservedWords.Add(word);
        }
    }

    public bool Equals(IState state)
    {
        var crosswordState = (CrosswordState) state;
        // todo if implemented in PhiAi
        return true;
    }

}