using System;
using System.Collections;
using System.Collections.Generic;
using BST_lib;

namespace lab1_binary_search_tree_
{
    class animal:IComparable 
    { 
        public string name { get; set; }
        public animal (string name)
        {
            this.name = name;
        }

        public int CompareTo(object obj)
        {
            if (obj is animal a) return name.CompareTo(a.name);
            throw new Exception("Виключна ситуацiя: порiвняння енiмла з неенiмал");
        }
        public override string ToString()
        {
            return name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            b_t<int, string> tree1 = new b_t<int, string>();
            tree1.ev1 += (_,ea) => Console.WriteLine("Подiя: "+ ea.mes); //пiдписались на подiї
            tree1.insert(5, "value5");
            tree1.insert(1, "value1");
            tree1.insert(7, "value7");
            tree1.insert(8, "value8");
            tree1.insert(6, "value6");
            Console.WriteLine($"count={tree1.count}");
            Console.WriteLine(tree1.LCR()); //обхiд дерева лiвий-центр-правий (по зростанню ключiв)
            node<int, string> f1 = tree1.find(5); // пошук
            Console.WriteLine($" ({f1.key}, {f1.value})");
            Console.WriteLine(tree1.exist(7, "value7"));
            Console.WriteLine("\n test iменованого iтератора в foreach: ");
            foreach (node<int, string> T in tree1) // test iменованого iтератора в foreach:
            {
                Console.Write($"({T.key},{T.value}), ");
            }
            Console.Write("\nПревiрка виключної ситуацiї:");
            try // превiрка виключної ситуацiї
            {
                tree1.insert("hello", "world");
            }
            catch(Exception e)
            {
                Console.WriteLine("\nВиключна ситуацiя: "+e.Message);
            }
            finally { Console.WriteLine("кiнець програми"); }
            
            Console.WriteLine("\n\nдобавимо в колекцiю клас енiмал");
            b_t<int, animal> tree2 = new b_t<int, animal>();
            tree2.ev1 += (_, ea) => Console.WriteLine("Подiя: " + ea.mes); //пiдписались на подiї
            tree2.insert(3, new animal("вовк"));
            tree2.insert(1, new animal("заєць"));
            tree2.insert(4, new animal("лисиця"));
            Console.WriteLine(tree2.LCR());
            Console.WriteLine("\n test iменованого iтератора в foreach: ");
            foreach (node<int, animal> T in tree2) // test iменованого iтератора в foreach:
            {
                Console.Write($"({T.key},{T.value}), ");
            }
            IEnumerable<node<int, animal>> tree3 = tree2; //перевіряємо чи дійсно інтерфес працює 
            Console.WriteLine("\n test iменованого iтератора в foreach, в якому явно використали iнтерфейс IEnumerable<node<int, animal>>: ");
            foreach (node<int, animal> T in tree3) // test iменованого iтератора в foreach:
            {
                Console.Write($"({T.key},{T.value}), ");
            }
        }
    }
}
