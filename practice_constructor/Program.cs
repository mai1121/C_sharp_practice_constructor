using System;

namespace practice_constructor
{
    class HomeWork
    {
        static void Main(string[] args)
        {
            var b1 = new Books("ノルウェイの森", "村上春樹");
            Console.WriteLine(b1.Show());
            Console.WriteLine(b1.record);

            //コンストラクター②が呼び出される
            var b2 = new Books();
            Console.WriteLine(b2.Show());

            //オブジェクト初期化子
            var b3 = new Books()
            {
                author = "三島由紀夫",
                title = "春の雪"
            };
            Console.WriteLine(b3.Show());
        }
    }

    class Books
    {
        public string title;
        public string author;
        public string record;

        //コンストラクター①
        public Books(string title,string author)
        {
            this.title = title;
            this.author = author;
            this.record = $"{title}:{author}";
        }
        //コンストラクター②
        //コンストラクター初期化子に引数を渡す
        public Books() : this("こころ","夏目漱石") { }

        public string Show()
        {
            return $"{this.author}作の{this.title}を読みました";
        }


    }

 
}
