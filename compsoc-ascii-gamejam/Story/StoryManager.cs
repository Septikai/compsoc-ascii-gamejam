namespace compsoc_ascii_gamejam.Stories;

class BiLinkedStoryNode
{
    private readonly BiLinkedStoryNode? nextNode;
    private readonly List<Tuple<string, BiLinkedStoryNode>>? decisions;
    private readonly string dialogue;

    public BiLinkedStoryNode(BiLinkedStoryNode? nextNode, List<Tuple<string, BiLinkedStoryNode>>? decisions, string dialogue)
    {
        this.nextNode = nextNode;
        this.decisions = decisions;
        this.dialogue = dialogue;
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

        return this;
    }

}

public class StoryManager
{
    private BiLinkedStoryNode root = new BiLinkedStoryNode(null, null, "Hello World");
}