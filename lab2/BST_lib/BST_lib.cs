using System;
using System.Collections;
using System.Collections.Generic;
namespace BST_lib
{
    public class node<K, V> where K : IComparable where V : IComparable
    {
        public K key;
        public V value;
        public node<K, V> left;
        public node<K, V> right;
        public node(K key, V value)
        {
            this.key = key;
            this.value = value;
            left = null;
            right = null;
        }
    }
    public class EventArgs
    {
        public string mes;
        public EventArgs(string mes)
        {
            this.mes = mes;
        }
    }
    public class b_t<K, V>:IEnumerable<node<K,V>> 
        where K : IComparable where V : IComparable //там в низу є iтератор, просто вiн в iнтерфейсi не прописаний, але вiн є i в фореч циклi норм працює
    {
        // Додавання вузлів є, обходи дерева є 3, перевірка на наявність є, пошук є (видалення могло б бути, трохи складно було б, але реалізовувати не обов’язково)
        // Виключні ситуації: Я органiзував перевiрку типiв при додавання вузла в дерево.
        public node<K, V> top;
        public delegate void del1(object o, EventArgs e);
        public event del1? ev1;
        public int count = 0;
        public b_t()
        {
            top = null;
        }
        public node<K, V> find(node<K, V> T, K key)
        {
            if (T == null) return null;
            if (key.CompareTo(T.key) == 0) return T;
            if (key.CompareTo(T.key) > 0) return find(T.right, key);
            if (key.CompareTo(T.key) < 0) return find(T.left, key);
            return null;
        }
        public bool exist(K key, V value)
        {
            ev1?.Invoke(this, new EventArgs($"перевiрка на наявнiсть ({key},{value})"));
            node<K, V> rez = find(key);
            if (rez != null && value.CompareTo(rez.value) == 0) return true;
            else return false;
        }
        public node<K, V> find(K key)
        {
            ev1?.Invoke(this, new EventArgs($"пошук елементу з ключем {key}"));
            return find(top, key);
        }
        public void insert(ref node<K, V> T, K key, V value)
        {
            if (T == null)
            {
                T = new node<K, V>(key, value);
                count++;
            }
            else if (key.CompareTo(T.key) > 0) insert(ref T.right, key, value);
            else if (key.CompareTo(T.key) < 0) insert(ref T.left, key, value);
            else if (key.CompareTo(T.key) == 0) T.value = value;
        }


        public void insert(object? k0, object? v0)
        {
            if (k0 is K key && v0 is V value) //перевiрка типiв при додавання вузла в дерево.
            {
                insert(ref top, key, value);
                ev1?.Invoke(this, new EventArgs($"добавили елемент({key},{value})"));
            }
            else throw new Exception("в дерево добавляють тип даних, який не вiдповiдає оголошеному при iнiцiалiзацiї дерева");
        }

        public string LCR(node<K, V> T) //обхiд лiвий-центр-правий
        {
            string rezult = "";
            if (T == null) return "";
            rezult += LCR(T.left);
            rezult += $"({T.key},{T.value}), ";
            rezult += LCR(T.right);
            return rezult;
        }
        public string LCR()
        {
            ev1?.Invoke(this, new EventArgs($"обхiд лiвий корiнь правий:"));
            return LCR(top);
        }
        public string CLR(node<K, V> T) //обхiд центр-лiвий-правий
        {
            string rezult = "";
            if (T == null) return "";
            rezult += $"({T.key},{T.value}), ";
            rezult += CLR(T.left);
            rezult += CLR(T.right);
            return rezult;
        }
        public string CLR()
        {
            ev1?.Invoke(this, new EventArgs($"обхiд корiнь-лiвий-правий"));
            return CLR(top);
        }

        public string LRC(node<K, V> T) //обхiд лiвий-правий-центр
        {
            string rezult = "";
            if (T == null) return "";
            rezult += LRC(T.left);
            rezult += LRC(T.right);
            rezult += $"({T.key},{T.value}), ";
            return rezult;
        }
        public string LRC()
        {
            ev1?.Invoke(this, new EventArgs($"обхiд лiвий-правий-корiнь"));
            return LRC(top);
        }
        //public IEnumerator<node<K, V>> GetEnumerator()    // працює але з костилями, переупакував дерево в список через обхід і вивів ітерацію списку.
        //                                                  //Але знизу здогадався як зробити нормальний рекурентний ітератор
        //{
        //    ev1?.Invoke($"запустили iтератор");
        //    List<node<K, V>> rez = new List<node<K, V>>();
        //    void LCR1(node<K, V> T) //обхiд лiвий-центр-правий
        //    {
        //        if (T == null) return;
        //        LCR1(T.left);
        //        rez.Add(T);
        //        LCR1(T.right);
        //    }
        //    LCR1(top);
        //    //можна так return rez.GetEnumerator(); а можна i так
        //    for (int i = 0; i < rez.Count; i++) yield return rez[i];
        //    //перекинув обходом дерево в список i вивiв через простий iтератор.
        //}

        public IEnumerator<node<K, V>> GetEnumerator(node<K, V> T) //нарешті вдалось перетворити рекурентний обхід на нормальний ітератор, сам здогадався, як разібрав роботу змінної енумератора
        {
            if (T == null) yield break;
            IEnumerator<node<K, V>> l = GetEnumerator(T.left); // виявляється що якщо рекурентно повертаємо IEnumerator то там повертається ціла пачка значень, скинув їх в змінну l
            while (l.MoveNext()) yield return l.Current; // і їх треба перенаправити вище по рекурсії в циклі,
                                                         // тобто в циклі розпакував енумератор наокремі значення і передав їх вверх по рекурсії через yield return
            yield return T;
            IEnumerator<node<K, V>> r = GetEnumerator(T.right); // те саме з правим піддеревом
            while (r.MoveNext()) yield return r.Current;
        }
        public IEnumerator<node<K, V>> GetEnumerator()
        {
            ev1?.Invoke(this, new EventArgs($"викликали iтератор"));
            return GetEnumerator(top);
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
