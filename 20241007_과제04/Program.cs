using System.Text;
using System.Linq;

namespace _20241007_과제04
{

    internal class Grade
    {
        string name;
        int math;
        int eng;
        int sci;
        static void Main(string[] args)
        {
            int[] gradeArr;
            gradeArr= new int[4];
            Console.WriteLine("국어 점수를 입력하세요");
            gradeArr[0]=int.Parse(Console.ReadLine());
            Console.WriteLine("수학 점수를 입력하세요");
            gradeArr[1]=int.Parse(Console.ReadLine());
            Console.WriteLine("사회 점수를 입력하세요");
            gradeArr[2]=int.Parse(Console.ReadLine());
            Console.WriteLine("과학 점수를 입력하세요");
            gradeArr[3]=int.Parse(Console.ReadLine());
            int min = gradeArr.Min();
            Console.WriteLine($"가장 낮은 성적 : {min}");
            int max = gradeArr.Max();
            Console.WriteLine($"가장 높은 성적 : {max}");
            Console.WriteLine($"성적 평균 : {gradeArr.Average()}");
            Array.Sort( gradeArr );
            Console.Write("성적 오름차순 정렬 : ");
            for (int i = 0; i < gradeArr.Length; i++)
            {
                Console.Write(gradeArr[i]);
                if (i<gradeArr.Length-1)
                { Console.Write(", "); }
            }
            Console.WriteLine();
            

        }
    }
}