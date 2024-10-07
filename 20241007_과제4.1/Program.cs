namespace _20241007_과제4._1
{
    internal class Program
    {
        struct Card
        {
            int shape;
            int number;
            public void reset(Card[] k)
            {
                for (int i = 0; i < 52; i++)
                {
                    k[i].number = i + 1;
                }
            }

            public void shuffle(Card[] k)
            {
                Card temp;
                Random r = new Random();
                for (int i = 0; i < 500; i++)
                {
                    int sour, dest;
                    dest = r.Next(52);
                    sour = r.Next(52);
                    temp = k[dest];
                    k[dest] = k[sour];
                    k[sour] = temp;
                }
            }

            public int choice(Card[] k, int u)
            {
                for (int i = 0; i < 3; i++)
                {
                    k[i].shape = k[i + u].number / 13;
                    k[i].number = k[i + u].number % 13 + 1;
                    switch (k[i].shape)
                    {
                        case 0:
                            Console.WriteLine(" spade ");
                            break;
                        case 1:
                            Console.WriteLine(" dia ");
                            break;
                        case 2:
                            Console.WriteLine(" heart ");
                            break;
                        default:
                            Console.WriteLine(" club ");
                            break;
                    }
                    switch (k[i].number)
                    {
                        case 1:
                            Console.WriteLine(" ace ");
                            break;
                        case 11:
                            Console.WriteLine(" J ");
                            break;
                        case 12:
                            Console.WriteLine(" Q ");
                            break;
                        case 13:
                            Console.WriteLine("K");
                            break;
                        default:
                            Console.WriteLine(k[i].number);
                    }

                }
                return k[0].number, k[1].number, k[2].number;
            }

            public int bet(int m)
            {
                int b;
                while (true)
                {

                    Console.WriteLine($"소지금: {m} ");
                    Console.WriteLine("배팅하세요 ");
                    b = int.Parse(Console.ReadLine());
                    if (b > m)
                    {
                        Console.WriteLine("소지금보다 많은 배팅을 할 수 없습니다.");
                    }
                    else break;
                }
                return b;
            }

            public int gameresult(Card k[], int m, int b)
            {
                if (k[0].number<k[2].number && k[2].number<k[1].number || k[0].number > k[2].number && k[2].number > k[1].number)
                {
                    Console.WriteLine("이겼습니다.");
                    m += b;
                    Console.WriteLine($"소지금: {m}");
                }
                else
                {
                    Console.WriteLine("졌습니다.");
                    m -= b;
                    Console.WriteLine($"소지금: {m} ");
                }
                return m;
            }
        }
        static void Main(string[] args)
        {
            int betting = 0;
            int money = 10000;
            int usecard = 0;
            Card[] cards=new Card[52];
            Card card =new Card();
            while (true)
            {
                card.reset(cards);

                card.shuffle(cards);

                card.choice(cards, usecard);

                Console.WriteLine();

                money = card.gameresult(cards, money, card.bet(money));

                usecard += 3;

                if (money < 1000) { Console.WriteLine("패배하셨습니다."); break; }

            }
        }
    }
}
