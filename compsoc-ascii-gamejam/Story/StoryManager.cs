using System.Text;

namespace compsoc_ascii_gamejam.Stories;

public class BiLinkedStoryNode
{
    private BiLinkedStoryNode? nextNode;
    private List<Tuple<string, BiLinkedStoryNode>>? decisions;
    private string dialogue;

    public BiLinkedStoryNode(BiLinkedStoryNode? nextNode, List<Tuple<string, BiLinkedStoryNode>>? decisions, string dialogue)
    {
        this.nextNode = nextNode;
        this.decisions = decisions;
        this.dialogue = dialogue;
    }
    
    public BiLinkedStoryNode()
    {
        this.nextNode = null;
        this.decisions = null;
        this.dialogue = "";
    }

    public string getDialogue()
    {
        return dialogue;
    }

    public BiLinkedStoryNode? getNextNode()
    {
        return nextNode;
    }

    public List<string>? getDecisions()
    {
        if (decisions != null && decisions.Count == 0)
        {
            return null;
        }

        List<string> decisionList = new List<string>();

        foreach (var value in decisions)
        {
            decisionList.Add(value.Item1);
        }

        return decisionList;
    }

    public BiLinkedStoryNode getDecidedNode(string dec)
    {
        if (decisions != null)
            foreach (var value in decisions)
            {
                if (value.Item1 == dec)
                {
                    return value.Item2;
                }
            }
        Console.WriteLine("No such decision available");
        return this;
    }

    public void setNextNode(BiLinkedStoryNode newNode)
    {
        nextNode = newNode;
    }
    
    public void setDialogue(string newDialogue)
    {
        dialogue = newDialogue;
    }

    public void addDecision(Tuple<string, BiLinkedStoryNode> newDecision)
    {
        decisions ??= new List<Tuple<string, BiLinkedStoryNode>>();
        decisions.Add(newDecision);
    }

}

public class StoryManager
{
    private BiLinkedStoryNode root;


    public StoryManager(string filepath)
    {
        root = loadFile(filepath);
    }

    public BiLinkedStoryNode loadFile(string filepath)
    {
        filepath = Path.Combine(Directory.GetCurrentDirectory(), filepath);
        BiLinkedStoryNode? newRoot = new BiLinkedStoryNode();
        List<string?> fileLines = new List<string?>();
        using (var fileStream = File.OpenRead(filepath))
        {
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true)) {
                string? line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    fileLines.Add(line);
                }
            }
        }

        Dictionary<int, BiLinkedStoryNode> createdNodes = new Dictionary<int, BiLinkedStoryNode>();
        newRoot = RecursiveFileReader(ref fileLines, ref createdNodes, 0);

        return newRoot;
    }

    private static BiLinkedStoryNode? RecursiveFileReader(ref List<string?> fileLines, ref Dictionary<int, BiLinkedStoryNode> createdNodes, int workingIndex)
    {
        
        BiLinkedStoryNode currentWorkingNode = new BiLinkedStoryNode();

        if (createdNodes.TryGetValue(workingIndex, out var knownNode))
        {
            return knownNode;
        }
        
        var workingLine = fileLines[workingIndex];
        var data = workingLine.Split(';');
        currentWorkingNode.setDialogue(data[1]);
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
                var nextLine = int.Parse(choice[1]);
                //var item_given = int.Parse(choice[2]); //TODO: add items to the choice

                if (workingIndex != nextLine)
                {
                    var newNode = RecursiveFileReader(ref fileLines, ref createdNodes, nextLine);
                    if (newNode != null)
                    {
                        currentWorkingNode.addDecision(new Tuple<string, BiLinkedStoryNode>(dialogue, newNode));
                    }
                }
                else
                {
                    currentWorkingNode.addDecision(new Tuple<string, BiLinkedStoryNode>(dialogue, currentWorkingNode));
                }
            }
        }
        else
        {
            
            var newNode = RecursiveFileReader(ref fileLines, ref createdNodes, int.Parse(data[2]));
            if (newNode != null)
            {
                currentWorkingNode.setNextNode(newNode);
            }
        }

        createdNodes[workingIndex] = currentWorkingNode;
        
        return currentWorkingNode;
    }
}