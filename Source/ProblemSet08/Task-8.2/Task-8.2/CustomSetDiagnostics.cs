namespace ProblemSet08.Task02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class CustomSet<T>
    {
        /// <summary>
        /// See http://www.webgraphviz.com/
        /// </summary>
        /// <returns>Dumps the tree in graphviz format</returns>
        public string DumpTree()
        {
            var sb = new StringBuilder();
            var counter = 0;
            var d = new Dictionary<Node, string>();

            void Traverse(Node current, Action<Node> func)
            {
                if (current.Left != null)
                {
                    Traverse(current.Left, func);
                }

                func(current);

                if (current.Right != null)
                {
                    Traverse(current.Right, func);
                }
            }

            Traverse(_top, (n) =>
            {
                if (d.ContainsKey(n))
                {
                    return;
                }

                counter++;
                d.Add(n, counter.ToString());
            });

            sb.AppendLine("digraph sample {");

            foreach (var item in d)
            {
                sb.AppendLine($"L_{item.Value} [ label = \"{item.Key.Value}\" ];");
            }

            foreach (var item in d)
            {
                if (item.Key.Left != null)
                {
                    sb.AppendLine($"L_{item.Value} -> L_{d[item.Key.Left]} [ label = \"left\" ];");
                }

                if (item.Key.Right != null)
                {
                    sb.AppendLine($"L_{item.Value} -> L_{d[item.Key.Right]} [ label = \"right\" ];");
                }
            }

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
