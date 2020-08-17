using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProgramRunner
{
    [Skip]
    public class NAryTree : Runner
    {
        enum StatusFlag
        {
            Waiting = 1,
            Downloading,
            Downloaded,

            Installing,
            Installed,

            Uninstalling,
            Uninstalled,

            DownloadFailed,
            InstallFailed,
            UninstallFailed,

            Abort

        }

        class Node
        {
            public Node(StatusFlag status)
            {
                this.Status = status;
            }
            public StatusFlag Status { get; set; }
            /// <summary>
            /// Genearlly denotes success case
            /// </summary>
            public Node Right { get; set; }
            /// <summary>
            /// Genearlly denotes failure case
            /// </summary>
            public Node Left { get; set; }

        }

        Node root = new Node(StatusFlag.Waiting)
        {
            Right = new Node(StatusFlag.Downloading)
            {
                Right = new Node(StatusFlag.Downloaded)
                {
                    Right = new Node(StatusFlag.Installing)
                    {
                        Right = new Node(StatusFlag.Installed),
                        Left = new Node(StatusFlag.InstallFailed)
                    }
                },
                Left = new Node(StatusFlag.DownloadFailed)
            },
            Left = new Node(StatusFlag.Uninstalling)
            {
                Right = new Node(StatusFlag.Uninstalled),
                Left = new Node(StatusFlag.UninstallFailed)
            }
        };

        public override void Run(string[] args)
        {
            StatusFlag[] goodSeq1 =
                new StatusFlag[] { StatusFlag.Waiting, StatusFlag.Downloading, StatusFlag.Downloaded, StatusFlag.Installing, StatusFlag.Installed };

            StatusFlag[] goodSeq2 =
               new StatusFlag[] { StatusFlag.Waiting,
                   StatusFlag.Downloading, StatusFlag.Downloading, StatusFlag.Downloading,
                   StatusFlag.Downloaded, StatusFlag.Installing, StatusFlag.Installed };

            StatusFlag[] badSeq1 =
               new StatusFlag[] { StatusFlag.Waiting,
                   StatusFlag.Downloading, StatusFlag.Downloading, StatusFlag.Downloading,
                   StatusFlag.Downloaded, StatusFlag.Installing, StatusFlag.Installed, StatusFlag.Waiting, StatusFlag.Downloading };

            StatusFlag[] badSeq2 =
              new StatusFlag[] { StatusFlag.Waiting,
                   StatusFlag.Downloading, StatusFlag.Downloading, StatusFlag.Downloading,
                   StatusFlag.Downloaded, StatusFlag.Installing, StatusFlag.Installed, StatusFlag.Installing };

            StatusFlag[] badSeq3 =
              new StatusFlag[] { StatusFlag.Waiting,
                   StatusFlag.Downloading, StatusFlag.Downloading, StatusFlag.Downloading,
                   StatusFlag.Downloaded, StatusFlag.Downloading, StatusFlag.Installed, StatusFlag.Installing };

            Console.WriteLine($"\nProcessing {nameof(goodSeq1)}\n");
            LastProcessedNode = null;
            foreach (var i in goodSeq1)
            {
                //Thread.Sleep(1000);
                ProcessGoodOnesPrintBadOnes(i);
            }

            Console.WriteLine($"\nProcessing {nameof(goodSeq2)}\n");
            LastProcessedNode = null;
            foreach (var i in goodSeq2)
            {
                //Thread.Sleep(1000);
                ProcessGoodOnesPrintBadOnes(i);
            }

            Console.WriteLine($"\nProcessing {nameof(badSeq1)}\n");
            LastProcessedNode = null;
            foreach (var i in badSeq1)
            {
                //Thread.Sleep(1000);
                ProcessGoodOnesPrintBadOnes(i);
            }

            Console.WriteLine($"\nProcessing {nameof(badSeq2)}\n");
            LastProcessedNode = null;
            foreach (var i in badSeq2)
            {
                //Thread.Sleep(1000);
                ProcessGoodOnesPrintBadOnes(i);
            }

            Console.WriteLine($"\nProcessing {nameof(badSeq3)}\n");
            LastProcessedNode = null;
            foreach (var i in badSeq3)
            {
                //Thread.Sleep(1000);
                ProcessGoodOnesPrintBadOnes(i);
            }

        }


        Node LastProcessedNode = null;

        void ProcessGoodOnesPrintBadOnes(StatusFlag st)
        {
            if (LastProcessedNode == null)
                LastProcessedNode = root;

            if (!(GetLastProcessNode(LastProcessedNode, st)))
            {
                Console.WriteLine($"Error!!Status {st} is invalid. Previous status is {LastProcessedNode?.Status}");
            }
        }

        // update last processed node from here
        // cs => Current staus
        // lpn => Last processed node
        bool GetLastProcessNode(Node lpn, StatusFlag cs)
        {
            if (lpn == null) return false;

            if (lpn.Status == cs)
            {
                LastProcessedNode = lpn;
                Console.WriteLine($"Processed {cs}");
                return true;
            }

            return GetLastProcessNode(lpn.Right, cs) || GetLastProcessNode(lpn.Left, cs);
        }

    }
}
