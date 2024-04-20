using PhiAi.Core;
using PhiAi.MonteCarloTreeSearch;

namespace NytMiniGenerator;

public class CrosswordGeneratorAi
{
    private readonly MonteCarloTreeSearchAlgorithm<CrosswordDomain, CrosswordState, CrosswordAction> _algorithm;

    public CrosswordGeneratorAi()
    {
        _algorithm = new MonteCarloTreeSearchAlgorithm<CrosswordDomain, CrosswordState, CrosswordAction>(new CrosswordDomain(new List<string> {
            // across
            "abcde".ToUpper(),
            "fghij".ToUpper(),
            "klmno".ToUpper(),
            "pqrst".ToUpper(),
            "uvwxy".ToUpper(),
            // down
            "afkpu".ToUpper(),
            "bglqv".ToUpper(),
            "chmrw".ToUpper(),
            "dinsx".ToUpper(),
            "ejoty".ToUpper(),

            // red herring across
            "zbcde".ToUpper(),
            "azcde".ToUpper(),
            "abzde".ToUpper(),
            "abcze".ToUpper(),
            "abcdz".ToUpper(),
            
            "zghij".ToUpper(),
            "fzhij".ToUpper(),
            "fgzij".ToUpper(),
            "fghzj".ToUpper(),
            "fghiz".ToUpper(),
            
            "zlmno".ToUpper(),
            "kzmno".ToUpper(),
            "klzno".ToUpper(),
            "klmzo".ToUpper(),
            "klmnz".ToUpper(),
            
            "zqrst".ToUpper(),
            "pzrst".ToUpper(),
            "pqzst".ToUpper(),
            "pqrzt".ToUpper(),
            "pqrsz".ToUpper(),
            
            "zvwxy".ToUpper(),
            "uzwxy".ToUpper(),
            "uvzxy".ToUpper(),
            "uvwzy".ToUpper(),
            "uvwxz".ToUpper(),
            
            // red herring down
            "zfkup".ToUpper(),
            "zglvq".ToUpper(),
            "zhmwr".ToUpper(),
            "zinxs".ToUpper(),
            "zjoyt".ToUpper(),
            
            "azkup".ToUpper(),
            "bzlvq".ToUpper(),
            "czmwr".ToUpper(),
            "dznxs".ToUpper(),
            "ezoyt".ToUpper(),
            
            "afzup".ToUpper(),
            "bgzvq".ToUpper(),
            "chzwr".ToUpper(),
            "dizxs".ToUpper(),
            "ejzyt".ToUpper(),
           
            "fakzu".ToUpper(),
            "gblzv".ToUpper(),
            "hcmzw".ToUpper(),
            "idnzx".ToUpper(),
            "jeozy".ToUpper(),
           
            "fakpz".ToUpper(),
            "gblqz".ToUpper(),
            "hcmrz".ToUpper(),
            "idnsz".ToUpper(),
            "jeotz".ToUpper(),            
        }));
    }
    
    public List<string> Generate()
    {
        while (true)
        {
            _algorithm.SearchForIterations(175);
            var actions = _algorithm.GetActions();
            if (actions.Count() == 0)
            {
                break;
            }
            _algorithm.TakeAction(actions.First());
        }

        var crossword = new List<string>();
        foreach (string word in _algorithm.CurrentState.AcrossWords)
        {
            crossword.Add(word);
        }
        return crossword;
    }
}