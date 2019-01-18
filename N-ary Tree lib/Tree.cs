using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_ary_Tree
{
    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }
        public int Count { get; set; }
        public int LeafCount { get; set; }

        public Tree()
        {
            this.Root = null;
            this.Count = 0;
            this.LeafCount = 0; 
        }
        
        // Voeg een ChildNode toe aan een parent 
        public TreeNode<T> AddChildNode(TreeNode<T> parentNode, T value)
        {
            TreeNode<T> Node = new TreeNode<T>(parentNode, value);

            // De eerste node die wordt toegevoegd aan de tree, heeft geen parent en is de root van de tree.
            if (parentNode != null) {parentNode.Children.Add(Node);}
            else {this.Root = Node;}
            
            // Als het de eerste node is van de tree of als de parent meerdere children bevat
            // Betekent dit dat de huidige node een LeafNode is
            if (parentNode == null||parentNode.Children.Count > 1) { LeafCount++; }
            
            // Update Count
            Count++;
            return Node;
        }
       
        // Het verwijderen van een Node (met zijn aanhangsels) uit de tree 
        public void RemoveNode(TreeNode<T> Node) {

            // Als de opgegeven Node niet de root is
            if (Node.Parent != null) {
                // Controleer per node die wordt verwijderd:
                // - Of het een leadNodes is -->  leafCount--;
                // - Hoeveel kinderen die heeft --> Count -= Aantal kinderen
                
                List<TreeNode<T>> RemovedNodes = new List<TreeNode<T>>();
                RemovedNodes.Add(Node);

                //Update Count
                Count--;

                // Totdat alle Nodes zijn bekeken (die worden verwijderd)
                while (RemovedNodes.Count != 0)
                {   // Voeg de Children toe van elke node, zodat alle Children worden bekeken.
                    RemovedNodes.AddRange(RemovedNodes[0].Children);

                    // Als de Node een LeafNode is
                    if (RemovedNodes[0].Children.Count == 0){ LeafCount--;}

                    // Als de Node Children heeft
                    else{Count -= RemovedNodes[0].Children.Count;}

                    // Verwijder de Node die is gecontroleerd uit de lijst RemovedNodes
                    RemovedNodes.Remove(RemovedNodes[0]);
                }
                // Als de parent van de Node alleen deze Node als Child heeft,
                // Zal de parent een LeafNode worden
                if (Node.Parent.Children.Count == 1) {LeafCount++;}

                // Verwijder de opgegeven Node met de bijbehorende aanhangsels uit de Tree
                Node.Parent.Children.Remove(Node);
            }
            // Als de opgegeven Node de root is, wordt de hele boom leeg gemaakt
            else
            {
                Node.Children.Clear();
                Node = null;
                this.Count = 0;
                this.LeafCount = 0;
            }
        }

        // Return alle Nodes uit de Tree
        public List<T> TraverseNodes() {

            // Lijst met de values van alle Nodes
            List<T> AllNodes = new List<T>();
            AllNodes.Add(Root.Value);

            // Lijst die wordt gebruikt om alle Nodes af te gaan
            List<TreeNode<T>> Parents = new List<TreeNode<T>>();
            Parents.Add(Root);

            // Totdat er alle Nodes zijn bekeken
            while (Parents.Count != 0)
            {  
                // Voeg de children van de huidige Node toe aan de lijst met Parents
                Parents.AddRange(Parents[0].Children);

                // Voeg alle children van de huidige Node toe aan de lijst AllNodes
                Parents[0].Children.ForEach(x => AllNodes.Add(x.Value)); 

                // Verwijder de huidige Node uit de lijst Parents
                Parents.Remove(Parents[0]);
            }
            return AllNodes;
        }

        // Bereken voor elke LeafNode de som van alle Nodes op het pad t/m de Root
        public List<dynamic> SumOfLeafs() {

            // Maakt een lijst aan waar alle sommen in komen te staan
            // Door dynamic te beruiken wordt er rekening gehouden met de verschillende datatypen die 
            // voor kunnen komen in een Tree
            List<dynamic> AllSums = new List<dynamic>(LeafCount); 

            // Gebruik een lijst waarin parents worden opgeslagen
            List<TreeNode<T>> Parents = new List<TreeNode<T>>();
            Parents.Add(Root);

            // Voor de datatypen double en int worden de Node values bij elkaar opgeteld
            // i is de index van AllSums
            int i = 0;

            // Voor het datatype string worden de Nodes values aan elkaar geplakt
            StringBuilder builder = new StringBuilder();

            // Totdat alle Nodes zijn bekeken
            while (Parents.Count != 0)
            {
                // Als de Node een LeafNodes is
                if (Parents[0].Children.Count == 0 ) {

                    // Maak een plaats vrij in AllSums (Dit is niet nodig voor strings)
                    if (Parents[0].Value is double || Parents[0].Value is int){ AllSums.Add(0);}

                    // Elke parent wordt op het pad bekeken t/m de Root
                    // Deze parents worden bij elkaar opgeteld (of aan elkaar geplakt)
                    TreeNode<T> Node = Parents[0];
                    while (Node != null){ 
                        if (Parents[0].Value is string) {
                            builder.Append(Node.Value);
                        }
                        if (Parents[0].Value is double|| Parents[0].Value is int )
                        {
                            AllSums[i] += Node.Value;
                        }
                        Node = Node.Parent;
                    }
                    // In het geval van het datatype string: Voeg de som toe aan Allsums en leeg de builder
                    if (Parents[0].Value is string) {
                        AllSums.Add(builder.ToString());
                        builder.Clear();
                    }
                    // Update de Index
                    i++;
                }

                // Ga verder met zoeken naar de LeafNodes
                Parents.AddRange(Parents[0].Children);
                Parents.Remove(Parents[0]);
             }
            return AllSums;
        }

        //Deze method is bedoeld om een beeld te krijgen van hoe de Tree eruit ziet
        public void ShowTree() {

            // Als de Tree TreeNodes bevat
            if (Count != 0)
            {   // In deze lijst worden de parents opgeslagen
                List<TreeNode<T>> Parents = new List<TreeNode<T>>();
                Parents.Add(Root);

                // In deze lijst worden de children van een Node opgeslagen
                List<TreeNode<T>> Children = new List<TreeNode<T>>();
                
                // Toon de Root
                Console.WriteLine("{0}: {1}", "Root", Root.Value);

                // Totdat de lijst Parents TreeNodes bevat
                while (Parents.Count != 0)
                {
                    // Totdat de lijst Parents TreeNodes bevat
                    while (Parents.Count != 0)
                    {   
                        // Als de Parent children bevat
                        if (Parents[0].Children.Count != 0)
                        {
                            // Toon alle children
                            Console.Write("ChildOf_{0}: ", Parents[0].Value);
                            Parents[0].Children.ForEach(x => Console.Write("{0}  ", x.Value));
                            Console.Write("| ");
                        }
                        // Voeg de children van de Parent toe aan de lijst met children
                        Children.AddRange(Parents[0].Children);

                        // Verwijder de Parent waarvan de children al zijn getoond.
                        Parents.Remove(Parents[0]);

                    }
                    Console.Write("\n");

                    // De children worden de parents
                    Parents = Children.ToList();

                    // Maak de lijst met children leeg
                    Children.Clear();
                }
            }
            // Als de Tree leeg is
            else{ Console.WriteLine("Waarschuwing: de Tree bevat geen nodes");}
        }
    }
}
