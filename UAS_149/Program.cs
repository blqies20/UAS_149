using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace UAS_149
{
    class Node
    {
        public int rollNumber;
        public string name;
        public string jenis;
        public int harga;
        public Node next;
        public Node prev;
    }
    class doublelinkedlist
    {
        Node START;
        public doublelinkedlist()
        {
            START = null;
        }
        public void addNode()
        {
            int rollNo;
            string nm;
            string jenis;
            int harga;
            Console.Write("\nMasukkan id barang : ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama barang : ");
            nm = Console.ReadLine();
            Console.Write("\nMasukkan jenis barang : ");
            jenis = Console.ReadLine();
            Console.Write("\nMasukkan harga barang : ");
            harga = Convert.ToInt32(Console.ReadLine());
            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;
            newnode.jenis = jenis;
            newnode.harga = harga;

            if (START!= null || rollNo <= START.rollNumber)
            {
                if ((START!= null) && (rollNo == START.rollNumber))
                {
                    {
                        Console.WriteLine("\nduplicate id barang not allowed");
                        return;
                    }
                    newnode.next = START;
                    if (START!= null)
                        START.prev = newnode;
                    newnode.prev = null;
                    START = newnode;
                    return;
                }
                Node previous, current;
                for (current = previous = START; current != null && rollNo >= current.rollNumber; previous = current, current = current.next)
                {
                    if (rollNo == current.rollNumber)
                    {
                        Console.WriteLine("\nduplicate id barang not allowed");
                        return;
                    }
                }
                newnode.next = current;
                newnode.prev = previous;

                if (current == null)
                {
                    newnode.next = null;
                    previous.next = newnode;
                }
                current.prev = newnode;
                previous.next = newnode;
            }
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null && rollNo != current.rollNumber; previous = current, current = current.next)
            { }

            return (current !=null);
        }
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public void traverse()
        {
            if (ListEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the ascending order of "+"roll numbers are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + "  " + currentNode.name + "\n");
            }
        }
        public void retraverse()
        {
            if (ListEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("/nRecords in the descending order of "+"roll numbers are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.rollNumber + "  " + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            doublelinkedlist obj = new doublelinkedlist();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Menu" +
                        "\n 1. Add a record to the list" +
                        "\n 2. Delete a record from the list" +
                        "\n 3. View all records in the ascending order of roll numbers" +
                        "\n 4. View all records in the descending order of rol numbers" +
                        "\n 5. Search for a record in the list" +
                        "\n 6. Exit \n" +
                        "\n Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.ListEmpty())
                                {
                                    Console.WriteLine("\nList is empty" + "Whose record si to be deleted: ");
                                    break;
                                }
                                Console.WriteLine("\nMasukkan id barang");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number" + rollNo + "deleted\n");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                obj.retraverse();
                            }
                            break;
                        case '5':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("\nEnter the roll number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number" + curr.rollNumber);
                                    Console.WriteLine("\nName" + curr.name);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                            }
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Check for the values entered. ");
                }
            }
        }
    }
}
   
   //2) menggunakan algortima double linked list, karena bisa menginput beberapa data dalam sekali pilih perintah, dan menampilkan data dalam bentuk list yang sesuai//
   //3) rear, front//
   //4) a. memiliki 5 kedalaman  ||  b. inorder traversal//