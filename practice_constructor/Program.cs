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
            //クラス定数呼び出し
            Console.WriteLine($"１科目めは{Score.Subject1}です");
            Console.WriteLine($"２科目めは{Score.Subject2}です");
            //クラスメソッド呼び出し
            Score.TotalScore(70,40);
            //クラスフィールド呼び出し
            Console.WriteLine($"合格点は{Score.PassingScore}点です");

            var s1 = new Score(90,67);
            var s2 = new Score(86,78);

            var l1 = new Lunch() { 
            mainDish="カレー",
            subDish="切り干し大根"
            };
            //既定値をそのまま使用して呼び出し
            l1.Show();
            //既定値を上書き
            l1.Show("飲むヨーグルト");
            //順番入れ替えながら既定値を上書き
            l1.Show(dessert:"いちご",drink:"お茶");
            //引数に何個指定してもOK
            Console.WriteLine($"総カロリーは{l1.Calory(200, 300, 450, 20)}です");
            Console.WriteLine(l1.CaloryOld("5年生",900,30,20,300));
        }
    }

    #region Booksクラス定義
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
    #endregion

    #region Scoreクラス定義
    class Score
    {
        public int japanese_language;
        public int sociology;

        //静的コンストラクター
        static Score()
        {
            Console.WriteLine("点数発表");
        }

        //クラスフィールド
        public static int PassingScore = 120;

        //クラス定数
        public static readonly string Subject1 = "数学";
        public const string Subject2 = "化学";

        //クラスメソッド
        public static void TotalScore(int math,int science)
        {
            Console.WriteLine($"合計点は{math+science}です");
        }

        //通常のコンストラクター
        public Score(int japanese_language, int sociology)
        {
            this.japanese_language = japanese_language;
            this.sociology = sociology;
            Console.WriteLine($"国語は{japanese_language}点で社会は{sociology}点です");
        }
    }
    #endregion

    #region
    class Lunch
    {
        public string mainDish;
        public string subDish;

        //既定値を設定する。
        public void Show(string drink="牛乳",string dessert="みかん")
        {
            Console.WriteLine($"今日の献立は{drink}と{this.mainDish}と{this.subDish}と{dessert}です");
        }
        //可変長引数のメソッド
        public int Calory(params int[] values)
        {
            int totalCalory = 0;
            foreach(var i in values)
            {
                totalCalory += i;
            }
            return totalCalory;
        }
        //可変長引数は引数の最後に指定する
        public string CaloryOld(string schoolYear,params int[] values)
        {
            int totalCalory = 0;
            foreach (var i in values)
            {
                totalCalory += i;
            }
            return $"{schoolYear}の摂取カロリーは{totalCalory}です";
        }

    }
    #endregion
}
