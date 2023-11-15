using System.Text;
using compsoc_ascii_gamejam.Characters.Player;

namespace compsoc_ascii_gamejam.Story;

public class BiLinkedStoryNode
{
    private BiLinkedStoryNode? _nextNode;
    private List<Tuple<string, BiLinkedStoryNode>>? _decisions;
    private string _dialogue;
    private InventoryItem? _itemReceived;

    public BiLinkedStoryNode(BiLinkedStoryNode? nextNode, List<Tuple<string, BiLinkedStoryNode>>? decisions, string dialogue)
    {
        this._nextNode = nextNode;
        this._decisions = decisions;
        this._dialogue = dialogue;
    }
    
    public BiLinkedStoryNode()
    {
        this._nextNode = null;
        this._decisions = null;
        this._dialogue = "";
        this._itemReceived = null;
    }

    public string GetDialogue()
    {
        return _dialogue;
    }

    public BiLinkedStoryNode? GetNextNode()
    {
        return _nextNode;
    }

    public List<string>? GetDecisions()
    {
        if (_decisions is { Count: 0 })
        {
            return null;
        }

        List<string> decisionList = new List<string>();

        foreach (var value in _decisions)
        {
            decisionList.Add(value.Item1);
        }

        return decisionList;
    }

    public BiLinkedStoryNode GetDecidedNode(string dec)
    {
        if (_decisions != null)
            foreach (var value in _decisions)
            {
                if (value.Item1 == dec)
                {
                    return value.Item2;
                }
            }
        Console.WriteLine("No such decision available");
        return this;
    }

    public void SetNextNode(BiLinkedStoryNode newNode)
    {
        _nextNode = newNode;
    }
    
    public void SetDialogue(string newDialogue)
    {
        _dialogue = newDialogue;
    }

    public void AddDecision(Tuple<string, BiLinkedStoryNode> newDecision)
    {
        _decisions ??= new List<Tuple<string, BiLinkedStoryNode>>();
        _decisions.Add(newDecision);
    }

    public void SetItem(InventoryItem? newItem)
    {
        _itemReceived = newItem;
    }

    public InventoryItem? GetItem()
    {
        return _itemReceived;
    }

}

public class StoryManager
{
    private BiLinkedStoryNode? _root;


    public StoryManager(string filepath)
    {
        _root = LoadFile(filepath);
    }

    public BiLinkedStoryNode? LoadFile(string filepath)
    {
        Console.WriteLine($"Loading: {filepath}");
        filepath = Path.Combine(Directory.GetCurrentDirectory(), filepath);
        List<string?> fileLines = new List<string?>();
        using (var fileStream = File.OpenRead(filepath))
        {
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true)) {
                while (streamReader.ReadLine() is { } line)
                {
                    if (!line.Contains("#")) // comments help navigate the story format
                    {
                        fileLines.Add(line);
                    }
                }
            }
        }

        Dictionary<int, BiLinkedStoryNode> createdNodes = new Dictionary<int, BiLinkedStoryNode>();
        var newRoot = RecursiveFileReader(ref fileLines, ref createdNodes, 0);
        Console.WriteLine("Successfully loaded story!");
        return newRoot;
    }

    private static BiLinkedStoryNode? RecursiveFileReader(ref List<string?> fileLines, ref Dictionary<int, BiLinkedStoryNode> createdNodes, int workingIndex)
    {
        
        BiLinkedStoryNode currentWorkingNode = new BiLinkedStoryNode();

        if (createdNodes.TryGetValue(workingIndex, out var knownNode))
        {
            return knownNode;
        }

        if (workingIndex < 0)
        {
            return null;
        }
        var workingLine = fileLines[workingIndex];
        var data = workingLine.Split(';');
        currentWorkingNode.SetDialogue(data[1]);
        createdNodes.Add(workingIndex, currentWorkingNode);
        if (data[2].Contains('{'))
        {
            data[2] = data[2].Replace("{", "");
            data[2] = data[2].Replace("}", "");
            var choices = data[2].Split("@");
            for (var i = 0; i < choices.Length; i++)
            {
                var choice = choices[i].Split("_");
                var dialogue = choice[0];
                var nextLine = int.Parse(choice[2]);
                InventoryItem? itemGiven = int.Parse(choice[1]) switch
                {
                    0 => InventoryItem.Rock,
                    1 => InventoryItem.Stick,
                    2 => InventoryItem.Flowers,
                    3 => InventoryItem.RustedBlade,
                    4 => InventoryItem.ThornyVine,
                    _ => null
                };

                if (workingIndex != nextLine)
                {
                    var newNode = RecursiveFileReader(ref fileLines, ref createdNodes, nextLine);
                    newNode.SetItem(itemGiven);
                    if (newNode != null)
                    {
                        currentWorkingNode.AddDecision(new Tuple<string, BiLinkedStoryNode>(dialogue, newNode));
                    }
                }
                else
                {
                    currentWorkingNode.AddDecision(new Tuple<string, BiLinkedStoryNode>(dialogue, currentWorkingNode));
                }
            }
        }
        else
        {
            
            var newNode = RecursiveFileReader(ref fileLines, ref createdNodes, int.Parse(data[2]));
            if (newNode != null)
            {
                currentWorkingNode.SetNextNode(newNode);
            }
        }

        createdNodes[workingIndex] = currentWorkingNode;
        
        return currentWorkingNode;
    }

    public void nextNode()
    {
        if (_root.GetNextNode() != null)
        {
            _root = _root.GetNextNode();    
        }
    }

    public void nextDecisionNode(string decison)
    {
        _root = _root.GetDecidedNode(decison);
    }
    
    
    public string getDialogue()
    {
        return _root.GetDialogue();
    }

    public List<string>? getDecisions()
    {
        return _root.GetDecisions();
    }

    public InventoryItem? getItem()
    {
        return _root.GetItem();
    }

    public string[]? getEffect()
    {
        string[] result = getDialogue().Split('[');
        if (result.Length != 1)
        {
            var effect = result[^1].Replace("]", "").Split("_");
            if (effect[0] == "LOAD")
            {
                // Console.WriteLine($"Loading next story: {effect[1]}");
                _root = LoadFile(effect[1]);
                return effect;
            }
            else
            {
                // Console.WriteLine($"Effect applied: {effect[1]}");
                return effect;
            }
        }
        else
        {
            return null;
        }
    }
}