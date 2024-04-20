using PhiAi.Core;

namespace NytMiniGenerator;

// general idea note to self
// actions are writing in single letters
// actions are legal only if a word can fit with the existing letters and newly placed letter in that action's row and column
// terminal state is no legal actions
// successful terminal state means all squares have a letter

// alternate idea that i doubt will work better than the above but idk bro
// actions are legal as long as there are empty squares left. an action can be any letter of alphabet
// terminal state when crossword is filled
// successful terminal state if crossword has only legal words

public class CrosswordDomain : IDomain<CrosswordState, CrosswordAction>
{
    public const int DIMENSION = 5;
    private List<string> _letters = new List<string> {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    private readonly IEnumerable<string> _legalWords;
    
    public CrosswordDomain()
    {
        _legalWords = new List<string>();
    }
    public CrosswordDomain(IEnumerable<string> legalWords)
    {
        _legalWords = legalWords;
    }

    public CrosswordState GetInitialState()
    {
        return new CrosswordState();
    }

    public IEnumerable<CrosswordAction> GetActionsFromState(CrosswordState state)
    {
        var actions = new List<CrosswordAction>();
        for (int row = 0; row < DIMENSION; row++)
        {
            for (int col = 0; col < DIMENSION; col++)
            {
                if (state.Squares[row,col] == string.Empty) 
                {
                    foreach(string letter in _letters)
                    {
                        if (
                            CanFitInLegalWord(state.AcrossWords[row].Remove(col,1).Insert(col, letter))
                            && CanFitInLegalWord(state.DownWords[col].Remove(row,1).Insert(row, letter))
                        )
                        {
                            actions.Add(new CrosswordAction(row, col, letter));
                        }
                    }
                }
            }
        }
       
        return actions;
    }

    public CrosswordState GetStateFromStateAndAction(CrosswordState state, CrosswordAction action)
    {
        var newState = new CrosswordState(state);
        newState.Squares[action.Row, action.Column] = action.Letter;
        newState.AcrossWords[action.Row] = newState.AcrossWords[action.Row].Remove(action.Column, 1).Insert(action.Column, action.Letter);
        newState.DownWords[action.Column] = newState.DownWords[action.Column].Remove(action.Row, 1).Insert(action.Row, action.Letter);
        return newState;
    }

    public double GetTerminalStateValue(CrosswordState state)
    {
        var allWords = state.AcrossWords.Concat(state.DownWords);
        if (allWords.Count() != allWords.Distinct().Count())
        {
            return -1;
        }
        foreach (var word in allWords)
        {
            if (!_legalWords.Contains(word))
            {
                return -1;
            }
        }
        return 1;
    }

    public bool IsStateTerminal(CrosswordState state)
    {
        return GetActionsFromState(state).Count() == 0; // todo this is why phiai needs to rethink isterminal, it's annoying
    }

    private bool CanFitInLegalWord(string letters)
    {
        string startTrimmedLetters = letters.TrimStart();
        int position = DIMENSION - startTrimmedLetters.Length;
        string fullyTrimmedLetters = startTrimmedLetters.TrimEnd();
        foreach(string word in _legalWords)
        {
            if (word.Substring(position).StartsWith(fullyTrimmedLetters))
            {
                return true;
            }
        }
        return false;
    }
}