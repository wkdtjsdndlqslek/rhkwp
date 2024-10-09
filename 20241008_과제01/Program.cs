using Microsoft.VisualBasic.FileIO;
using System.Numerics;
using static _20241008_과제01.Program;

namespace _20241008_과제01
{
    internal class Program
    {
        public interface IBehavior
        {
            void Attack(Character c);
            void Defence();
            void Move();
        }
        public abstract class Character : IBehavior
        {
            protected string name;
            protected int att;
            protected int def;
            protected int spd;
            protected int location;
            protected bool isDef;
            protected int hp;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public int HP
            {
                get { return hp; }
                set { hp = value; }
            }
            public int ATT
            {
                get { return att; }
                set { att = value; }
            }
            public int DEF
            {
                get { return def; }
                set { def = value; }
            }
            public int SPD
            {
                get { return spd; }
                set { spd = value; }
            }
            public int Location
            {
                get { return location; }
                set { location = value; }
            }
            public bool IsDef
            {
                get { return isDef; }
                set { isDef = value; }
            }
            public abstract void Attack(Character c);
            public abstract void Defence();
            public abstract void Move();
            public void MovingGimmick()
            {
                
                switch (Name)
                {
                    case "플레이어":
                        while (true)
                        {
                            Console.WriteLine("1.왼쪽으로 가기 0.오른쪽으로 가기");
                            int playerChoice = int.Parse(Console.ReadLine());
                            if (playerChoice == 1||playerChoice==0)
                            {
                                switch (playerChoice)
                                {
                                    case 1:
                                        if (Location<1)
                                        { Console.WriteLine("더 이상 왼쪽으로 이동 할 수 없다."); }
                                        else if(Location-SPD<0)
                                        {
                                            Console.WriteLine($"플레이어가 왼쪽으로 {-Location}만큼 이동");
                                            Location = 0;
                                        }
                                        else
                                        {
                                            Location-=SPD;
                                            Console.WriteLine($"플레이어가 왼쪽으로 {SPD}만큼 이동");
                                        }
                                        break;
                                    case 0:
                                        if (Location>9)
                                        {
                                            Console.WriteLine("더 이상 오른쪽으로 이동 할 수 없다.");
                                        }
                                        else if (Location-SPD>10)
                                        {
                                            Console.WriteLine($"플레이어가 오른쪽으로 {SPD-Location+10}만큼 이동");
                                            Location = 10;
                                        }
                                        else
                                        {
                                            Location+=SPD;
                                            Console.WriteLine($"플레이어가 오른쪽으로 {SPD}만큼 이동");
                                        }
                                        break;
                                }
                                break;
                            }
                            Console.WriteLine("다시 입력하세요.");
                        }
                        break;
                    case "몬스터":
                        Random rand = new Random();
                        int cpuChoice = rand.Next(0, 2);
                        switch (cpuChoice)
                        {
                            case 1:
                                if (Location<1)
                                { Console.WriteLine("몬스터는 왼쪽으로 더 이상 이동 할 수 없다."); }
                                else
                                {
                                    Location-=SPD;
                                    Console.WriteLine($"몬스터가 왼쪽으로 {SPD}만큼 이동");
                                }
                                break;
                            case 0:
                                if (Location>9)
                                {
                                    Console.WriteLine("몬스터는 오른쪽으로 더 이상 이동 할 수 없다.");
                                }
                                else
                                {
                                    Location+=SPD;
                                    Console.WriteLine($"몬스터가 오른쪽으로 {SPD}만큼 이동");
                                }
                                break;
                        }
                        break;
                }
            }
            public void AttackGimmick(Character enemy)
            {
                if (location-spd<=enemy.Location&&enemy.Location<=location+spd)
                {
                    if(enemy.IsDef)
                    {
                        Console.WriteLine($"{enemy.Name}이/가 방어에 성공했습니다.");
                    }
                    else
                    {
                        Console.WriteLine("공격 성공!");
                        GiveDamage(att,enemy);
                    }
                    
                }
                else
                {
                    Console.WriteLine("사정거리가 닿지 않았습니다.");
                }
            }
            public void GiveDamage(int damage, Character enemy)
            {
                enemy.hp-=(damage-enemy.DEF);
                Console.WriteLine($"{enemy.name}이/가 {damage-enemy.DEF}만큼 데미지를 입었습니다.");
            }
        }
        public class Mage : Character
        {
            public Mage(string n)
            {
                name = n; hp=100; att=30; def=20; spd=2;
            }

            public override void Attack(Character c)
            {
                Console.WriteLine($"{name}의 파이어볼!");
                AttackGimmick(c);
            }
            public override void Defence()
            {
                Console.WriteLine ($"{name}의 매직쉴드!");
                isDef = true;
            }
            public override void Move()
            {
                Console.WriteLine($"{name}의 텔레포트!");
                MovingGimmick();
            }
        }
        public class Knight : Character
        {
            public Knight(string n)
            {
                name=n; hp=500; att=100; def=10; spd=1;
            }

            public override void Attack(Character c)
            {
                Console.WriteLine($"{name}의 방망이 휘두르기");
                AttackGimmick(c);
            }
            public override void Defence()
            {
                Console.WriteLine($"{name}의 막기");
                isDef = true;
            }
            public override void Move()
            {
                Console.WriteLine($"{name}의 뚜벅뚜벅");
                MovingGimmick();
            }

        }
        public class Archer : Character
        {
            public Archer(string n)
            {
                name = n; hp=200; att=20; def=10; spd=3;
            }

