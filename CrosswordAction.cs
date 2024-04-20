using PhiAi.Core;

namespace NytMiniGenerator;

public class CrosswordAction : IAction
{
    public int Row { get; set; }
    public int Column { get; set; }
    public string Letter { get; set; }

    public CrosswordAction(int row, int column, string letter)
    {
        Row = row;
        Column = column;
        Letter = letter;
    }

    public bool Equals(IAction action)
    {
        var crosswordAction = (CrosswordAction) action;
        return crosswordAction.Row == Row 
            && crosswordAction.Column == Column
            && crosswordAction.Letter == Letter;
    }
} 