            public override void Attack(Character c)
            {
                Console.WriteLine($"{name}의 에로우 레인!");
                AttackGimmick(c);
            }
            public override void Defence()
            {
                Console.WriteLine($"{name}의 트리가드!");
                isDef = true;
            }
            public override void Move()
            {
                Console.WriteLine($"{name}의 플레시 점프!");
                MovingGimmick();
            }
        }
        public class ChoiceClass
        {
            public Character ChoiceCharacter()
            {   
                
                while (true)
                {
                    Console.WriteLine("캐릭터를 선택해주세요.");
                    Console.WriteLine("1.법사 2.전사 3.궁수");
                    Character player = null;
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            player = new Mage("플레이어");
                            Console.WriteLine("법사를 선택하셨습니다.");
                            break;
                        case 2:
                            player = new Knight("플레이어");
                            Console.WriteLine("전사를 선택하셨습니다.");
                            break;
                        case 3:
                            player = new Archer("플레이어");
                            Console.WriteLine("궁수를 선택하셨습니다.");
                            break;
                        default:
                            Console.WriteLine("다시 선택하세요");
                            break;
                    }
                    player.Location = 0;
                    if (player != null)
                    {
                        return player;
                    }
                }
            }
            public Character EnemyCharacter()
            {
                Console.WriteLine("몬스터가 나타났습니다.");
                Character cpu = null;
                Random rand = new Random();
                switch (rand.Next(0, 3))
                {
                    case 0:
                        cpu = new Mage("몬스터");
                        Console.WriteLine("흑마법사 출현!");
                        break;
                    case 1:
                        cpu = new Knight("몬스터");
                        Console.WriteLine("흑기사 출현!");
                        break;
                    default:
                        cpu = new Archer("몬스터");
                        Console.WriteLine("다크엘프 출현!");
                        break;
                }
                cpu.Location = 10;
                return cpu;
            }
            public string ChoiceBehavior()
            {
                Console.WriteLine("행동을 선택하세요");
                while (true)
                {
                    Console.WriteLine("1.공격 2.방어 3.이동");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice== 1||choice==2||choice==3)
                    {
                        switch (choice)
                        {
                            case 1:
                                return "Attack";
                            case 2:
                                return "Defence";
                            default:
                                return "Move";
                        }
                    }
                    else { Console.WriteLine("다시 입력해주세요"); }
                }
            }
            public string CpuBehavior()
            {
                Random rand = new Random();
                int choice = rand.Next(0, 3);
                switch(choice)
                {
                    case 1:
                        return "Attack";
                    case 2:
                        return "Defence";
                    default:
                        return "Move";
                }    
            }
            public void BattleResult(Character p, Character c)
            {
                p.IsDef=false;
                c.IsDef=false;
                string pb = ChoiceBehavior();
                string cb = CpuBehavior();
                switch (pb)
                {
                    case "Attack":
                        switch (cb)
                        {
                            case "Attack":
                                p.Attack(c);
                                c.Attack(p);
                                break;
                            case "Defence":
                                c.Defence();
                                p.Attack(c);
                                break;
                            default:
                                c.Move();
                                p.Attack(c);
                                break;
                        }
                        break;
                    case "Defence":
                        switch (cb)
                        {
                            case "Attack":
                                p.Defence();
                                c.Attack(p);
                                break;
                            case "Defence":
                                p.Defence();
                                c.Defence();
                                break;
                            default:
                                p.Defence();
                                c.Move();
                                break;
                        }
                        break;
                    default:
                        switch (cb)
                        {
                            case "Attack":
                                p.Move();
                                c.Attack(p);
                                break;
                            case "Defence":
                                p.Move();
                                c.Defence();
                                break;
                            default:
                                p.Move();
                                c.Move();
                                break;
                        }
                        break;
                }
            }
            public void PrintLocation(Character p, Character c)
            {
                if (p.Location<c.Location)
                {
                    for (int i = 0; i<p.Location; i++)
                    {
                        Console.Write("·");
                    }
                    Console.Write(p.Name);
                    for (int i = 0; i<c.Location-p.Location; i++)
                    {
                        Console.Write("·");
                    }
                    Console.Write(c.Name);
                    for (int i = 0; i<10-c.Location; i++)
                    {
                        Console.Write("·");
                    }
                    Console.WriteLine();
                }
                else if (c.Location<p.Location)
                {
                    for (int i = 0; i<c.Location; i++)
                    {
                        Console.Write("·");
                    }
                    Console.Write(c.Name);
                    for (int i = 0; i<p.Location-c.Location; i++)
                    {
                        Console.Write("·");
                    }
                    Console.Write(p.Name);
                    for (int i = 0; i<10-p.Location; i++)
                    {
                        Console.Write("·");
                    }
                    Console.WriteLine();
                }
                else
                {
                    for (int i = 0; i<p.Location; i++)
                    {
                        Console.Write("·");
                    }
                    Console.Write($"{p.Name},{c.Name}");
                    for (int i = 0; i<10-p.Location; i++)
                    {
                        Console.Write("·");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"{p.Name} 체력: {p.HP}, {c.Name} 체력: {c.HP}");
            }
               
            
        }
        static void Main(string[] args)
        {
            ChoiceClass choiceClass = new ChoiceClass();
            Character player= choiceClass.ChoiceCharacter();
            Character cpu = choiceClass.EnemyCharacter();
            while (true)
            {
                choiceClass.PrintLocation(player,cpu);
                choiceClass.BattleResult(player, cpu);
                if (player.HP==0)
                { Console.WriteLine($"{player.Name}이 승리했습니다."); break; }
                else if (cpu.HP==0)
                { Console.WriteLine($"{cpu.Name}이 승리했습니다."); break; }
            }
        }
    }
}
